using CRM.DataAccess;

namespace RH.Extensions
{
    public static class ActivityExtensions
    {
        /// <summary>
        /// Updates all activity non-navigational properties from another activity.
        /// </summary>
        /// <param name="original">Activity whose properties will update.</param>
        /// <param name="value">Activity whose properties will be used.</param>
        public static void UpdateAllProperties(this Activity original, Activity value)
        {
            if (original.ActivityID != value.ActivityID)
            {
                original.ActivityID = value.ActivityID;
            }

            if (original.DateCreated != value.DateCreated)
            {
                original.DateCreated = value.DateCreated;
            }

            if (original.Description != value.Description)
            {
                original.Description = value.Description;
            }

            if (original.DueDate != value.DueDate)
            {
                original.DueDate = value.DueDate;
            }

            if (original.Notes != value.Notes)
            {
                original.Notes = value.Notes;
            }

            if (original.Priority != value.Priority)
            {
                original.Priority = value.Priority;
            }

            if (original.Status != value.Status)
            {
                original.Status = value.Status;
            }

            if (original.Type != value.Type)
            {
                original.Type = value.Type;
            }

            if (original.Opportunity != value.Opportunity)
            {
                original.Opportunity = value.Opportunity;
            }
            
            if (original.OpportunityID != value.OpportunityID)
            {
                original.OpportunityID = value.OpportunityID;
            }
        }
    }
}
