using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin khách hàng
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public class Customer
    {
        #region Fields
        /// <summary>
        /// Khóa chính
        /// </summary>
        [MISARequired]
        [MISADisplayName("Id khách hàng")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [MISARequired]
        [MISADisplayName("Mã khách hàng")]
        [MISAPrimaryKey]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        [MISARequired]
        [MISADisplayName("Tên khách hàng")]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        #endregion
    }
}
