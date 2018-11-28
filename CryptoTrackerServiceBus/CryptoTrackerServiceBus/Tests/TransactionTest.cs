using CryptoTrackerServiceBus.Interfaces;
using CryptoTrackerServiceBus.Interfaces.External;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrackerServiceBus.Tests
{
    class TransactionTest
    {
        private IAPI api;
        private int apiCalls;
        private IBot bot;
        private int botCalls;
        private ILogger logger;

        [SetUp]
        public void SetUp()
        {
            var ApiMock = new Moq.Mock<IAPI>();
            ApiMock.Setup(a => a.AggregateExternalSources()).Returns(new Task(() => { apiCalls++;}));
            api = ApiMock.Object;
            var BotMock = new Moq.Mock<IBot>();
            BotMock.Setup(a => a.NotifyRateChange()).Returns(new Task(() => { botCalls++; }));
            bot = BotMock.Object;
            logger = new Logger();
        }
        [Test]
        public void TestQueOk()
        {
            var que = new TaskFactory(logger, bot, api).BuildAggregationTask();
            que.Run();
            Assert.AreEqual(1, apiCalls);
            Assert.AreEqual(1, botCalls);
        }
    }
}
