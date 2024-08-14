namespace RCloud.Contracts;

public record UploadDataRequest(IFormFile file, string path);