using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin phòng ban
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public class Department
    {
        #region Fields
        /// <summary>
        /// Khóa chính
        /// </summary>
        [MISARequired]
        [MISADisplayName("Id phòng ban")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [MISARequired]
        [MISADisplayName("Mã phòng ban")]
        [MISAPrimaryKey]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [MISARequired]
        [MISADisplayName("Tên phòng ban")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}
