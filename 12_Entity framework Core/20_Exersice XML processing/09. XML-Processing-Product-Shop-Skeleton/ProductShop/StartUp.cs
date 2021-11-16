namespace ProductShop
{
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using ProductShop.XMLHelper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            ////reset Database
            //context.Database.EnsureDeleted();
            //Console.WriteLine("Successfully delete DB");
            //context.Database.EnsureCreated();
            //Console.WriteLine("Successfully create DB");

            ////problem 1
            //var userXml1 = File.ReadAllText("../../../Datasets/users.xml");
            //var result1 = ImportUsers(context, userXml1);
            //Console.WriteLine(result1);

            ////problem 2
            //var userXml2 = File.ReadAllText("../../../Datasets/products.xml");
            //var result2 = ImportProducts(context, userXml2);
            //Console.WriteLine(result2);

            ////problem 3
            //var userXml3 = File.ReadAllText("../../../Datasets/categories.xml");
            //var result3 = ImportCategories(context, userXml3);
            //Console.WriteLine(result3);

            ////problem 4
            //var userXml4 = File.ReadAllText("../../../Datasets/categories-products.xml");
            //var result4 = ImportCategoryProducts(context, userXml4);
            //Console.WriteLine(result4);

            //problem 5
            var productInRange = GetProductsInRange(context);
            File.WriteAllText("../../../ExportResults/products-in-range.xml", productInRange);

            //problem 6
            var soldProducts= GetSoldProducts(context);
            File.WriteAllText("../../../ExportResults/users-sold-products.xml", soldProducts);

            //problem 7
            var categoryByProductCount = GetCategoriesByProductsCount(context);
            File.WriteAllText("../../../ExportResults/categories-by-products.xml", categoryByProductCount);
        }

        //problem 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";
            var userResults = XMLConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            List<User> users = new List<User>();

            foreach (var importUserDto in userResults)
            {
                var user = new User
                {
                    FirstName = importUserDto.FirstName,
                    LastName = importUserDto.LastName,
                    Age = importUserDto.Age
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //problem 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";
            var productResultDtos = XMLConverter.Deserializer<ImportProductDto>(inputXml, rootElement);


            ////with foreach
            //List<Product> products = new List<Product>();
            //
            //foreach (var importProductDto in productResultDtos)
            //{
            //    var product = new Product
            //    {
            //        Name = importProductDto.Name,
            //        Price = importProductDto.Price,
            //        SellerId = importProductDto.SellerId,
            //        BuyerId = importProductDto.BuyerId
            //    };

            //    products.Add(product);
            //}

            ////with object
            var products = productResultDtos
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerId = p.BuyerId,
                    SellerId = p.SellerId
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }

        //problem 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";
            var categoryResultDto = XMLConverter.Deserializer<ImportCategoryDto>(inputXml, rootElement);

            List<Category> categories = new List<Category>();

            foreach (var importCategoryDto in categoryResultDto)
            {
                if (importCategoryDto.Name == null)
                {
                    continue;
                }

                var category = new Category
                {
                    Name = importCategoryDto.Name
                };

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "CategoryProducts";

            var categryResultDto = XMLConverter.Deserializer<ImportCategotyProductsDto>(inputXml, rootElement);

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categryResultDto)
            {
                var doesExists = context.Products.Any(x => x.Id == categoryProductDto.ProductId) &&
                                 context.Categories.Any(x => x.Id == categoryProductDto.CategoryId);
                if (!doesExists)
                {
                    continue;
                }

                var categoryproduct = new CategoryProduct
                {
                    CategoryId = categoryProductDto.CategoryId,
                    ProductId = categoryProductDto.ProductId
                };

                categoryProducts.Add(categoryproduct);
            }

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductInfoDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            var result = XMLConverter.Serialize(products, rootElement);

            return result;
        }

        //problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var userWithProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new UserProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()

                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var result = XMLConverter.Serialize(userWithProducts, rootElement);

            return result;
        }

        //product 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categories = context.Categories
                .Select(c => new ExportCategotyDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Select(x => x.Product).Average(p => p.Price),
                    TotalRevenue = c.CategoryProducts.Select(x => x.Product).Sum(p => p.Price)
                })
                .OrderByDescending(c=>c.Count)
                .ThenBy(t=>t.TotalRevenue)
                .ToArray();

            var result = XMLConverter.Serialize(categories, rootElement);

            return result;
        }

        //problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            return null;
        }
    }
}