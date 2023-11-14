namespace AYweb.Core.Generators;

public class Generator
{
    public static string CreateUniqueText()
    {
        return Guid.NewGuid().ToString().Replace("-", "");
    }
    public static string CreateVerificationCode()
    {
        Random rand = new Random();

        return rand.Next(100000, 999999).ToString();
    }
    public static string GenerateDefaultPassword()
    {
        Random random = new Random();
        string password = CreateUniqueText().Substring(2, 3) + random.Next(100, 999) + CreateUniqueText().Substring(2, 2) + random.Next(10, 99);
        return password;
    }
}
