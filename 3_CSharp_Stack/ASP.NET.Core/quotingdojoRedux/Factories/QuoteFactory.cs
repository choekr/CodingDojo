using System.Collections.Generic;
// using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using quotingdojoRedux.Models;
using System;
using Microsoft.Extensions.Options;

namespace quotingdojoRedux.Factory
{
    public class QuoteFactory : IFactory<QuoteItem>
    {
        private readonly IOptions<MySqlOptions> mysqlConfig;

        public QuoteFactory(IOptions<MySqlOptions> conf) 
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
        public IEnumerable<QuoteItem> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<QuoteItem>("SELECT * FROM quotes");
            }
        }
        public void Add(QuoteItem item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO quotes (user_id, quote, created_at, updated_at) VALUES (@user_id, @Quote, NOW(), NOW());";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  $"DELETE FROM quotes WHERE id={id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public IEnumerable<QuoteItem> QuoteById(int id)
        {
            using (IDbConnection dbConnection = Connection) {
                string query = $"SELECT quote FROM quotes WHERE id={id}";
                dbConnection.Open();
                return dbConnection.Query<QuoteItem>(query);
            }
        }
        public void Edit(QuoteItem Quote1, int id)
        {
            using (IDbConnection dbConnection = Connection) {
                string query = $"UPDATE quotes SET quote='{Quote1.Quote}', updated_at=NOW() WHERE id={id}";
                dbConnection.Open();
                dbConnection.Execute(query, Quote1);
            }
        }
        public IEnumerable<QuoteItem> QuotesByUserByID()
        {
            using (IDbConnection dbConnection = Connection) {
                var query = $"SELECT * FROM quotes JOIN users ON quotes.user_id WHERE users.id = quotes.user_id";
                dbConnection.Open();
                var myQuotes = dbConnection.Query<QuoteItem, User, QuoteItem>(query, (quote1, user1) => {quote1.user = user1; return quote1; });
                return myQuotes;
            }
        }

        public static implicit operator QuoteFactory(UserFactory v)
        {
            throw new NotImplementedException();
        }
    }
}