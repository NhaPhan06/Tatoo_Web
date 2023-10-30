using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    internal class ArtWorkService : IArtWorkSevice
    {
        private IUnitOfWork _unitOfWork;
        public ArtWorkService(IUnitOfWork unitOfWork) 
        {
        _unitOfWork = unitOfWork;
        }

        public IEnumerable<ArtWork> GetArtWorks()
        {
           var list = _unitOfWork.ArtWork.GetAll();
            return list;
        }
    }
}
