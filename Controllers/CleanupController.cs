using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beachcombing_API.Models;
using Beachcombing_API.Data;
using Beachcombing_API.Services;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Beachcombing_API.Controllers
{
    [Route("api/[controller]")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CleanupRecordsController : ControllerBase
    {
        private readonly BlobService _blobService;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        // 构造函数，用于依赖注入
        public CleanupRecordsController(BlobService blobService, ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _blobService = blobService;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        // 用于提交清理记录的方法
        [HttpPost]
        public async Task<IActionResult> SubmitCleanupRecord([FromForm] CleanupRecordSubmissionModel model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var trashCounts = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(model.TrashCounts);
            List<string> imageUrls = new List<string>();

            foreach (var image in model.Images)
            {
                var uniqueImageName = $"{System.Guid.NewGuid()}_{image.FileName}";
                var imageUrl = await _blobService.UploadImageAsync(image.OpenReadStream(), uniqueImageName);
                imageUrls.Add(imageUrl);
            }

            var cleanupRecord = new CleanupRecord
            {
                UserId = user.Id,
                CleanupDate = System.DateTime.UtcNow,
                TrashItemCounts = trashCounts,
                ImagesUrl = string.Join(";", imageUrls)
            };

            await _dbContext.CleanupRecords.AddAsync(cleanupRecord);
            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Cleanup record submitted successfully." });
        }
    }
}