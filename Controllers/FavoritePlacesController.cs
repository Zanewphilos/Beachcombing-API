using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Beachcombing_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Beachcombing_API.Data;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Beachcombing_API.Models.Dto.Favorite;

namespace Beachcombing_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FavoritePlacesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavoritePlacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoritePlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoritePlace>>> GetFavoritePlaces()
        {
            // Assume UserID is part of each FavoritePlace
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _context.FavoritePlaces
                                 .Where(fp => fp.UserId == userId)
                                 .ToListAsync();
        }

        // POST: api/FavoritePlaces
        [HttpPost]
        public async Task<ActionResult<FavoritePlace>> PostFavoritePlace(FavoritePlaceDTO dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favoritePlace = new FavoritePlace
            {
                UserId = userId,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                FullAddress = dto.FullAddress,
                Country = dto.Country,
                State = dto.State,
                District = dto.District,
                TideData = dto.TideData,
                Date = dto.Date,
                Note = dto.Note
            };

            _context.FavoritePlaces.Add(favoritePlace);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Create success" });
        }

        // GET: api/FavoritePlaces/5


        // PUT: api/FavoritePlaces/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFavoritePlace(int id, FavoritePlaceUpdateDto updateDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // 获取要更新的实体
            var favoritePlace = await _context.FavoritePlaces
                .FirstOrDefaultAsync(fp => fp.Id == id && fp.UserId == userId);

            if (favoritePlace == null)
            {
                return NotFound();
            }

            // 更新 note
            favoritePlace.Note = updateDto.Note;

            // 标记 note 为已修改
            _context.Entry(favoritePlace).Property(fp => fp.Note).IsModified = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritePlaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Update note success" });
        }

        // DELETE: api/FavoritePlaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoritePlace(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favoritePlace = await _context.FavoritePlaces.FirstOrDefaultAsync(fp => fp.Id == id && fp.UserId == userId);

            if (favoritePlace == null)
            {
                return NotFound();
            }

            _context.FavoritePlaces.Remove(favoritePlace);
            await _context.SaveChangesAsync();

            return Ok(new { message = "delete success." });
        }

        private bool FavoritePlaceExists(int id)
        {
            return _context.FavoritePlaces.Any(e => e.Id == id);
        }
    }
}