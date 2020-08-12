using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Models;

namespace Azure.Services
{
    public interface IBlobService
    {
        public Task<BlobInfo> GetFiles(string name);

        public Task<IEnumerable<string>> ListBlobsAsync();

        public Task UploadFile(string filePath, string fileName);
        
        public Task UploadContent(string content, string fileName);

        public Task DeleteFile(string blobName);
    }
}