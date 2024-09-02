using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCloud.Contracts;

namespace RCloud.Services;

public class DataService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public DataService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _dataDirPath = _webHostEnvironment.WebRootPath;
    }
    
    private readonly string _dataDirPath;

    public void CreateDir(string path) =>
        Directory.CreateDirectory(_dataDirPath + @"\" + path);

    public async Task UploadData(IFormFile file, string path)
    {
        using (var fileStream = new FileStream(_dataDirPath + @"\" + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
    }

    public DirDataDto GetDirData(string path)
        {
            var absPath = _dataDirPath + @"\" + path;
            var files = Directory.GetFiles(absPath);
            files = files
                .Select(f => f.Replace(absPath, ""))
                .ToArray();
            var dirs = Directory.GetDirectories(absPath);
            dirs = dirs
                .Select(f => f.Replace(absPath, ""))
                .ToArray();
            var dirdata = new DirDataDto(dirs, files);
            return dirdata;
        }

    public FileInfo GetFile(string path)
    {
        var absPath = _dataDirPath + @"\" + path;
        var file = new FileInfo(absPath);
        return file;
    }
}