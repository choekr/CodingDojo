using System.Collections.Generic;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using quotingdojoRedux.Models;
using Microsoft.Extensions.Options;
using System.Linq;

namespace quotingdojoRedux.Factory
{
    public class UserFactory : IFactory<User>
    {
        private readonly IOptions<MySqlOptions> mysqlConfig;

        public UserFactory(IOptions<MySqlOptions> conf) 
        {
            mysqlConfig = conf;
        }
        internal IDbConnection Connection
        {
            get 
            {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }
        public void Add(User item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query = "INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES (@FirstName, @LastName, @Email, @Password, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }

        public User FindByEmail(string email)
        {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE email = @Email", new {Email = email}).FirstOrDefault();
            }
        }

        public User GrabEmail(string email)
        {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT email FROM users WHERE email = @Email", new {Email = email}).FirstOrDefault();
            }
        }
    }
}