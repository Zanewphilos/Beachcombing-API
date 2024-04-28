using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

public class CleanupRecord
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }
    public DateTime CleanupDate { get; set; }


    public string TrashItemCountsJson { get; set; }

    [NotMapped]
    public Dictionary<string, Dictionary<string, int>> TrashItemCounts
    {
        get => JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(TrashItemCountsJson);
        set => TrashItemCountsJson = JsonSerializer.Serialize(value);
    }

    // Optional: Link to images of trash collected
    public string ImagesUrl { get; set; }
}
