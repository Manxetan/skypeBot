using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot_Application3.Dialogs
{
    [Serializable]

    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
  
            var activity = await result as Activity;

            string UserName = (activity.From.Name);         
                await context.PostAsync($"Привет {UserName}. ");

            context.Wait(MessageReceivedAsync);
        }
    }
}  