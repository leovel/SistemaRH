using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace RH.Manager.Localization
{
    public class CustomLocalizationManager : LocalizationManager
    {
        public override string GetStringOverride(string key)
        {
            switch (key)
            {
                case "GridViewAlwaysVisibleNewRow": return "Clique aqui para adicionar um novo elemento";	            //Click here to add new item
                case "GridViewClearFilter": return "Limpar filtro";	                            //Clear Filter
                case "GridViewFilter": return "Filtro";	                                //Filter
                case "GridViewFilterAnd": return "e";		                            //And
                case "GridViewFilterContains": return "Contem";	                        //Contains
                case "GridViewFilterDoesNotContain": return "Não contem";		                //Does not contain
                case "GridViewFilterEndsWith": return "Acaba com";                        //Ends with
                case "GridViewFilterIsContainedIn": return "É contido em";	                    //Is contained in
                case "GridViewFilterIsEqualTo": return "É igual a";                        //Is equal to
                case "GridViewFilterIsGreaterThan": return "É maior que";                    //Is greater than
                case "GridViewFilterIsGreaterThanOrEqualTo": return "Maior ou igual que";		        //Is greater than or equal to
                case "GridViewFilterIsNotContainedIn": return "Não é contido em";	                //Is not contained in
                case "GridViewFilterIsLessThan": return "É menor que";                    //Is less than
                case "GridViewFilterIsLessThanOrEqualTo": return "É menor ou igual que";	            //Is less than or equal to
                case "GridViewFilterIsNotEqualTo": return "É diferente de";                    //Is not equal to
                case "GridViewFilterMatchCase": return "Maiúsculas/minúsculas";                       //Match case
                case "GridViewFilterOr": return "ou";                          //Or
                case "GridViewFilterSelectAll": return "Seleccionar tudo";                       //Select All
                case "GridViewFilterShowRowsWithValueThat": return "Mostrar linhas com valor que";            //Show rows with value that
                case "GridViewFilterStartsWith": return "Começa com";	                    //Starts with
                case "GridViewFilterIsNull": return "É nulo";                        //Is null
                case "GridViewFilterIsNotNull": return "Não é nulo";                        //Is not null
                case "GridViewFilterIsEmpty": return "É vazio";	                        //Is empty
                case "GridViewFilterIsNotEmpty": return "Não é vazio";                    //Is not empty
                case "GridViewFilterDistinctValueNull": return "[nulo]";                //[null]
                case "GridViewFilterDistinctValueStringEmpty": return "[vazio]";	        //[empty]
                //case "GridViewGroupPanelText": return "Arraste um cabeçado de uma coluna para qui\npara agrupar por essa coluna";                     //Drag a column header and drop it here to group by that column
                case "GridViewGroupPanelText": return "Os cabeçalhos das colunas [Direcção] ou/e [Estado] podem ser arrastados aqui para agrupar.";                     //Drag a column header and drop it here to group by that column
                case "GridViewGroupPanelTopText": return "Cabeçalho de Grupo";                    //Group Header
                case "GridViewGroupPanelTopTextGrouped": return "Agrupadas por:";               //Grouped by:
                                                                                                //////////////////////////ScheduleView//////////////////////////////////
                                                                                                //case "AllDayEvent": return "Todo o Dia";
                case "Yes": return "Sim";
                case "No": return "Não";
                case "True": return "Verdadeiro";
                case "False": return "Falso";
                case "Appointment": return "Componente";
                //case "AppointmentRecurrence": return "Recorrência";
                //case "AppointmentTime": return "Tempo";
                //case "Body": return "Corpo";
                //case "Busy": return "Ocupado";
                //case "Cancel": return "Cancelar";
                //case "Categorize": return "Categorizar";
                case "CreateAppointment": return "Criar Componente";
                //case "Daily": return "Diario";
                //case "Day": return "Dia";
                //case "Days": return "Dias";
                case "DeleteAppointment": return "Remover Componente";
                case "DeleteItem": return "Remover Componente";
                case "DeleteItemQuestion": return "Seguro que deseja eliminar o componente?";
                //case "DeleteOccurrence": return "";
                //case "DeleteRecurringItem": return "";
                //case "DeleteRecurringItemQuestion": return "";
                //case "DeleteSeries": return "";
                //case "DurationColon": return "";
                //case "DurationDay": return "";
                //case "DurationDays": return "";
                //case "DurationHour": return "";
                //case "DurationHours": return "";
                //case "DurationMinute": return "";
                //case "DurationMinutes": return "";
                //case "DurationWeek": return "";
                //case "DurationWeeks": return "";
                //case "EditAppointment": return "";
                //case "EditParentAppointment": return "";
                //case "EditRecurrence": return "";
                //case "EditRecurrenceCommandText": return "";
                //case "EditRecurrenceRule": return "";
                //case "EndAfter": return "";
                //case "EndBy": return "";
                //case "EndColon": return "";
                //case "EndDateBeforeStart": return "";
                case "EndTime": return "Data de Terminação";
                //case "Event": return "";
                //case "Every": return "";
                case "EveryDay": return "Tudos os dias";
                case "EveryWeekday": return "Tudos os dias da semana";
                //case "First": return "";
                //case "Fourth": return "";
                //case "Free": return "";
                case "HighImportance": return "Alta Importancia";
                //case "InvalidRecurrenceRuleMessage": return "";
                //case "InvalidRecurrenceRuleTitle": return "";
                //case "Last": return "";
                //case "LowImportance": return "";
                //case "Month": return "";
                //case "Monthly": return "";
                //case "Months": return "";
                //case "NoEndDate": return "";
                //case "Occurrences": return "";
                //case "Of": return "";
                //case "OfEvery": return "";
                //case "Ok": return "";
                //case "OpenOccurrence": return "";
                //case "OpenRecurringItem": return "";
                //case "OpenRecurringItem
                //case "OpenSeries": return "";
                //case "OutOfOffice": return "";
                //case "RangeOfRecurrence": return "";
                //case "RecurEvery": return "";
                //case "RecurrencePattern": return "";
                //case "RemoveRecurrence": return "";
                //case "SaveAndClose": return "";
                //case "SaveAndCloseCommandText": return "";
                //case "SaveAppointment": return "";
                //case "SaveRecurrence": return "";
                //case "Second": return "";
                //case "SetDayViewMode": return "";
                //case "SetMonthViewMode": return "";
                //case "SetTimelineViewMode": return "";
                //case "SetWeekViewMode": return "";
                //case "ShowAs": return "";
                //case "Start": return "";
                //case "StartColon": return "";
                case "StartTime": return "Data de Començo";
                case "Subject": return "Nome";
                //case "Tentative": return "";
                //case "The": return "";
                //case "Third": return "";
                //case "Timeline": return "";
                //case "Untitled": return "";
                //case "Week": return "";
                //case "WeekDays": return "";
                //case "WeekendDays": return "";
                //case "Weekly": return "";
                //case "WeeksOn": return "";
                //case "Yearly": return "";
                //case "DragRecurringWarning": return "";
                default:
                    break;
            }
            return base.GetStringOverride(key);
        }
    }
}
