using Dapper;
using MISA.Core.Interfaces.Infrastructure;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Tương tác với database
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public class DbContext<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity:class
    {
        #region Fields
        protected IDbConnection DbConnection;
        string _connectionString;
        string _className = typeof(MISAEntity).Name;
        #endregion

        #region Constructors
        public DbContext()
        {
            // Kết nối database
            // Khai báo thông tin kết nối
            _connectionString = "" +
                "Host=47.241.69.179;" +
                "Port=3306;" +
                "Database=MF887_LNNam_CukCuk;" +
                "User Id=dev;" +
                "Password=12345678";

            // Khởi tạo kết nối
            DbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>List đối tượng cần truy vấn</returns>
        /// Created By LNNam (31/07/2021)
        public List<MISAEntity> GetAll()
        {
            // Khai báo lệnh truy vấn
            var sqlCommand = $"SELECT * FROM {_className}";

            // Thực hiện truy vấn lất tất cả dữ liệu
            var entities = DbConnection.Query<MISAEntity>(sqlCommand).ToList();

            // Trả về list đối tượng
            return entities;
        }

        /// <summary>
        /// Lấy dữ liệu đối tượng theo Id
        /// </summary>
        /// <typeparam name="entityId">Id (Khóa chính)</typeparam>
        /// <returns>Đối tượng có Id cần truy vấn</returns>
        /// Created By LNNam (31/07/2021)
        public MISAEntity GetById(Guid entityId)
        {
            // Khai báo tham số cho lệnh truy vấn
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{_className}Id", entityId);

            // Khai báo lệnh truy vấn
            var sqlCommand = $"SELECT * FROM {_className} WHERE {_className}Id=@{_className}Id";

            // Thực hiện truy vấn lấy đối tượng theo Id
            var entity = DbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, parameters);

            // Trả về đối tượng
            return entity;
        }

        /// <summary>
        /// Lấy dữ liệu đối tượng theo Code
        /// </summary>
        /// <typeparam name="entityCode">Code của đối tượng cần tìm</typeparam>
        /// <returns>Đối tượng có Code cần truy vấn</returns>
        /// Created By LNNam (31/07/2021)
        public MISAEntity GetByCode(string entityCode)
        {
            // Khai báo tham số cho lệnh truy vấn
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{_className}Code", entityCode);

            // Khai báo lệnh truy vấn
            var sqlCommand = $"SELECT * FROM {_className} WHERE {_className}Code=@{_className}Code";

            // Thực hiện truy vấn lấy đối tượng theo Id
            var entity = DbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, parameters);

            // Trả về đối tượng
            return entity;
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns>Số bản ghi được thêm</returns>
        /// Created By LNNam (03/08/2021)
        public int Add(MISAEntity entity)
        {
            var className = entity.GetType().Name;
            var columnCommandText = string.Empty;
            var paramCommandText = string.Empty;

            DynamicParameters parameters = new DynamicParameters();

            var properties = entity.GetType().GetProperties();
             
            foreach(var prop in properties)
            {

                var propName = prop.Name;
                var propValue = prop.GetValue(entity);

                columnCommandText += propName + ',';
                paramCommandText += $"@{propName},";

                parameters.Add($"@{propName}", propValue);
            }

            columnCommandText = columnCommandText.Remove(columnCommandText.Count() - 1, 1);
            paramCommandText = paramCommandText.Remove(paramCommandText.Count() - 1, 1);

            var sqlCommand = $"INSERT INTO {className}({columnCommandText}) VALUES({paramCommandText})";

            var rowsEffect = DbConnection.Execute(sql: sqlCommand, param: parameters, commandType: CommandType.Text);

            return rowsEffect;
        }

        /// <summary>
        /// Sửa đổi bản ghi
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns>Số bản ghi bị sửa đổi</returns>
        /// Created By LNNam (03/08/2021)
        public int Update(MISAEntity Entity)
        {
            return 1;
        }

        /// <summary>
        /// Xóa đối tượng theo Id
        /// </summary>
        /// <typeparam name="entityId">Id (Khóa chính)</typeparam>
        /// <returns>Số bản ghi bị xóa</returns>
        /// Created By LNNam (31/07/2021)
        public int Delete(Guid entityId)
        {
            // Khai báo tham số cho lệnh truy vấn
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{_className}Id", entityId);

            // Khai báo lệnh truy vấn
            var sqlCommand = $"DELETE FROM {_className} WHERE {_className}Id=@{_className}Id";

            // Thực hiện truy vấn xóa đối tượng
            var res = DbConnection.Execute(sqlCommand, parameters);

            // Trả về số bản ghi bị xóa
            return res;
        }
        #endregion
    }
}
