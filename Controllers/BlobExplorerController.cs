using System.Threading.Tasks;
using Azure.Models;
using Azure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorageExample.Controllers
{
    [Route("blobs")]
    public class BlobExplorerController : Controller
    {
        private readonly IBlobService _blobService;
        
        public BlobExplorerController(IBlobService blobService)
        {
            _blobService = blobService;
        }
        
        [HttpGet("{blobName}")]
        public async Task<IActionResult> GetBlob(string blobName)
        {
            var data = await _blobService.GetFiles(blobName);
            return File(data.Content, data.ContentType);
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListBlobs()
        {
            return Ok(await _blobService.ListBlobsAsync());
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFile([FromBody]UploadFile request)
        {
            await _blobService.UploadFile(request.FilePath, request.FileName);
            return Ok();
        }
        
        [HttpPost("uploadcontent")]
        public async Task<IActionResult> UploadContent([FromBody] UploadContent request)
        {
            await _blobService.UploadContent(request.Content, request.FileName);
            return Ok();
        }

        [HttpDelete("{blobName}")]
        public async Task<IActionResult> DeleteFile(string blobName)
        {
            await _blobService.DeleteFile(blobName);
            return Ok();
        }
    }
}