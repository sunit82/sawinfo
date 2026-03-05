using SAWDAL.Repository;
using SAWDAL.SAWEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPages
{
    public static class Utility
    {
        public static string GetPageContent(string pageName)
        {
            string pageData = "";
            //string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\SAWINFO\MyPages\MyPages\App_Data\SAWINFO.mdb'; providerName=JetEntityFrameworkProvider";
            using (var unitOfWork = new UnitOfWork(new SAWContext("sawManagerConnection")))
            {
                pageData = unitOfWork.ContentManagers.GetContent(pageName)?.PageContent;
            }
            return pageData;
        }

        public static List<ContentManager> GetContentPageList()
        {
            List<ContentManager> data;
            using (var unitOfWork = new UnitOfWork(new SAWContext("sawManagerConnection")))
            {
                data = unitOfWork.ContentManagers.GetContentPageList();
            }
            return data;
        }
    }
}