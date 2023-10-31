﻿using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface IStudioRepository : IGenericRepository<Studio>
{
    List<Studio> Search(String name);
    Studio GetById(Guid id);
    Studio Update (Studio studio);
    Studio Delete(Studio studio);
    Studio Create(Studio studio);
    void SaveChanges();
    Boolean IsEmailExist(string email);
    Boolean IsNameExist(string name);
    Boolean IsPhoneExist(string phone);
    Boolean IsChange(Studio stu1, Studio stu2);
}