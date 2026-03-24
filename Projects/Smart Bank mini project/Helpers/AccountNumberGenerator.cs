namespace SmartBankMiniProject.Helpers
{
    public class AccountNumberGenerator
    {
        public static string Generate(int id)
        {
            return $"SB-{DateTime.Now.Year}-{id.ToString().PadLeft(6, '0')}";
        }
    }
}
