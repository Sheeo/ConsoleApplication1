using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Tss.WindowsGame1
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the game.
        /// </summary>
        static void Main(string[] args)
        {
            setupLogging();
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }

        private static void setupLogging()
        {
            var conf = new LoggingConfiguration();
            var coloredConsoleTarget = new ColoredConsoleTarget
                                           {
                                               Name = "Console",
                                               Layout = @"${date:format=HH\:MM\:ss} ${logger} ${message}"
                                           };
            var consoleRule = new LoggingRule("*", LogLevel.Trace, coloredConsoleTarget);
            conf.AddTarget("Console", coloredConsoleTarget);
            conf.LoggingRules.Add(consoleRule);
            LogManager.Configuration = conf;
        }
    }
#endif
}

