using CoreService.Models.Interfaces;
using System.Collections.Generic;
using Telegram.Bot;

namespace CoreService.Models.Entities
{
    public class Bot
    {
        public TelegramBotClient client;
        private List<ICommand> commandsList;

        public IReadOnlyList<ICommand> Commands => commandsList.AsReadOnly();

        public Bot(string ApiKey, string url)
        {
            client = new TelegramBotClient(ApiKey);
            var hook = string.Format(url, "api/message/update");
            client.SetWebhookAsync(hook).RunSynchronously();

            commandsList = new List<ICommand>();
        }
    }
}
