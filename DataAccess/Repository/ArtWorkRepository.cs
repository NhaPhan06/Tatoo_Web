using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class ArtWorkRepository: GenericRepository<ArtWork>, IArtWorkRepository
{
    private readonly TatooWebContext _context;
    
    public ArtWorkRepository(TatooWebContext context) : base(context)
    {
        _context=context;
    }
    public ArtWork Create(ArtWork ArtWork)
    {
        _context.Set<ArtWork>().Add(ArtWork);
        return ArtWork;
    }
}