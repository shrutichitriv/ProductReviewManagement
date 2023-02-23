using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProblems
{
    public class ProductReviewManagement
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
        public static void RetrieveProductIDWithRating(List<ProductReview> list)
        {
            Console.WriteLine("Only Retrieving ProductID with Rating");
            var result = list.Select(product => new { ProductID = product.ProductID, Rating = product.Rating }).ToList();
            foreach (var item in result)
            {
                Console.WriteLine("ProductID: " + item.ProductID + " Rating: " + item.Rating);
            }
        }
    }
}
