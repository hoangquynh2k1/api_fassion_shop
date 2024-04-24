using Dropbox.Api;

namespace API_FashionShop.Services
{
    public class FileService
    {
        DropboxClient _client;
        public FileService(DropboxClient client)
        {
            _client = client;
        }
        public void Upload(string fileName, string content)
        {

        }
        public void Read(string fileName)
        {
            //_client.
        }
    }
}
