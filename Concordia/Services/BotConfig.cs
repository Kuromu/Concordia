namespace Concordia.Services
{
    using System;
    using System.IO;
    using Newtonsoft.Json.Linq;
    using NLog;

    public class BotConfig
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private readonly string configFilename = Path.Combine(Directory.GetCurrentDirectory(), "Data/Botconfig.json");

        public BotConfig()
        {
            if (!File.Exists(configFilename))
            {
                log.Fatal($"Could not load bot configuration file from source {configFilename}. Check file permissions and locations and restart the bot.");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            try
            {
                var data = JObject.Parse(File.ReadAllText(configFilename));

                BotId = data.SelectToken("BotId").ToObject<ulong>();
                Token = data.SelectToken("Token").ToString();
                if (string.IsNullOrWhiteSpace(Token))
                {
                    log.Fatal("Token is missing from BotConfig.json. Add it and restart the bot.");
                    Console.ReadKey();
                    Environment.Exit(-2);
                }
            }
            catch (Exception ex)
            {
                log.Fatal(ex, ex.Message, null);
                throw;
            }
        }

        public ulong BotId { get; private set; }

        public string Token { get; private set; }
    }
}
