using CryptoTrackerServiceBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTrackerServiceBus
{
    public class Logger : ILogger
    {
        public void Debug(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(_formatMessage(message));
            Console.ResetColor();
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(_formatMessage(message));
            Console.ResetColor();
        }

        public void Log(string message)
        {
            Console.WriteLine(_formatMessage(message));
        }

        public void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(_formatMessage(message));
            Console.ResetColor();
        }

        public void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_formatMessage(message));
            Console.ResetColor();
        }

        private string _formatMessage(string message)
        {
            var now = DateTime.Now.ToLocalTime();
            return $"[{now}]  {message}"; 
        }
    }
}
