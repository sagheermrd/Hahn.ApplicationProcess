using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.IRepository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
