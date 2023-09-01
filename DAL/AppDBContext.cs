using System.Data.SqlClient;
using System.Data.OleDb;

namespace OnlineShop.DAL
{
    public class AppDBContext
    {
        public SqlConnection StartLocalDBConnection()
        {
            SqlConnectionStringBuilder strCon = new()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "Shop",
                IntegratedSecurity = true,
                Pooling = true,
            };

            SqlConnection sqlConnection = new(strCon.ConnectionString);
            return sqlConnection;
        }

        public OleDbConnection StartOleDBConnection()
        {
            //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\D\Programming\DB\OnlineShop.accdb;Persist Security Info=True
            OleDbConnectionStringBuilder strCon = new()
            {
                Provider = "Microsoft.ACE.OLEDB.12.0",
                DataSource = @"C:\D\Programming\DB\OnlineShop.accdb",
                PersistSecurityInfo = true,
            };
            OleDbConnection oleDbConnection = new(strCon.ConnectionString);
            return oleDbConnection;
        }
    }
}
