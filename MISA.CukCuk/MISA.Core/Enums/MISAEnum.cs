using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Enums
{
    /// <summary>
    /// Giới tính
    /// Nữ = 0; Nam = 1; Khác = 2;
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public enum Gender
    {
        Female = 0,
        Male = 1,
        Other = 2,
    }

    /// <summary>
    /// Tình trạng công việc
    /// Đã nghỉ = 0; Đang làm = 1; Đang thực tập = 2, Khác = 3;
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public enum WorkStatus
    {
        NotWorking = 0,
        Working = 1,
        Intern = 2,
        Other = 3,
    }
}
