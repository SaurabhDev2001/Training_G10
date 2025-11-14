namespace CalculatorApplication.Services
{
    public class CalculatorServices
    {
            public int Add(int a, int b)
            {
                try
                {
                    return checked(a + b);
            }
                catch (Exception ex)
                {
                throw new InvalidOperationException("Overflow occurred during addition.");
            }
            }
    }
}