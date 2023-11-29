namespace AYweb.Core.Generators;

public class Generator
{
    public static string CreateUniqueText(int length)
    {
        return Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
    }
    public static string CreateVerificationCode()
    {
        Random rand = new Random();

        return rand.Next(100000, 999999).ToString();
    }
    public static string GenerateDefaultPassword()
    {
        Random random = new Random();
        string password = CreateUniqueText(3) + random.Next(100, 999) + CreateUniqueText(2) + random.Next(10, 99);
        return password;
    }
}
