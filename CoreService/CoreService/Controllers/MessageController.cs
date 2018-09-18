using CoreService.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CoreService.Controllers
{
    public class MessageController : Controller
    {
        private Bot telegramBot;

        public MessageController(Bot telegramClient)
        {
            this.telegramBot = telegramClient;
        }

        [Route(@"api/message/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = telegramBot.Commands;
            var message = update.Message;

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, telegramBot.client);
                    break;
                }
            }

            return Ok();
        }
    }
}
