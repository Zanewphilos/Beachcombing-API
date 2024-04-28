using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beachcombing_API.Models
{
    public class FavoritePlace
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FullAddress { get; set; }
        public string Country { get; set; }
        public string State { get; set; } // 新增状态/省份字段
        public string District { get; set; }
        public string TideData { get; set; } // 存储序列化的 TideResponse 对象

        public string Date { get; set; } 
        public string Note { get; set; } // 用户自定义笔记
    }
}