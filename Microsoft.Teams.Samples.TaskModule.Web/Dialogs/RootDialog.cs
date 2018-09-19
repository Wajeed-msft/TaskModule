using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;
using Microsoft.Bot.Connector.Teams.Models;
using System.Collections.Generic;
using AdaptiveCards;
using Microsoft.Bot.Connector.Teams;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Microsoft.Bot.Sample.SimpleEchoBot
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private static Dictionary<string, string> privateStorage = new Dictionary<string, string>();

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = (Activity)await argument;
            var messageText = message.GetTextWithoutMentions();
            var reply = message.CreateReply();

            ThumbnailCard card = new ThumbnailCard();

            // dynamic jsonResponse = JsonConvert.DeserializeObject(@"{'type': 'task/fetch','taskModule': 'open'}");

            try
            {
                card.Buttons = new List<CardAction>();
                card.Buttons.Add(new CardAction("invoke", "HTML", null, "{\"type\": \"task/fetch\", \"action\": \"html\"}"));
                card.Buttons.Add(new CardAction("invoke", "Adaptive Card", null, "{\"type\": \"task/fetch\" , \"action\": \"adaptivecard\"}"));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            

            reply.Attachments.Add(card.ToAttachment());
            await context.PostAsync(reply);
            context.Wait(MessageReceivedAsync);
        }

    }
}