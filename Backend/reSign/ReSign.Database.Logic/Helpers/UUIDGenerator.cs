namespace ReSign.Database.Logic.Helpers
{
    public static class UUIDGenerator
    {
        public static string GenerateQRToken()
        {
            Guid g = Guid.NewGuid();
            string str = g.ToString();
            string[] result = str.Split("-");

            if (result == null)
                throw new Exception("An error occured while generating a new QRToken.");

            return result[0];
        }

        public static string GenerateUserToken()
        {
            Guid g = Guid.NewGuid();
            return g.ToString();
        }
    }
}
