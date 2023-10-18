using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class ArtistRepository: GenericRepository<Artist>, IArtistRepository
{
    public ArtistRepository(TatooWebContext context) : base(context)
    {
    }
}