using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Microsoft.Teams.Samples.TaskModule.Web.Helper
{
    public static class ApplicationSettings
    {
        public static readonly string BaseUrl;

        public static readonly string BaseUrlEncoded;

        public static readonly string MicrosoftAppId;

        static ApplicationSettings()
        {
            BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            MicrosoftAppId = ConfigurationManager.AppSettings["MicrosoftAppId"];

            BaseUrlEncoded = HttpUtility.UrlEncode(BaseUrl);
        }
    }
}