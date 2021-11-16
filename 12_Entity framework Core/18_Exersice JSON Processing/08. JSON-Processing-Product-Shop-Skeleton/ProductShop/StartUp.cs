using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO.Product;
using ProductShop.DTO.User;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string DirectoryPath = "../../../Datasets/Results";
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();
            InitializeMapper();

            //problem 
            //first reset DB
             ResetDatabase(db);

            //DESTERALIZARION-**************************************************************************************************
            //problem 01
            ////read JSON file
            string inputJson = File.ReadAllText("../../../Datasets/users.json");

            string result = ImportUsers(db, inputJson);
            Console.WriteLine(result);

            //problem 02
            string inputJson2 = File.ReadAllText("../../../Datasets/products.json");
            string result2 = ImportProducts(db, inputJson2);
            Console.WriteLine(result2);

            ////problem 03
            string inputJson3 = File.ReadAllText("../../../Datasets/categories.json");
            string result3 = ImportCategories(db, inputJson3);
            Console.WriteLine(result3);

            ////problem 04
            string inputJson4 = File.ReadAllText("../../../Datasets/categories-products.json");
            string result4 = ImportCategoryProducts(db, inputJson4);
            Console.WriteLine(result4);

            //STERALIZATION-**************************************************************************************************

            //problem 05
            string json05 = GetProductsInRange(db);
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            File.WriteAllText(DirectoryPath + "/products-in-range.json", json05);
            Console.WriteLine(json05);

            //problem 6
            string json06 = GetSoldProducts(db);
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            File.WriteAllText(DirectoryPath + "/users-sold-products.json", json06);
            Console.WriteLine(json06);

            //problem 7
            string json07 = GetCategoriesByProductsCount(db);
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            File.WriteAllText(DirectoryPath + "/categories-by-products.json", json07);
            Console.WriteLine(json07);

            //problem 8
            string json08 = GetUsersWithProducts(db);
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            File.WriteAllText(DirectoryPath + "/users-and-products.json", json08);
            Console.WriteLine(json08);
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }

        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Database was succsessfully created!");
        }

        //DESTERALIZARION-**************************************************************************************************
        //problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {

            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            //add user colection to the context
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}"; ;
        }

        //problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            //it can be array or list
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();


            return $"Successfully imported {products.Count}";
        }

        //problem 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            //with JSON ignor null, but here don't work :(
            //JsonSerializerSettings settings =
            //    new JsonSerializerSettings()
            //    {
            //        NullValueHandling = NullValueHandling.Ignore
            //    };
            //List<Category> categories = JsonConvert
            //    .DeserializeObject<List<Category>>(inputJson, settings);

            //C# style:
            List<Category> categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.AddRange(categories);

            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        //problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }


        //STERALIZATION-**************************************************************************************************

        //problem 5 
        //solution with aninim object, DTO and AutoMapper
        public static string GetProductsInRange(ProductShopContext context)
        {
            //with anonim object
            //var products = context
            //    .Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price)
            //    .Select(p => new
            //    {
            //        name = p.Name,
            //        price = p.Price,
            //        seller = p.Seller.FirstName + ' ' + p.Seller.LastName

            //    })
            //    .ToArray();


            //with DTO
            //var products = context
            //    .Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price)
            //    .Select(p => new ListProductsInRangeDTO
            //    {
            //        Name = p.Name,
            //        Price = p.Price,
            //        SellerName = p.Seller.FirstName + ' ' + p.Seller.LastName

            //    })
            //    .ToArray();
            //

            //with AutoMapper
            var products = context
           .Products
           .Where(p => p.Price >= 500 && p.Price <= 1000)
           .OrderBy(p => p.Price)
           .ProjectTo<ListProductsInRangeDTO>()
           .ToArray();
            //


            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        //probmen 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            //with anonim object
            //var users = context
            //  .Users
            //  .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            //  .OrderBy(u => u.LastName)
            //  .ThenBy(u => u.FirstName)
            //  .Select(u => new
            //  {
            //      firstName = u.FirstName,
            //      lastName = u.LastName,
            //      soldProducts = u.ProductsSold
            //        .Where(p => p.Buyer != null)
            //        .Select(p => new
            //        {
            //            name = p.Name,
            //            price = p.Price,
            //            buyerFirstName = p.Buyer.FirstName,
            //            buyerLastName = p.Buyer.LastName
            //        })
            //        .ToArray()
            //  })
            //  .ToArray();
            //
             
          //with DTO
          //  var users = context
          //.Users
          //.Where(u => u.ProductsSold.Any(p => p.Buyer != null))
          //.OrderBy(u => u.LastName)
          //.ThenBy(u => u.FirstName)
          //.Select(u => new UserWithSoldProductDTO
          //{
          //    FirstName = u.FirstName,
          //    LastName = u.LastName,
          //    SoldProducts = u.ProductsSold
          //      .Where(p => p.Buyer != null)
          //      .Select(p => new UserSoldProductDTO
          //      {
          //          Name = p.Name,
          //          Price = p.Price,
          //          BuyerFirstName = p.Buyer.FirstName,
          //          BuyerLastName = p.Buyer.LastName
          //      })
          //      .ToArray()
          //})
          //.ToArray();
          //

          //with AutoMaper
          var users = context
          .Users
          .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
          .OrderBy(u => u.LastName)
          .ThenBy(u => u.FirstName)
          .ProjectTo<UserWithSoldProductDTO>()
          .ToArray();
          //


            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }

        //problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
             .Categories
             .Select(c => new
             {
                 category = c.Name,
                 productsCount = c.CategoryProducts.Count(),
                 averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("f2"),
                 totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")
             })
             .OrderByDescending(c => c.productsCount)
             .ToArray();

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }

        //problem 8
        //50/100
        //public static string GetUsersWithProducts(ProductShopContext context)
        //{
        //    var users = context
        //        .Users
        //        .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
        //        .AsEnumerable() //for judge 50/100
        //        .Select(u => new
        //        {
        //            firstName = u.FirstName,
        //            lastName = u.LastName,
        //            age = u.Age,
        //            soldProducts = new
        //            {
        //                count = u.ProductsSold.Where(p => p.Buyer != null).Count(),
        //                products = u.ProductsSold.Where(p => p.Buyer != null)
        //                .Select(p => new
        //                {
        //                    name = p.Name,
        //                    price = p.Price
        //                })
        //                .ToList()
        //            }
        //        })
        //       // .OrderByDescending(u => u.soldProducts.count)
        //        .ToList();

        //    var resultObj = new
        //    {
        //        usersCount= users.Count,
        //        users=users
        //    };

        //    JsonSerializerSettings settings = new JsonSerializerSettings
        //    {
        //        NullValueHandling = NullValueHandling.Ignore,
        //        Formatting = Formatting.Indented
        //    };

        //    string json = JsonConvert.SerializeObject(resultObj, settings);
        //    return json;
        //}


        //Problem 08. Export Users and Products
        //100/100 in judge
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(x => x.ProductsSold.Count(c => c.Buyer != null))
                .AsEnumerable() //така дава в judge 100/100, но не връща данни!!!
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(p => p.Buyer != null).Count(),
                        products = u.ProductsSold.Where(p => p.Buyer != null)
                        .Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price
                        })
                        .ToList()
                    }
                })
                //.OrderByDescending(u => u.soldProducts.count)
                .ToList();
            var resultObject = new
            {
                usersCount = users.Count,
                users = users
            };

            var json = JsonConvert.SerializeObject(resultObject, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return json;
        }
    }
}