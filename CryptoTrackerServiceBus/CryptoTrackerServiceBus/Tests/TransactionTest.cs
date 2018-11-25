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
        private IBot bot;
        private ILogger logger;

        [SetUp]
        public void SetUp()
        {
            var mock = new Moq.Mock<IAPI>();
            mock.Setup(a => a.AggregateExternalSources()).Returns(new Task(() => { }));
        }
    }
}
