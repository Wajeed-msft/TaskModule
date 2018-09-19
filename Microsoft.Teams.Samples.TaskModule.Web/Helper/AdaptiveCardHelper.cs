using AdaptiveCards;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Teams.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace Microsoft.Teams.Samples.TaskModule.Web.Helper
{
    /// <summary>
    ///  Helper class which posts to the saved channel every 20 seconds.
    /// </summary>
    public static class AdaptiveCardHelper
    {
        private static string _adaptiveCardJson;

        public static string AdaptiveCardJson
        {
            get {
                if(_adaptiveCardJson == null)
                    _adaptiveCardJson = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~\Resources\Cards\AdaptiveCard.json"));

                return _adaptiveCardJson;
            }
        }


        public static string GetAdaptiveCardJson()
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath(@"~\Resources\Cards\AdaptiveCard.json");

            return File.ReadAllText(path);
        }

        public static Attachment GetAdaptiveCard()
        {

            // Parse the JSON 
            AdaptiveCardParseResult result = AdaptiveCard.FromJson(GetAdaptiveCardJson());

            // Get card from result
            AdaptiveCard card = result.Card;

            //var card2 = new AdaptiveCard()
            //{

            //    Body = new List<AdaptiveElement>()
            //    {
            //        new AdaptiveTextBlock(){Text="Adaptive Card",Weight=AdaptiveTextWeight.Bolder,Size=AdaptiveTextSize.ExtraLarge},new AdaptiveTextBlock(){Text="Your bots — wherever your users are talking",Weight=AdaptiveTextWeight.Bolder,Size=AdaptiveTextSize.Small},
            //        new AdaptiveImage(){Size=AdaptiveImageSize.Auto,Url=new System.Uri("https://pbs.twimg.com/profile_images/3647943215/d7f12830b3c17a5a9e4afcc370e3a37e_400x400.jpeg"), HorizontalAlignment=AdaptiveHorizontalAlignment.Left},
            //        new AdaptiveTextBlock(){Text="Build and connect intelligent bots to interact with your users naturally wherever they are, from text/sms to Skype, Slack, Office 365 mail and other popular services.",HorizontalAlignment=AdaptiveHorizontalAlignment.Left, MaxLines=10, Wrap=true }
            //    },

            //    Actions = new List<AdaptiveAction>()
            //    {
            //        new AdaptiveSubmitAction()
            //        {
            //            Title="Test Submit Action"
            //        },
            //        new AdaptiveOpenUrlAction()
            //        {
            //            Title="Open Another Task Module",
            //            Url=new System.Uri("https://teams.microsoft.com/l/task/d61ca023-5aa4-423c-8fd6-1a29d332616e?url=https%3A%2F%2F01f871ca.ngrok.io%2Fsecond&title=TestTitle&completionBotId=f25d8568-8dc3-4746-8b90-e03c9975a4ee")
            //        }
            //    },
            //};
            return new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card,

            };
        }
    }
}