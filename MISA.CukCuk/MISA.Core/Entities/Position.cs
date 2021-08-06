using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin vị trí
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public class Position
    {
        #region Fields
        /// <summary>
        /// Khóa chính
        /// </summary>
        [MISARequired]
        [MISADisplayName("Id vị trí")]
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        [MISARequired]
        [MISADisplayName("Mã vị trí")]
        [MISAPrimaryKey]
        public string PositionCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [MISARequired]
        [MISADisplayName("Tên vị trí")]
        public string PositionName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}
