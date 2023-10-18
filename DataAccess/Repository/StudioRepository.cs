using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class StudioRepository: GenericRepository<Studio>, IStudioRepository
{
    public StudioRepository(TatooWebContext context) : base(context)
    {
    }
}