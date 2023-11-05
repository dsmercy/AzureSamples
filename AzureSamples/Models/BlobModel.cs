using Azure.Storage.Blobs.Models;
using Azure;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace AzureSamples.Models
{
    
    public class BlobModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string DownloadLink { get; set; }
        public bool Deleted { get; set; }
        public Properties Properties { get; set; }
    }
    public class Properties
    {
        public DateTime LastModified { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
