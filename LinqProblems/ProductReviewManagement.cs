using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProblems
{
    class ProductReviewManagement
    {
        public static List<ProductReview> AddProductsReview()
        {
            List<ProductReview> list = new List<ProductReview>()
            {
                new ProductReview(){ ProductID=1,UserID=34,Review="Good",IsLike=true,Rating=4.5 },
                new ProductReview(){ ProductID=4,UserID=23,Review="Bad",IsLike=false,Rating=1.5 },
                new ProductReview(){ ProductID=5,UserID=39,Review="Good",IsLike=true,Rating=3.5 },
                new ProductReview(){ ProductID=8,UserID=57,Review="Average",IsLike=true,Rating=3.5 },
                new ProductReview(){ ProductID=1,UserID=78,Review="Good",IsLike=true,Rating=3.5 },
                new ProductReview(){ ProductID=7,UserID=22,Review="Average",IsLike=true,Rating=3.0 },
                new ProductReview(){ ProductID=9,UserID=11,Review="Good",IsLike=true,Rating=3.9 },
                new ProductReview(){ ProductID=3,UserID=45,Review="Bad",IsLike=false,Rating=2.5 },
                new ProductReview(){ ProductID=6,UserID=89,Review="Good",IsLike=true,Rating=3.5 },
                new ProductReview(){ ProductID=2,UserID=24,Review="Good",IsLike=true,Rating=4.8 },
                new ProductReview(){ ProductID=7,UserID=10,Review="Bad",IsLike=false,Rating=2.0 }
            };

            return list;
        }
        public static void DisplayeProductsReview(List<ProductReview> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void Top3HighRatedProduct(List<ProductReview> list)
        {
            Console.WriteLine("Retrieving Top 3 products based on rating");
            //Query Syntax
            var sortedProduct = from product in list orderby product.Rating descending select product;
            var top3 = sortedProduct.Take(3).ToList();
            DisplayeProductsReview(top3);
        }
        public static void ProductsRatingGreaterThan3(List<ProductReview> list)
        {
            //Query Syntax
            Console.WriteLine("Retrieving products based on rating greater than 3 and having ProductID as 1/4/9");
            var res = list.Where(p => p.Rating > 3 && (p.ProductID == 1 || p.ProductID == 4 || p.ProductID == 9)).ToList();
            DisplayeProductsReview(res);


        }
        public static void CountofReviewForEachProductID(List<ProductReview> list)
        {
            Console.WriteLine("Count of products for each ProductID");
            //2 lamda Expressions
            var result = list.GroupBy(p => p.ProductID).Select(product => new { Id = product.Key, Count = product.Count() }).ToList();
            foreach (var item in result)
            {
                Console.WriteLine("ProductID: " + item.Id + " Count: " + item.Count);
            }
        }
        public static void RetrieveProductIDWithReview(List<ProductReview> list)
        {
            Console.WriteLine("Only Retrieving ProductID with Review");
            var result = list.Select(product => new { ProductID = product.ProductID, Review = product.Review }).ToList();
            foreach (var item in result)
            {
                Console.WriteLine("ProductID: " + item.ProductID + " Review: " + item.Review);
            }
        }
        public static void SkipTop5Records(List<ProductReview> list)
        {
            Console.WriteLine("Skipping top 5 records and displaying remaining records");
            var result = list.Skip(5).ToList();
            DisplayeProductsReview(result);
        }
        public static void RetrieveProductIDWithRating(List<ProductReview> list)
        {
            Console.WriteLine("Only Retrieving ProductID with Rating");
            var result = list.Select(product => new { ProductID = product.ProductID, Rating = product.Rating }).ToList();
            foreach (var item in result)
            {
                Console.WriteLine("ProductID: " + item.ProductID + " Rating: " + item.Rating);
            }
        }
        public static DataTable CreatingDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProductID", typeof(int));
            dataTable.Columns.Add("UserID", typeof(int));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("IsLike", typeof(bool));
            dataTable.Columns.Add("Rating", typeof(double));

            dataTable.Rows.Add(1, 34, "Good", true, 4.5);
            dataTable.Rows.Add(3, 57, "Good", true, 3.9);
            dataTable.Rows.Add(4, 56, "Average", true, 3.0);
            dataTable.Rows.Add(7, 22, "Bad", false, 2.0);
            dataTable.Rows.Add(8, 21, "Good", true, 4.7);
            dataTable.Rows.Add(3, 67, "Good", true, 4.3);
            dataTable.Rows.Add(2, 69, "Good", true, 4.4);
            dataTable.Rows.Add(9, 13, "Bad", false, 1.5);
            dataTable.Rows.Add(6, 81, "Average", true, 3.5);
            dataTable.Rows.Add(5, 29, "Good", true, 4.9);
            dataTable.Rows.Add(2, 30, "Bad", false, 2.0);
            return dataTable;
        }
        public static void DisplayDataTable(DataTable dataTable)
        {
            dataTable = CreatingDataTable();
            var resRows = from table in dataTable.AsEnumerable() select table;
            Console.WriteLine($"ProductId,  UserId,  Rating,  Review,  IsLike");
            foreach (var row in resRows)
            {
                Console.WriteLine($"{row["ProductId"]},  {row["UserId"]}, {row["Review"]},  {row["IsLike"]}, {row["Rating"]}");
            }
        }

        public static void RetriveRecordsWithIsLikeTrue(DataTable dataTable)
        {
            Console.WriteLine("Displaying reviews with IsLike value as True");
            var resRows = from table in dataTable.AsEnumerable() where table.Field<bool>("IsLike") == true select table;
            Console.WriteLine($"ProductId, UserId, Review, IsLike, Rating");
            foreach (var row in resRows)
            {
                Console.WriteLine($"{row["ProductId"]},  {row["UserId"]},  {row["Review"]},  {row["IsLike"]},  {row["Rating"]}");
            }
        }

        public static void FindAverageOfRating(DataTable dataTable)
        {
            var ratingAvg = from product in dataTable.AsEnumerable()
                            group product by product.Field<int>("ProductId")
                            into temp
                            select new { productid = temp.Key, average = Math.Round(temp.Average(x => x.Field<double>("Rating")), 2) };

            foreach (var row in ratingAvg)
            {
                Console.WriteLine("Product Id: {0} \tAverage Ratings: {1}", row.productid, row.average);
            }
        }

        public static void RecordsWithNiceReview(DataTable dataTable)
        {
            var niceReview = from product in dataTable.AsEnumerable() where product.Field<string>("Review").Contains("Nice") || product.Field<string>("Review").Contains("Good") select product;
            Console.WriteLine($"ProductId, UserId, Review, IsLike, Rating");
            foreach (var row in niceReview)
            {
                Console.WriteLine($"{row["ProductId"]},  {row["UserId"]},  {row["Review"]},  {row["IsLike"]},  {row["Rating"]}");
            }
        }
    }
}