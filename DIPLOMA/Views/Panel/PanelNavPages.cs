using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DIPLOMA.Views.Panel
{
    public static class PanelNavPages
    {
        public static string Index => "Index";
        public static string Messages => "Messages";
        public static string Notification => "Notification";
        public static string Fundraising => "Fundraising";
        public static string Statistic => "Statistic";
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string MessagesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Messages);
        public static string NotificationNavClass(ViewContext viewContext) => PageNavClass(viewContext, Notification);
        public static string FundraisingNavClass(ViewContext viewContext) => PageNavClass(viewContext, Fundraising);
        public static string StatisticNavClass(ViewContext viewContext) => PageNavClass(viewContext, Statistic);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
