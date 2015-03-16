﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    
    #line 2 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using CronExpressionDescriptor;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using Hangfire.Storage;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class RecurringJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");









            
            #line 9 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
  
    Layout = new LayoutPage("Recurring jobs");
	List<RecurringJobDto> recurringJobs;
    
    int from, perPage;

    int.TryParse(Query("from"), out from);
    int.TryParse(Query("count"), out perPage);

    Pager pager = null;

	using (var connection = Storage.GetConnection())
	{
	    var storageConnection = connection as JobStorageConnection;
	    if (storageConnection != null)
	    {
	        pager = new Pager(from, perPage, storageConnection.GetRecurringJobCount());
	        recurringJobs = storageConnection.GetRecurringJobs(pager.FromRecord, pager.FromRecord + pager.RecordsPerPage - 1);
	    }
	    else
	    {
            recurringJobs = connection.GetRecurringJobs();
	    }
	}


            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h1 class=\"page-header\"" +
">Recurring Jobs</h1>\r\n\r\n");


            
            #line 39 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
         if (recurringJobs.Count == 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"alert alert-info\">\r\n                No recurring jobs fou" +
"nd.\r\n            </div>\r\n");


            
            #line 44 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"js-jobs-list\">\r\n                <div class=\"btn-toolbar b" +
"tn-toolbar-top\">\r\n                    <button class=\"js-jobs-list-command btn bt" +
"n-sm btn-primary\"\r\n                            data-url=\"");


            
            #line 50 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                 Write(Url.To("/recurring/trigger"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                            data-loading-text=""Triggering..."">
                        <span class=""glyphicon glyphicon-play-circle""></span>
                        Trigger now
                    </button>

                    <button class=""js-jobs-list-command btn btn-sm btn-default""
                            data-url=""");


            
            #line 57 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                 Write(Url.To("/recurring/remove"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                            data-loading-text=""Removing...""
                            data-confirm=""Do you really want to REMOVE ALL selected jobs?"">
                        <span class=""glyphicon glyphicon-remove""></span>
                        Remove
                    </button>

");


            
            #line 64 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                     if (pager != null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        ");

WriteLiteral(" ");


            
            #line 66 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                      Write(Html.PerPageSelector(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 67 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral(@"                </div>

                <table class=""table"">
                    <thead>
                    <tr>
                        <th class=""min-width"">
                            <input type=""checkbox"" class=""js-jobs-list-select-all""/>
                        </th>
                        <th class=""min-width"">Id</th>
                        <th class=""min-width"">Cron</th>
                        <th>Time zone</th>
                        <th>Job</th>
                        <th class=""align-right min-width"">Next execution</th>
                        <th class=""align-right min-width"">Last execution</th>
                    </tr>
                    </thead>
                    <tbody>
");


            
            #line 85 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                     foreach (var job in recurringJobs)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr class=\"js-jobs-list-row hover\">\r\n                    " +
"        <td>\r\n                                <input type=\"checkbox\" class=\"js-j" +
"obs-list-checkbox\" name=\"jobs[]\" value=\"");


            
            #line 89 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                                                     Write(job.Id);

            
            #line default
            #line hidden
WriteLiteral("\"/>\r\n                            </td>\r\n                            <td class=\"mi" +
"n-width\">");


            
            #line 91 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                             Write(job.Id);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td class=\"min-width\">");


            
            #line 92 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                             Write(ExpressionDescriptor.GetDescription(job.Cron));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td class=\"min-width\">\r\n");


            
            #line 94 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                 if (!String.IsNullOrWhiteSpace(job.TimeZone))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <span title=\"");


            
            #line 96 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                            Write(TimeZoneInfo.FindSystemTimeZoneById(job.TimeZone).DisplayName);

            
            #line default
            #line hidden
WriteLiteral("\" data-container=\"body\">");


            
            #line 96 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                                                                                  Write(job.TimeZone);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");


            
            #line 97 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    ");

WriteLiteral(" UTC\r\n");


            
            #line 101 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </td>\r\n                            <td>\r\n");


            
            #line 104 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                 if (job.Job != null)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    ");

WriteLiteral(" ");


            
            #line 106 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                  Write(Html.JobName(job.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 107 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <em>");


            
            #line 110 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                   Write(job.LoadException.InnerException.Message);

            
            #line default
            #line hidden
WriteLiteral("</em>\r\n");


            
            #line 111 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </td>\r\n                            <td class=\"align-r" +
"ight min-width\">\r\n");


            
            #line 114 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                 if (job.NextExecution != null)
                                {
                                    
            
            #line default
            #line hidden
            
            #line 116 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                               Write(Html.RelativeTime(job.NextExecution.Value));

            
            #line default
            #line hidden
            
            #line 116 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                               
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <em>N/A</em>\r\n");


            
            #line 121 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </td>\r\n                            <td class=\"align-r" +
"ight min-width\">\r\n");


            
            #line 124 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                 if (job.LastExecution != null)
                                {
                                    if (!String.IsNullOrEmpty(job.LastJobId))
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <a href=\"");


            
            #line 128 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                            Write(Url.JobDetails(job.LastJobId));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                            <span class=\"label label-default " +
"label-hover\" style=\"");


            
            #line 129 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                                            Write(String.Format("background-color: {0};", JobHistoryRenderer.GetForegroundStateColor(job.LastJobState)));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                                ");


            
            #line 130 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                           Write(Html.RelativeTime(job.LastExecution.Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </span>\r\n                          " +
"              </a>\r\n");


            
            #line 133 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                    }
                                    else
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <em>\r\n                                   " +
"         Canceled\r\n                                            ");


            
            #line 138 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                       Write(Html.RelativeTime(job.LastExecution.Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </em>\r\n");


            
            #line 140 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                    }
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <em>N/A</em>\r\n");


            
            #line 145 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </td>\r\n                        </tr>\r\n");


            
            #line 148 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    </tbody>\r\n                </table>\r\n\r\n");


            
            #line 152 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                 if (pager != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                    ");

WriteLiteral(" ");


            
            #line 154 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                  Write(Html.Paginator(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 155 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n");


            
            #line 157 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>    ");


        }
    }
}
#pragma warning restore 1591
