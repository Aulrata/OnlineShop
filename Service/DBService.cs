using OnlineShop.DAL;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace OnlineShop.Service
{
    public delegate void ConnectionHandler(string message);
    public class DBService
    {
        private SqlConnection _sqlConnection;
        private OleDbConnection _oleDbConnection;
        private AppDBContext _appDBContext;
        private ConnectionHandler? _connect;
        public DBService()
        {
            _appDBContext = new AppDBContext();
            _sqlConnection = _appDBContext.StartLocalDBConnection();
            _oleDbConnection = _appDBContext.StartOleDBConnection();
        }

        public void RegisterHandler(ConnectionHandler del)
        {
            _connect = del;
        }

        public void CheckConnection()
        {
            TryOpenSQL();
            TryOpenOleDb();
        }

        private void TryOpenSQL()
        {
            try
            {
                _sqlConnection.Open();
                _connect?.Invoke("База данных SQL успешно открылась!");
            }
            catch (System.Exception ex)
            {
                _connect?.Invoke($"Error: {ex.Message}");
            }
            finally
            {
                _sqlConnection.Close();
                _connect?.Invoke("База данных SQL успешно закрылась!");
            }
        }
        private void TryOpenOleDb()
        {
            try
            {
                _oleDbConnection.Open();
                _connect?.Invoke("База данных OleBD успешно открылась!");
            }
            catch (System.Exception ex)
            {
                _connect?.Invoke($"Error: {ex.Message}");
            }
            finally
            {
                _oleDbConnection.Close();
                _connect?.Invoke("База данных OleBD успешно закрылась!");
            }
        }
    }
}
