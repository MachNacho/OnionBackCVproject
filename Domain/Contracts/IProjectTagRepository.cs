using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IProjectTagRepository
    {
        Task Add();
        Task Delete();
        Task Update();
    }
}
