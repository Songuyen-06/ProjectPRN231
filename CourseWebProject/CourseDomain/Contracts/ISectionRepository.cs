﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDomain.Contracts
{
    public  interface ISectionRepository:IGenericRepository<Section>
    {
        public IQueryable<Section> GetListSectionByInclude();

        public Task<IEnumerable<Section>> GetListSectionByCourseId(int courdId);
    }
}