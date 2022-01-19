namespace Services
{
    public interface ILuhnCheckService
    {
        public bool Check(string cardNumber);

    }
}