namespace Services
{
    public class LuhnCheckService : ILuhnCheckService

    {
        public bool LuhnCheck(string cardNumber)
        {
            return LuhnCheck(cardNumber.Select(c => c - '0').ToArray());
        }

        private bool LuhnCheck(int[] digits)
        {
            return GetCheckValue(digits) == 0;
        }

        private int GetCheckValue(int[] digits)
        {
            return digits.Select((d, i) => i % 2 == digits.Length % 2 ? ((2 * d) % 10) + d / 5 : d).Sum() % 10;
        }
    }
}