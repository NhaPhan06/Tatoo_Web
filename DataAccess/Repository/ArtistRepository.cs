using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class ArtistRepository: GenericRepository<Artist>, IArtistRepository
{
    private readonly TatooWebContext _context;

    public ArtistRepository(TatooWebContext context) : base(context)
    {
        _context = context;
    }

    public List<Artist> SearchArtist(string name)
    {
        if (name == null)
        {
            var artists = _context.Set<Artist>().ToList();
            return artists;
        }
        else
        {
            var artists = _context.Set<Artist>()
                .Where(s => s.Name.Contains(name))
                .ToList();
            return artists;
        }
    }

    public Artist UpdateArtist(Artist artist)
    {
            _context.Set<Artist>().Update(artist);
            return artist;
    }
}