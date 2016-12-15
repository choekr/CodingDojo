using System.Collections.Generic;
// using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using quotingDojo.Models;
namespace quotingDojo.Factory
{
    public class quoteFactory : IFactory<QuoteList>
    {
        private string connectionString;
        public quoteFactory()
        {
<<<<<<< HEAD
            connectionString = "server=localhost;userid="YourUserID";password="YourPassword";port="YourPort#";database="YourDbName";SslMode=None";
=======
            connectionString = "server=localhost;userid="userID";password="Password";port=8889;database="YourDatabaseName";SslMode=None";
>>>>>>> 49ca99ffc8bf4388d31a427c848bf62610ad76e2
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public IEnumerable<QuoteList> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<QuoteList>("SELECT * FROM quotingdojo");
            }
        }
        public void Add(QuoteList item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO quotingdojo (name, quote, created_at, updated_at) VALUES (@Name, @Quote, NOW(), NOW());";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  $"DELETE FROM quotingdojo WHERE id={id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public void Edit(int id)
        {
            using (IDbConnection dbConnection = Connection) {
                string query = $"UPDATE codingdojo SET quote=@quote, name=@name WHERE id={id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
    }
}
