using System.Text;
using Microsoft.IdentityModel.Tokens;

public class AuthOptions
{
    public const string ISSUER = "RCloud";
    public const string AUDIENCE = "RCloudClient"; 
    const string KEY = "mysupersecret_secretsecretsecretkey!123";  
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}