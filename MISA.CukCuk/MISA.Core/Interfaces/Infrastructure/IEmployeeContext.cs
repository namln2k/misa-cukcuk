using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Infrastructure
{
    /// <summary>
    /// Interface giao tiếp với Database Employee
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public interface IEmployeeContext
    {
        // Thêm mới thông tin nhân viên
        public int Add(Employee employee);

        // Sửa đổi thông tin nhân viên
        public int Update(Employee employee);
    }
}
