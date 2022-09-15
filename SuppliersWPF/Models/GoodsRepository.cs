using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppliersWPF.Models
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Delete(int id);
        Product Get(int id);
        List<Product> GetGoods();
        void Update(Product product);
    }
    public class GoodsRepository : IProductRepository
    {
        string connectionString;
        public GoodsRepository(string conn)
        {
                connectionString = conn;
        }
        public List<Product> GetGoods()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select goods.id, goods.name, ");
                sb.Append("goods.price, goods.weight, ");
                sb.Append("goods.date_price, goods.id_suppliers, Suppliers.name  as sup_name, ");
                sb.Append("Suppliers.address, Suppliers.phone ");
                sb.Append("from goods, Suppliers ");
                sb.Append("where goods.id_suppliers = Suppliers.id ");

                return db.Query<Product>(sb.ToString()).ToList();
            }
        }

        public Product Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Product>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Product product)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, product);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }

        public void Update(Product product)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, product);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

    }
}
