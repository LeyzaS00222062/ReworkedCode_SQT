namespace TestingForAssignment
{
    // Define the DiscountService interface to resolve the missing reference issue.
    public interface DiscountService
    {
        double GetDiscount();
    }

    public class DefaultDiscountService : DiscountService
    {
        public double GetDiscount() => 0.9;
    }

    public class GameService
    {
        private readonly DefaultDiscountService _discountService;

        public GameService(DefaultDiscountService discountService)
        {
            _discountService = discountService;
        }

        public double CalcPremium(int age, string gameMode)
        {
            double premium = 0.0;

            if (gameMode == "casual")
            {
                if (age >= 18 && age <= 30)
                    premium = 5.0;
                else if (age >= 31)
                    premium = 2.5;
            }
            else if (gameMode == "hardcore")
            {
                if (age >= 18 && age <= 35)
                    premium = 6.0;
                else if (age >= 36)
                    premium = 5.0;
            }

            if (age >= 50)
            {
                premium *= _discountService.GetDiscount();
            }

            return premium;
        }
    }
}
