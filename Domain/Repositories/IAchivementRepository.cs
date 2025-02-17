using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAchivementRepository
    {
        List<Achivement> GetAll();
        Task Add(Achivement achivement);
        Task Update(Achivement achivement);
        Achivement Delete(int id);
    }
}
