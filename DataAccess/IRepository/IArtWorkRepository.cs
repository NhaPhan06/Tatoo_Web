using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface IArtWorkRepository : IGenericRepository<ArtWork>
{
    ArtWork Create(ArtWork ArtWork);
}