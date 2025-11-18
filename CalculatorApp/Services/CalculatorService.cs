namespace CalculatorApp.Services
{
    public class CalculatorService : ICalculatorService
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

        public double Subtract(double a, double b)
        {
            try
            {
                return a - b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public double Multiply(double a, double b)
        {
            try
            {
                return a * b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
