using LinqProblems;
namespace LinqProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product review management problem statement");

            try
            {
                Console.WriteLine("Welcome To Product Review Management System\n");
                List<ProductReview> list = ProductReviewManagement.AddProductsReview();
                Console.WriteLine("Choose Option or press 0 for exit\n1:Only Retrieving ProductID with Rating");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        ProductReviewManagement.RetrieveProductIDWithRating(list);
                        break;
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
