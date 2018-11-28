using CryptoTrackerServiceBus.Exception;
using CryptoTrackerServiceBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrackerServiceBus
{
    public class Transaction : ITransaction
    {
        private readonly ILogger logger;
        private readonly Queue<Action> actions = new Queue<Action>();

        public Transaction(ILogger logger, int retries = 0)
        {
            this.logger = logger;
            Retries = retries;
        }

        public int Retries { get; set; }

        public ITransaction AddAction(Action action)
        {
            actions.Enqueue(action);
            return this;
        }

        public void Run()
        {
            try
            {
                RunTask(actions.Dequeue());
            }
            catch (SystemException ex) {
                logger.Error(ex.Message);
            }
        }

        public void RunTask(Action action)
        {
            if (action == null) return;
            var currentTries = 0;
            while (currentTries <= Retries)
            {
                try
                {
                    action.Invoke();
                    RunTask(actions.Dequeue());
                }
                catch (SystemException) {
                    if (++currentTries > Retries)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
