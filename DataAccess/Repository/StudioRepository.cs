using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class StudioRepository: GenericRepository<Studio>, IStudioRepository
{
    private readonly TatooWebContext _context;
    public StudioRepository(TatooWebContext context) : base(context)
    {
        _context = context;     
    }

    public Studio Create(Studio studio)
    {
        _context.Set<Studio>().Add(studio);
        return studio;
    }

    public Studio Delete(Studio studio)
    {
        _context.Set<Studio>().Update(studio);
        return studio;
    }

    public Studio GetById(Guid id)
    {
        return _context.Set<Studio>().FirstOrDefault(c => c.Id == id);
    }

    public bool IsChange(Studio stu1, Studio stu2)
    {
        var studio1 = _context.Set<Studio>().Entry(stu1);
        var studio2 = _context.Set<Studio>().Entry(stu2);
        if (studio1 == studio2)
        {
            return false;
        }
        return true;
    }

    public bool IsEmailExist(string email)
    {
        var check = _context.Set<Studio>().FirstOrDefault(c => c.StudioEmail == email);
        if(check == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsNameExist(string name)
    {
        var check = _context.Set<Studio>().FirstOrDefault(c => c.Name == name);
        if (check == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsPhoneExist(string phone)
    {
        var check = _context.Set<Studio>().FirstOrDefault(c => c.StudioPhone == phone);
        if (check == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SaveChanges()
    {
        
        _context.SaveChanges();
    }

    public List<Studio> Search(string name)
    {
        if (name == null)
        {
            var studios = _context.Set<Studio>().ToList();
            return studios;
        }
        else
        {
            var studios = _context.Set<Studio>()
                .Where(s => s.Name.Contains(name))
                .ToList();
            return studios;
        }
    }

    Studio IStudioRepository.Update(Studio studio)
    {
        _context.Set<Studio>().Update(studio);
        return studio;
    }
}