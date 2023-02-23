using LinqProblems;
namespace LinqProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Product Review Management System");

            List<ProductReview> list = ProductReviewManagement.AddProductsReview();
            ProductReviewManagement.DisplayeProductsReview(list);
            Console.ReadLine();

        }
    }
}
