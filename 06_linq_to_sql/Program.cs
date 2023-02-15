using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _06_linq_to_sql
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ShopClassesDataContext dbDataContext = new ShopClassesDataContext();

            //CRUD - Create, Read, Update, Delete

            //Read
            //var products =  dbDataContext.Products;
            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Product : {p.Id}  {p.Name}  {p.Price} $");
            //}

            //Find
            // var products = dbDataContext.Products.Where(p=>p.Price > 500).
            //     OrderByDescending(p => p.Price).Take(5);

            //var products = (from p in dbDataContext.Products
            //               where p.Price > 500
            //               orderby p.Price descending
            //               select p).Take(5);

            //foreach (var p in products) Console.WriteLine($"Product : {p.Id}  {p.Name}  {p.Price} $");

            var sportBottle = new Product()
            {
                Name = "My Bottle Protein",
                TypeProduct = "Drink",
                Quantity = 25,
                Price = 150,
                CostPrice = 100,
                Producer = "UA"
            };

            // dbDataContext.Products.InsertOnSubmit(sportBottle);
            //dbDataContext.Products.InsertOnSubmit(new Product() { });

            //dbDataContext.SubmitChanges();


            //Update
            //var productToEdit = dbDataContext.Products.Where(p => p.Id == 22).FirstOrDefault();
            //var productToEdit = dbDataContext.Products.FirstOrDefault(p => p.Id == 22);

            //productToEdit.Price -= 100;
            //productToEdit.CostPrice -= 100;
            //dbDataContext.SubmitChanges();


            //Delete
            var productToDelete = dbDataContext.Products.FirstOrDefault(p => p.Id == 22);

            if(productToDelete != null) 
                dbDataContext.Products.DeleteOnSubmit(productToDelete);
            dbDataContext.SubmitChanges();
            var products = dbDataContext.Products;
            foreach (var p in products) Console.WriteLine($"Product : {p.Id}  {p.Name}  {p.Price} $");

        }
    }
}
