using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông điệp trả về khi xử lý các nghiệp vụ
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public class ServiceResult
    {
        #region Fields
        /// <summary>
        /// Báo kết quả thành công hay không
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Thông điệp gửi đến người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Thông điệp cho dev
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Dữ liệu liên quan
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Mã kết quả
        /// </summary>
        public string MISACode { get; set; }
        #endregion

        #region Constructors
        public ServiceResult()
        {
            this.Success = true;
            this.UserMsg = string.Empty;
            this.DevMsg = string.Empty;
            this.Data = null;
            this.MISACode = string.Empty;
        }
        #endregion
    }
}
