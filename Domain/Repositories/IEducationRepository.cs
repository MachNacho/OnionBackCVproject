using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEducationRepository
    {
        List<Education> GetAll();
        Task Add(Education education);
        Task Update(Education education);
        Education Delete(int id);
    }
}
