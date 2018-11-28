using CryptoTrackerServiceBus.Interfaces;
using CryptoTrackerServiceBus.Interfaces.External;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrackerServiceBus
{
    class TaskFactory
    {
        private readonly ILogger logger;
        private readonly IBot bot;
        private readonly IAPI api;

        public TaskFactory(ILogger logger, IBot bot, IAPI api)
        {
            this.logger = logger;
            this.bot = bot;
            this.api = api;
        }

        public ITransaction BuildAggregationTask()
        {
            return new Transaction(logger, 5)
                .AddAction(async () => {
                    await api.AggregateExternalSources();
                })
                 .AddAction(async () => {
                     await bot.NotifyRateChange();
                 });
            
        }
    }
}
