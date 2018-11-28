using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace CryptoTracker
{
    class Bot
    {
        private readonly TelegramBotClient botClient;

        public Bot()
        {
            botClient = new TelegramBotClient("656960876:AAH_XWa0UR-dZiW2X4RMqQDDqd-bERWezWw");
        }

        private async void OnMessageRecived(object sender, MessageEventArgs messageEventArgs)
        {
        }
    }
}
