using EduCore.Domain;
using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.Contracts
{
    public interface ICheckoutRepository : IGenericRepository<StudentCheckout>
    {
        public IQueryable<StudentCheckout > GetListCheckoutByInclude();

    }
}
