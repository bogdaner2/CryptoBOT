using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using static System.Console;

namespace CryptoTracker
{
    class Program
    {
        static TelegramBotClient botClient = new TelegramBotClient("656960876:AAH_XWa0UR-dZiW2X4RMqQDDqd-bERWezWw");

        static void Main(string[] args)
        {
            botClient.OnMessage += BotOnMessageReceived;
            botClient.StartReceiving(new[] { UpdateType.Message });
            WriteLine("Start working...");
            ReadLine();
        }
        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            WriteLine("Recieved message: " + message.Text);
            await botClient.SendTextMessageAsync(message.Chat.Id, message.Text);
        }
    }
}
