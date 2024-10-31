using System;
using GroupRun.Models;

namespace GroupRun.Interfaces
{
	public interface IRaceRepository
	{
        Task<IEnumerable<Race>> GetAll();

        Task<Race> GetAllRacesByIdAsync(int id);

        Task<Race> GetAllRacesByIdAsyncNoTracking(int id);

        Task<IEnumerable<Race>> GetAllRacesByCity(string city);

        bool Add(Race race);

        bool Update(Race race);

        bool Delete(Race race);

        bool Save();
    }
}

