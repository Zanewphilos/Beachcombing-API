using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace  Beachcombing_API.Services
{
    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "cleanup-images";
        public BlobService(IConfiguration configuration)
        {
            _blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorage"));
        }
        public async Task<string> UploadImageAsync(Stream imageStream, string imageName)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient(_containerName);
            await blobContainer.CreateIfNotExistsAsync(); // Ensure the container exists.
            var blobClient = blobContainer.GetBlobClient(imageName);
            await blobClient.UploadAsync(imageStream, overwrite: true);
            return blobClient.Uri.ToString();
        }
    }
}