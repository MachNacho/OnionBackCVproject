using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IExperienceRepository
    {
        List<Experience> GetAll();
        Task Add(Experience experience);
        Task Update(Experience experience);
        Experience Delete(int id);
    }
}
