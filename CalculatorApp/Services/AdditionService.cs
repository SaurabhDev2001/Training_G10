namespace CalculatorApp.Services
{
    public class AdditionService : IAdditionService
    {
        public double Add(double a, double b)
        {
            try
            {
                return a + b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}