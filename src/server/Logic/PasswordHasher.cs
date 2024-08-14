namespace RCloud.Logic;

public class PasswordHasher
{
    public string Generate(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(text: password, hash: hashPassword);  

}