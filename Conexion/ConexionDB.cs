namespace TiendaApi.Conexion
{
    public class ConexionDB
    {
        private string connectionString = string.Empty;

        public ConexionDB()
        {
            var constructor = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = constructor.GetSection("ConnectionStrings:Connection").Value;
        }

        public string CadenaSQL()
        {
            return connectionString; 
        }
    }
}
