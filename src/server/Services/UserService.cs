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

    private readonly IWebHostEnvironment _env;
    public UserService(UserRepository userRepository, IWebHostEnvironment env)
    {
        _env = env;
        _jwtProvider = new JwtProvider();
        _passwordHasher = new PasswordHasher();
        _userRepository = userRepository;
    }
    public async Task Register(string username, string password, string email)
    {

        var findUser = await _userRepository.FindByUsernameAsync(username);
        if (findUser != null) throw new Exception("This user already exists");

        var hashPassword = _passwordHasher.Generate(password);
        var user = new User(username: username, hashPassword: hashPassword, email: email);
        await _userRepository.AddUserAsync(user);
    }

    public async Task<string?> Login(string username, string password)
    {
        
        var user = await _userRepository.FindByUsernameAsync(username);
        if (user == null) throw new Exception("This user does not exist");

        var resoult = _passwordHasher.Verify(password, user.HashPassword);
        if(resoult == false) throw new Exception("Incorrect password");

        var token = _jwtProvider.GenerateToken(user);

        return token;
    }
}
