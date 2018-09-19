using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Sample.SimpleEchoBot;
using Microsoft.Teams.Samples.TaskModule.Web.Helper;
using Newtonsoft.Json.Linq;

namespace Microsoft.Teams.Samples.TaskModule.Web.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new RootDialog());
            }

            else if (activity.Type == ActivityTypes.Invoke)
            {
                if (activity.Name == "task/fetch")
                {

                    // TODO: Convert this to helpers once available.
                    JObject taskEnvelope = new JObject();

                    JObject taskObj = new JObject();
                    JObject taskInfo = new JObject();

                    taskObj["value"] = taskInfo;
                    taskObj["type"] = "continue";
                    if (activity.Value.ToString().Contains("html"))
                        taskInfo["url"] = ApplicationSettings.BaseUrl + "/customform";
                    else
                        taskInfo["card"] = JObject.FromObject(AdaptiveCardHelper.GetAdaptiveCard());

                    taskInfo["title"] = "Test";

                    taskEnvelope["task"] = taskObj;

                    return Request.CreateResponse(HttpStatusCode.OK, taskEnvelope);

                }
                else if (activity.Name == "task/submit")
                {
                    Console.WriteLine(activity.Value);

                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    Activity reply = activity.CreateReply("Received = " + activity.Value.ToString());
                    connector.Conversations.ReplyToActivity(reply);
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            return new HttpResponseMessage(HttpStatusCode.Accepted);

        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.InstallationUpdate)
            {
                // Handle add/remove from contact lists
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}
