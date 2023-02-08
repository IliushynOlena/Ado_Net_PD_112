using data_access;
using data_access.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace _02_ConnectedModeCRUD
{
    //#region Клaс Продукт
    //class Product
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Type { get; set; }
    //    public int Quantity { get; set; }
    //    public int CostPrice { get; set; }
    //    public string Producer { get; set; }
    //    public int Price { get; set; }

    //}
    //#endregion
    //class SportShopDb
    //{
    //    //CRUD interface
    //    //[C]reate
    //    //[R]ead
    //    //[U]pdate
    //    //[D]elete
    //    private SqlConnection connection;
     
    //    public SportShopDb(string connectionString)
    //    {
    //        connection = new SqlConnection(connectionString);
    //        connection.Open();
    //    }
    //    ~SportShopDb()
    //    {
    //        connection.Close();
    //    }
    //    public void Create(Product product)
    //    {
    //        string cmdText = $@"INSERT INTO Products
    //                           VALUES (@name, 
    //                                   @type, 
    //                                   @quantity, 
    //                                   @costPrice, 
    //                                   @producer, 
    //                                   @price)";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.Parameters.AddWithValue("name",product.Name);
    //        command.Parameters.AddWithValue("type", product.Type);
    //        command.Parameters.AddWithValue("quantity", product.Quantity);
    //        command.Parameters.AddWithValue("costPrice", product.CostPrice);
    //        command.Parameters.AddWithValue("producer", product.Producer);
    //        command.Parameters.AddWithValue("price", product.Price);
    //        command.CommandTimeout = 5;           
    //        command.ExecuteNonQuery();
    //    }
    //    public List<Product> GelAll()
    //    {
    //        string cmdText = @"select * from Products";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        SqlDataReader reader = command.ExecuteReader();
    //        return this.GetProductsByQuery(reader);
    //    }
    //    public void Update(Product product)
    //    {
    //        string cmdText = $@"UPDATE Products
    //                           SET Name = @name, 
    //                               TypeProduct = @type, 
    //                               Quantity = @quantity, 
    //                               CostPrice = @costPrice, 
    //                               Producer =@producer, 
    //                               Price = @price
    //                               WHERE Id = {product.Id}";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.Parameters.AddWithValue("name", product.Name);
    //        command.Parameters.AddWithValue("type", product.Type);
    //        command.Parameters.AddWithValue("quantity", product.Quantity);
    //        command.Parameters.AddWithValue("costPrice", product.CostPrice);
    //        command.Parameters.AddWithValue("producer", product.Producer);
    //        command.Parameters.AddWithValue("price", product.Price);
    //        command.CommandTimeout = 5;
    //        command.ExecuteNonQuery();
    //    }
    //    public void Delete(int id)
    //    {
    //        string cmdText = $@"Delete Products where Id = {id}";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.ExecuteNonQuery();
    //    }
    //    public Product GetOneById(int id)
    //    {
    //        string cmdText = $@"select  * from Products WHERE Id = {id}";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        SqlDataReader reader = command.ExecuteReader();
       
    //        return this.GetProductsByQuery(reader).FirstOrDefault();
    //    }
    //    public List<Product> GetOneByName(string name)
    //    {
           
    //        string cmdText = $@"select * from Products WHERE Name = @name";
    //        SqlCommand command = new SqlCommand(cmdText, connection);
    //        command.Parameters.Add("name",System.Data.SqlDbType.NVarChar).Value = name;

    //        //SqlParameter sql = new SqlParameter()
    //        //{
    //        //    ParameterName = "name",
    //        //    SqlDbType = System.Data.SqlDbType.NVarChar,
    //        //    Value = name
    //        //};
    //        //command.Parameters.Add(sql);

    //        SqlDataReader reader = command.ExecuteReader();
    //        return this.GetProductsByQuery(reader);
           
    //    }
    //    private List<Product> GetProductsByQuery(SqlDataReader reader)
    //    {            
    //        List<Product> products = new List<Product>();
    //        while (reader.Read())
    //        {
    //            products.Add(new Product()
    //            {
    //                Id = (int)reader[0],
    //                Name = (string)reader[1],
    //                Type = (string)reader[2],
    //                Quantity = (int)reader[3],
    //                CostPrice = (int)reader[4],
    //                Producer = (string)reader[5],
    //                Price = (int)reader[6]
    //            });
    //        }
    //        reader.Close();
    //        return products;
    //    }


    //}
    internal class Program
    {
        static void Main(string[] args)
        {
            string con = @"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                Initial Catalog=SportShop;Integrated Security=True;
                                Connect Timeout = 2";
            SportShopDb db = new SportShopDb(con);
            Console.OutputEncoding = Encoding.UTF8;
            Product product = new Product()
            {
                Name = "Football T-Shirt",
                Type = "Sport Clothes",
                Quantity = 12,
                CostPrice = 600,
                Producer = "Turkey",
                Price = 400
            };
            //db.Create(product);
            //var p = db.GelAll();
            Console.WriteLine("Enter name of product to search:");
            string name = Console.ReadLine();

            List<Product> products = db.GetOneByName(name);
            foreach (var item in products)
            {
                Console.WriteLine(item.Id + " " + item.Name+ " " +
                    item.CostPrice + " " + item.Producer);
            }
            

            var p = db.GetOneById(29);
            Console.WriteLine(p.Id + " " + p.Name);
             p.Price = 800;
             p.CostPrice = 1000;
             p.Quantity = 100;

            db.Update(p);

            var p1 = db.GelAll();
            foreach (var item in p1)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " +
                    item.CostPrice + " " + item.Producer);
            }
        }
    }
}
