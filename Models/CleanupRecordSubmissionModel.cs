namespace Beachcombing_API.Models
{
    public class CleanupRecordSubmissionModel
    {
        public string TrashCounts { get; set; }
        public List<IFormFile> Images { get; set; } // 修改为支持多个文件
    }
}
