using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using CRM.Converters;
using CRM.Modules.Repository.Services;
using CRM.Repository.Extensions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace RH.Helpers
{
    public static class Categories
    {
        public static readonly ActivityCategory CallCategory = new ActivityCategory("CALL", (Brush)Application.Current.Resources["ScheduleCallBrush"]);
        public static readonly ActivityCategory MailCategory = new ActivityCategory("MAIL", (Brush)Application.Current.Resources["ScheduleMailBrush"]);
        public static readonly ActivityCategory MeetCategory = new ActivityCategory("MEET", (Brush)Application.Current.Resources["ScheduleMeetBrush"]);
    }

    public static class TimeMarkers
    {
        public static readonly TimeMarker NotStartedTimeMarker = new TimeMarker("NOT STARTED", (Brush)new SolidColorBrush(Colors.Transparent));
        public static readonly TimeMarker InProgressTimeMarker = new TimeMarker("IN PROGRESS", (Brush)new SolidColorBrush(Colors.Transparent));
        public static readonly TimeMarker DoneTimeMarker = new TimeMarker("DONE", (Brush)new SolidColorBrush(Colors.Transparent));
    }

    public class ActivityAppointment : Appointment
    {
        private Activity activity;

        public ActivityAppointment()
        {
            this.Activity = new Activity() { Status = 0, Type = 0, Priority = 1 };
            this.UniqueId = "0";
        }

        public ActivityAppointment(Activity activity)
        {
            this.Activity = activity;
            this.UniqueId = activity.ActivityID.ToString();

            ActivityType activityType = activity.Type.HasValue ? (ActivityType)activity.Type.Value : ActivityType.Call;
            this.Resources.Add(new Resource()
            {
                ResourceName = activityType.ToString(),
                ResourceType = "Activities"
            });
        }

        public Activity Activity
        {
            get
            {
                return this.Storage<ActivityAppointment>().activity;
            }
            set
            {
                using (var storage = this.Storage<ActivityAppointment>())
                {
                    if (storage.activity != value)
                    {
                        storage.activity = value;
                        this.OnPropertyChanged(() => this.Activity);
                    }
                }
            }
        }

        public override string Body
        {
            get
            {
                return this.Activity.Notes;
            }
            set
            {
                this.Activity.Notes = value;
            }
        }

        public override ICategory Category
        {
            get
            {
                switch (this.Activity.Type)
                {
                    case (int)ActivityType.Mail:
                        return Categories.MailCategory;
                    case (int)ActivityType.Call:
                        return Categories.CallCategory;
                    case (int)ActivityType.Meet:
                        return Categories.MeetCategory;
                    default:
                        return Categories.MailCategory;
                }
            }
            set
            {
                if (value != null)
                {
                    this.Activity.Type = this.GetActivityTypeByString(value.CategoryName);
                }
                this.OnPropertyChanged("Category");
            }
        }

        public override DateTime End
        {
            get
            {
                return this.Activity.DueDate.GetValueOrDefault().ToLocalTime();
            }
            set
            {
                this.Activity.DueDate = value.ToUniversalTime();
                this.OnPropertyChanged("End");
            }
        }

        public override DateTime Start
        {
            get
            {
                return this.Activity.DateCreated.GetValueOrDefault().ToLocalTime();
            }
            set
            {
                this.Activity.DateCreated = value.ToUniversalTime();
            }
        }

        public override string Subject
        {
            get
            {
                return this.Activity.Description;
            }
            set
            {
                this.Activity.Description = value;
            }
        }

        public override Importance Importance
        {
            get
            {
                int priority = this.Activity.Priority.GetValueOrDefault(0);
                var importance = (Importance)PriorityTypeToImportanceConverter.Instance.Convert((PriorityType)priority, typeof(Importance), null, CultureInfo.CurrentCulture);
                return importance;
            }
            set
            {
                var priority = (int)PriorityTypeToImportanceConverter.Instance.ConvertBack(value, typeof(PriorityType), null, CultureInfo.CurrentCulture);
                this.Activity.Priority = priority;
            }
        }

        public override ITimeMarker TimeMarker
        {
            get
            {
                switch (this.Activity.Status)
                {
                    case (int)ActivityStatusType.NotStarted:
                        return TimeMarkers.NotStartedTimeMarker;
                    case (int)ActivityStatusType.InProgress:
                        return TimeMarkers.InProgressTimeMarker;
                    case (int)ActivityStatusType.Done:
                        return TimeMarkers.DoneTimeMarker;
                    default:
                        return TimeMarkers.NotStartedTimeMarker;
                }
            }
            set
            {
                if (value != null)
                {
                    switch (value.TimeMarkerName)
                    {
                        case "NOT STARTED":
                            this.Activity.Status = (int)ActivityStatusType.NotStarted;
                            break;
                        case "IN PROGRESS":
                            this.Activity.Status = (int)ActivityStatusType.InProgress;
                            break;
                        case "DONE":
                            this.Activity.Status = (int)ActivityStatusType.Done;
                            break;
                        default:
                            this.Activity.Status = (int)ActivityStatusType.NotStarted;
                            break;
                    }
                }
            }
        }

        public Opportunity Opportunity
        {
            get
            {
                return this.Activity.Opportunity;
            }
            set
            {
                this.Activity.Opportunity = value;
                this.Activity.OpportunityID = (value != null) ? value.OpportunityID : 0;
            }
        }

        public override void CopyFrom(IAppointment other)
        {
            base.CopyFrom(other);
            ActivityAppointment appointment = other as ActivityAppointment;
            if (appointment != null)
            {
                this.Opportunity = appointment.Opportunity;
                this.Activity.UpdateAllProperties(appointment.Activity);
                if (this.Resources.Count > 0)
                {
                    this.Activity.Type = this.GetActivityTypeByString(this.Resources[0].DisplayName);
                }
            }
        }

        public override IAppointment Copy()
        {
            IAppointment appointment = new ActivityAppointment();
            appointment.CopyFrom(this);
            return appointment;
        }

        private int GetActivityTypeByString(string activityTypeString)
        {
            int result;
            switch (activityTypeString.ToUpper())
            {
                case "MAIL":
                    result = (int)ActivityType.Mail;
                    break;
                case "CALL":
                    result = (int)ActivityType.Call;
                    break;
                case "MEET":
                    result = (int)ActivityType.Meet;
                    break;
                default:
                    result = (int)ActivityType.Mail;
                    break;
            }

            return result;
        }
    }

    public class ActivityCategory : Category
    {
        public ActivityCategory()
            : base()
        {
        }

        public ActivityCategory(string categoryName, Brush brush)
            : base(categoryName, brush)
        {
        }

        public override int GetHashCode()
        {
            return this.CategoryName.GetHashCode();
        }

        public override bool Equals(object other)
        {
            Category category = (other as ActivityCategory);

            return category == null ? false : this.CategoryName.Equals(category.CategoryName);
        }
    }
}
