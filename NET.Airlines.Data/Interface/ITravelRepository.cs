using NET.Airlines.Entity;
using System.Collections.Generic;

namespace NET.Airlines.Data.Interface
{
    public interface ITravelRepository : IRepository<Travel>
    {
        IEnumerable<DTO.Travel> GetAllTravels(Travel entity = null);

        IEnumerable<DTO.Airport> GetAllSources();

        IEnumerable<DTO.Airport> GetAllDestinies();
    }
}
