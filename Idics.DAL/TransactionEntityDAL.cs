using Idics.MOD;
using Idics.ULT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idics.DAL
{
    public class TransactionEntityDAL
    {
        // Danh sách giao dịch 
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<TransactionEntityMOD> danhSachGiaoDich = new List<TransactionEntityMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("Keyword",SqlDbType.NVarChar,200),
                new SqlParameter("OrderByName",SqlDbType.NVarChar,50),
                new SqlParameter("OrderByOption",SqlDbType.NVarChar,50),
                new SqlParameter("pLimit",SqlDbType.Int),
                new SqlParameter("pOffset",SqlDbType.Int),
                new SqlParameter("TotalRow",SqlDbType.Int),
                new SqlParameter("TrangThai",SqlDbType.TinyInt),
                new SqlParameter("VaiTro",SqlDbType.TinyInt),

            };
            parameters[0].Value = p.Keyword != null ? p.Keyword : "";
            parameters[1].Value = p.OrderByName;
            parameters[2].Value = p.OrderByOption;
            parameters[3].Value = p.Limit;
            parameters[4].Value = p.Offset;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[5].Size = 8;
            parameters[6].Value = p.TrangThai ?? Convert.DBNull;
            parameters[7].Value = p.VaiTro;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "TransactionEntity_DanhSach", parameters))
                {
                    while (dr.Read())
                    {
                        TransactionEntityMOD item = new TransactionEntityMOD();
                        item.id_giaodich = Utils.ConvertToInt32(dr["id_giaodich"], 0);
                        item.id_user = Utils.ConvertToInt32(dr["id_user"], 0);
                        item.FullName = Utils.ConvertToString(dr["FullName"], string.Empty);
                        item.Device = Utils.ConvertToString(dr["Device"], string.Empty);
                        item.Location = Utils.ConvertToString(dr["Location"], string.Empty);
                        item.Time = Utils.ConvertToString(dr["Time"], string.Empty);
                        danhSachGiaoDich.Add(item);
                       Console.WriteLine(dr.ToString());
                    }
                    dr.Close();
                }
                TotalRow = Utils.ConvertToInt32(parameters[5].Value, 0);
                Result.Status = 1;
                Result.Data = danhSachGiaoDich;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
            }
            return Result;
        }

        // thêm mới dữ liệu
        public BaseResultMOD ThemMoi(ADDTransactionEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id_user", SqlDbType.Int),
                    new SqlParameter("@Device", SqlDbType.NVarChar),
                    new SqlParameter("@Location", SqlDbType.NVarChar),
                    new SqlParameter("@Time", SqlDbType.Date)
                };
                parameters[0].Value = item.id_user;
                parameters[1].Value = item.Device;
                parameters[2].Value = item.Location;
                parameters[3].Value = item.Time;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "TransactionEntity_ThemMoi", parameters);
                            trans.Commit();
                            Result.Message = "Thêm mới thành công!";
                            Result.Data = Result.Status;
                        }
                        catch (Exception ex)
                        {
                            Result.Status = -1;
                            Result.Message = Constant.ERR_INSERT;
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }

        // tìm kiếm theo ngày 
        public BaseResultMOD Search(string Time1, string Time2)
        {
            var Result = new BaseResultMOD();
            try
            {
                List<TransactionEntityMOD> listUser = new List<TransactionEntityMOD>();
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Time1", SqlDbType.Date),
                    new SqlParameter("@Time2", SqlDbType.Date)
                };
                parameters[0].Value = Time1;
                parameters[1].Value = Time2;
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "TransactionEntity_TimKiem", parameters))
                            {
                                while (dr.Read())
                                {
                                    TransactionEntityMOD item = new TransactionEntityMOD();
                                    item.id_giaodich = Utils.ConvertToInt32(dr["id_giaodich"], 0);
                                    item.id_user = Utils.ConvertToInt32(dr["id_user"], 0);
                                    item.FullName = Utils.ConvertToString(dr["FullName"], string.Empty);
                                    item.Device = Utils.ConvertToString(dr["Device"], string.Empty);
                                    item.Location = Utils.ConvertToString(dr["Location"], string.Empty);
                                    item.Time = Utils.ConvertToString(dr["Time"], string.Empty);
                                    listUser.Add(item);
                                }
                                dr.Close();
                            }
                            Result.Status = 1;
                            //Result.Message = "Tìm kiếm thành công!";
                            Result.Data = listUser;
                        }
                        catch (Exception ex)
                        {
                            Result.Status = -1;
                            Result.Message = Constant.ERR_INSERT;
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }

        // Xóa thông tin
        public BaseResultMOD Xoa(int id_giaodich)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("id_giaodich", SqlDbType.Int)
            };
            parameters[0].Value = id_giaodich;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var val = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "TransactionEntity_Xoa", parameters);
                        trans.Commit();
                        if (val < 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Xóa người dùng không thành công!";
                            return Result;
                        }
                    }
                    catch
                    {
                        Result.Status = -1;
                        Result.Message = Constant.ERR_DELETE;
                        trans.Rollback();
                        return Result;
                        throw;
                    }
                }
            }
            Result.Status = 1;
            Result.Message = "Xóa người dùng thành công!";
            return Result;
        }
    }
}
