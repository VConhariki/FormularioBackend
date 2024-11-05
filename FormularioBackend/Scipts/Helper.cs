namespace FormularioBackend.Scipts
{
    public static class Helper
    {
        private static readonly string rootDirectory = Directory.GetCurrentDirectory();

        public static string ObterConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(rootDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
            return connectionString;
        }
    }
}
