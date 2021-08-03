using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Infrastructure
{
    /// <summary>
    /// Interface giao tiếp với table Department
    /// </summary>
    /// Created By LNNam (01/08/2021)
    public interface IDepartmentContext : IBaseRepository<Department>
    {
    }
}
