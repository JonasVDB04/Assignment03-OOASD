using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess.SqlServer;

public abstract class BaseDao
{
    private readonly string _connectionString;

    protected BaseDao()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddUserSecrets<BaseDao>().Build();
        string? connectionStringBase = config.GetConnectionString("DefaultConnection");
        SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(connectionStringBase);
        sqlBuilder.UserID = config["SQL:UserID"];
        sqlBuilder.Password = config["SQL:Password"];
        _connectionString = sqlBuilder.ConnectionString;
    }

    protected SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}