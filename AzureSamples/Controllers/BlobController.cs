using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AzureSamples.Controllers
{
    [Route("blob")]
    public class BlobController : Controller
    {
        private readonly IConfiguration _configuration;

        public BlobController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: BlobController
        [HttpGet("list")]
        public ActionResult ListBlobs()
        {
            var containerClient = new BlobContainerClient(_configuration.GetValue<string>("Azure:ConnectionString"), _configuration.GetValue<string>("Azure:Container"));
            var blobs = JsonConvert.DeserializeObject<List<BlobModel>>(JsonConvert.SerializeObject(containerClient.GetBlobs()));
            return View(blobs);
        }

        [HttpGet("upload")]
        public ActionResult upload()
        {
            return View();
        }

        // POST: BlobController/Create
        [HttpPost("upload")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Upload(IFormFile postedFile)
        {

            try
            {
                var containerClient = new BlobContainerClient(_configuration.GetValue<string>("Azure:ConnectionString"), _configuration.GetValue<string>("Azure:Container"));

                var filePath = Path.Combine(Path.GetTempPath(), postedFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                string newFileName = DateTimeOffset.Now.ToUnixTimeSeconds() + "_" + Path.GetFileName(postedFile.FileName);
                var blobClient = containerClient.GetBlobClient(@"/import/" + newFileName);
                var uploadFileStream = System.IO.File.OpenRead(filePath);
                await blobClient.UploadAsync(uploadFileStream);
                uploadFileStream.Close();

                return RedirectToAction("list");
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("download")]
        public async Task<ActionResult> Download(string fileName)
        {
            try
            {
                // Get a reference to the container
                var containerClient = new BlobContainerClient(_configuration.GetValue<string>("Azure:ConnectionString"), _configuration.GetValue<string>("Azure:Container"));
                
                // Get a reference to the blob
                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                // Check if the blob exists
                if (await blobClient.ExistsAsync())
                {
                    BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync();

                    Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
                    return File(blobDownloadInfo.Content, blobDownloadInfo.ContentType);
                }

                return View();
            }
            catch(Exception ex)
            {
                throw;
            }
        }


    }
}
