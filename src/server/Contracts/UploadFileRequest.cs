namespace RCloud.Contracts;

public record UploadFileRequest(IFormFile file, string path);