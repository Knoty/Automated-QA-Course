using Microsoft.Extensions.Configuration;

namespace Lesson2026_Ui_Markelov.Base
{
    public static class Config
    {
        private static readonly IConfiguration _configuration;

        static Config()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string BaseUrl => _configuration["BaseUrl"]
            ?? throw new InvalidOperationException("BaseUrl не указан в настройках appsettings.json");
    }
}
