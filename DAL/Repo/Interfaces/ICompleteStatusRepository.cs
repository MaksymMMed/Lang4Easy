﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Interfaces
{
    public interface ICompleteStatusRepository:IRepository<CompleteStatus>
    {
        public Task<CompleteStatus> GetComplete(int userId, int exerciseId);
    }
}
