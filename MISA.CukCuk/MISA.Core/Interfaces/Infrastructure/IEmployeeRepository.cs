using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Infrastructure
{
    /// <summary>
    /// Interface giao tiếp với table Employee
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
    }
}
