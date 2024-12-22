using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.Contracts
{
    public  interface ISectionRepository:IGenericRepository<Section>
    {
        public IQueryable<Section> GetListSectionByInclude();

        public Task<IEnumerable<Section>> GetListSectionByCourseId(int courdId);
    }
}
