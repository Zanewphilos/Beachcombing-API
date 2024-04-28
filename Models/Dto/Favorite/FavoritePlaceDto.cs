namespace Beachcombing_API.Models.Dto.Favorite
{
    public class FavoritePlaceDTO
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FullAddress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string TideData { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }
    }
}
