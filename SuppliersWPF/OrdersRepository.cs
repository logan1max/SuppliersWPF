using Dapper;
using SuppliersWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppliersWPF
{
    public interface IOrdersRepository
    {
        void Create(ItemOrder item);
        void Delete(int id);
        List<Order> GetOrders();
        List<ItemOrder> GetOrderItems(int id);
        List<ItemOrder> GetItems();
        void Update(ItemOrder item);
    }

    public class OrdersRepository : IOrdersRepository
    {
        string connectionString = "Server=.\\SQLEXPRESS;Initial Catalog=SuppliersDB;Integrated Security=True";
        public OrdersRepository()
        {
            //    connectionString = conn;
        }
        public List<ItemOrder> GetItems()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<ItemOrder>("SELECT * FROM Users").ToList();
            }
        }

        public List<Order> GetOrders()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select orders.id, Statuses.name, sum(price * quantity) as cost ");
                sb.Append("from orders, statuses, Orders_goods ");
                sb.Append("where Statuses.id = Orders.id_status ");
                sb.Append("and Orders_goods.id_orders = Orders.id ");
                sb.Append("group by Orders.id, statuses.name ");

                return db.Query<Order>(sb.ToString()).ToList();
            }
        }


        public List<ItemOrder> GetOrderItems(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT id_goods as idItem, Goods.name as nameItem");
                sb.Append(",quantity as quantityItem");
                sb.Append(",orders_goods.price as priceItem");
                sb.Append(",Suppliers.id as idSupplier");
                sb.Append(",Suppliers.name as nameSupplier");
                sb.Append(",Suppliers.address as addressSupplier");
                sb.Append(",Suppliers.phone as phoneSupplier ");
                sb.Append("FROM orders_goods, suppliers, goods ");
                sb.Append("where Suppliers.id in ");
                sb.Append("(select Goods.id_suppliers ");
                sb.Append("from goods ");
                sb.Append("where Goods.id = Orders_goods.id_goods) ");
                sb.Append("AND id_goods = Goods.id ");
                sb.Append("AND id_orders = @id");

                return db.Query<ItemOrder>(sb.ToString(), new { id }).ToList();
            }
        }

        public void Create(ItemOrder item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, item);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }

        public void Update(ItemOrder item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, item);
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
