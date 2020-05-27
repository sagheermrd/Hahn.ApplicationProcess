using System;
using Hahn.ApplicatonProcess.May2020.Data.Context;

namespace Hahn.ApplicatonProcess.May2020.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationProcessContext _context;
        public BaseRepository(ApplicationProcessContext _context)
        {
            this._context = _context;
        }
    }
}
