using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QHRMTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace QHRMTest.Data
{
    public class QHRMProductRepository
    {
        private readonly string _connectionString;

        public QHRMProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<QHRMProducts> GetAllProducts()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<QHRMProducts>("SELECT * FROM QHRMProducts").ToList();
        }

        public void AddProduct(QHRMProducts product)
        {
            product.Created = DateTime.Now;
            using var connection = new SqlConnection(_connectionString);
            const string sql = "INSERT INTO QHRMProducts (Name, Description, Price, Created) VALUES (@Name, @Description, @Price, @Created)";
            connection.Execute(sql, product);
        }


        public QHRMProducts GetProductById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingleOrDefault<QHRMProducts>("SELECT * FROM QHRMProducts WHERE Id = @Id", new { Id = id });
        }

        public void UpdateProduct(QHRMProducts product)
        {
            using var connection = new SqlConnection(_connectionString);
            const string sql = "UPDATE QHRMProducts SET Name = @Name, Description = @Description, Price = @Price WHERE Id = @Id";
            connection.Execute(sql, product);
        }


        public void DeleteProduct(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("DELETE FROM QHRMProducts WHERE Id = @Id", new { Id = id });
        }
    }
}
