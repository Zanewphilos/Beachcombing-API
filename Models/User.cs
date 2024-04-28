using Microsoft.AspNetCore.Identity;
using System;
using Beachcombing_API.Models;

namespace Beachcombing_API.Models
{
    public class User : IdentityUser
    {

        public string ?SelfIntro { get; set; }

        public string AvatarUrl { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual ICollection<FavoritePlace> FavoritePlaces { get; set; } = new List<FavoritePlace>();
        public bool IsLocationShared { get; set; } // Whether the user has opted to share their location

        //public virtual ICollection<FavoriteBeach> FavoriteBeaches { get; set; }
    }
}
