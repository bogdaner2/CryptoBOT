using CoreService.Models.Interfaces;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CoreService.Models.Entities
{
    public class ReflectCommand : ICommand
    {
        public string Name => "reflect";

        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains("CryptoSeeker");
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, message.Text, replyToMessageId: messageId);
        }
    }
}
