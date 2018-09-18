using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CoreService.Models.Interfaces
{
    public interface ICommand
    {
        string Name { get; }

        Task Execute(Message message, TelegramBotClient client);

        bool Contains(string command);
    }
}
