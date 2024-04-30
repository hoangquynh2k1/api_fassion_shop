using Dropbox.Api;

namespace API_FashionShop.Services
{
    public class FileService
    {
        public FileService()
        {
        }
        public async Task<string> Upload(IFormFile file, string f)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", f, file.FileName);
            using (var stream = System.IO.File.Create(path))
            {
                await file.CopyToAsync(stream);
            }
            return "Images/"+f+"/"+file.FileName;
        }
        public byte[] Read(string path)
        {
            var stream = System.IO.File.ReadAllBytes(path);
            return stream;
        }
    }
}
