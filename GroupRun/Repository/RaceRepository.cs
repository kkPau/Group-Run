using System;
using GroupRun.Interfaces;
using GroupRun.Data;
using GroupRun.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupRun.Repository
{
	public class RaceRepository : IRaceRepository
	{
        private readonly ApplicationDBContext _context;

        public RaceRepository(ApplicationDBContext context)
		{
			_context = context;
		}

        public bool Add(Race race)
        {
            _context.Add(race);
            return Save();
        }

        public bool Update(Race race)
        {
            _context.Update(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _context.Remove(race);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race> GetAllRacesByIdAsync(int id)
        {
            return await _context.Races.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Race> GetAllRacesByIdAsyncNoTracking(int id)
        {
            return await _context.Races.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
        {
            return await _context.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }
    }
}

