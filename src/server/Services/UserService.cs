namespace RCloud.Services;

using RCloud.DataAccess.Repositories;
using RCloud.Models;
using RCloud.Logic;
using RCloud.Providers;

public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly PasswordHasher _passwordHasher;
    private readonly JwtProvider _jwtProvider;
    public UserService(UserRepository userRepository)
    {
        _jwtProvider = new JwtProvider();
        _passwordHasher = new PasswordHasher();
        _userRepository = userRepository;
    }
    public async Task Register(string username, string password, string email)
    {
        var hashPassword = _passwordHasher.Generate(password);
        var user = new User(username: username, hashPassword: hashPassword, email: email);
        await _userRepository.AddUserAsync(user);
    }

    public async Task<string?> Login(string username, string password)
    {
        var user = await _userRepository.FindByUsernameAsync(username);
        if (user == null) return null;

        var resoult = _passwordHasher.Verify(password, user.HashPassword);
        if(resoult == false) return null;

        var token = _jwtProvider.GenerateToken(user);

        return token;
    }
}
