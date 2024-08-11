namespace RCloud.Contracts;

public record CreateUserRequest(string username, string password, string email);