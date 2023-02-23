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
        public readonly DataTable dataTable = new DataTable();
        
        // Top records
        
        //public void TopRecords(List<ProductReview> review)
        //{
        //    var recordData = (from productReviews in review orderby productReviews.Rating descending select productReviews).Take(3);
        //    Console.WriteLine("Top Records ");
        //    foreach (ProductReview product in recordData)
        //    {
        //        Console.WriteLine("ProductID : " + product.ProductID + " UserID : " + product.UserID + " Rating : " + product.Rating + " Review : " + product.Review + " IsLike : " + product.IsLike);
        //    }
        //}

        //public void SelectedRecords(List<ProductReview> review)
        //{
        //    var recordData = (from productReviews in review where productReviews.Rating > 3 && (productReviews.ProductID == 1 || productReviews.ProductID == 4 || productReviews.ProductID == 9) select productReviews);
        //    Console.WriteLine("Selected Records ");
        //    foreach (ProductReview product in recordData)
        //    {
        //        Console.WriteLine("ProductID : " + product.ProductID + " UserID : " + product.UserID + " Rating : " + product.Rating + " Review : " + product.Review + " IsLike : " + product.IsLike);
        //    }
        //}

        //public void CountOfReviewPresenForEachProductID(List<ProductReview> review)
        //{
        //    var recordData = (from productReviews in review group productReviews by productReviews.ProductID into product select new { ProductID = product.Key, Count = product.Count() });

        //    Console.WriteLine("Count Of Review Present For Each ProductID ");
        //    foreach (var product in recordData)
        //    {
        //        Console.WriteLine("Product Id : " + product.ProductID + "\tCount is : " + product.Count);
        //    }
        //    Console.WriteLine();
        //}

        public void RetriveOnlyProductIdAndReviewFromAllRecords(List<ProductReview> review)
        {
            var recordData = (from productReviews in review select (productReviews.ProductID, productReviews.Review));
            Console.WriteLine("ProductId And Review From All Records ");
            foreach (var product in recordData)
            {
                Console.WriteLine("ProductID : " + product.ProductID + " \tReview : " + product.Review);
            }
            Console.WriteLine();
        }
    }
}
