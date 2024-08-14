using System.Text;
using Microsoft.IdentityModel.Tokens;

public class AuthOptions
{
    public const string ISSUER = "http://localhost:5017";
    public const string AUDIENCE = "http://localhost:5173/"; 
    const string KEY = "mysupersecret_secretsecretsecretkey!123";  
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}