public class UploadService
{
    public string UploadPath { get; }

    private readonly IFormFile _file;

    public UploadService(IFormFile file)
    {
        _file = file;
        UploadPath = $"/Uploads/{file.FileName}";
    }
    public string CreateUploadsDirectory()
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        return uploadsFolder;

    }
    public async void CopyFileToServer(string uploadsFolder)
    {
        var filePath = Path.Combine(uploadsFolder, _file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await _file.CopyToAsync(stream);
        }        
    }

}