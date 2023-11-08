﻿using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IArtistService
{
    List<Artist> SearchArtist(string name);
    Artist GetArtistById(Guid id);
    Artist UdpateArtist(Guid id, Artist artist);
    Artist CreateArtist(Artist artist);
}