using Idics.MOD;
using Idics.ULT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Idics.DAL
{
    public class UserEntityDAL
    {
        // lấy danh sách người dùng
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<UserEntityMOD> DanhSanhUserEntity = new List<UserEntityMOD>();
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
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "UserEntity_DanhSach", parameters))
                {
                    while (dr.Read())
                    {
                        UserEntityMOD item = new UserEntityMOD();
                        item.Id_user = Utils.ConvertToInt32(dr["Id_user"], 0);
                        item.Password = Utils.ConvertToString(dr["Password"], string.Empty);
                        item.Sex = Utils.ConvertToString(dr["Sex"], string.Empty);
                        item.Nation = Utils.ConvertToString(dr["Nation"], string.Empty);
                        item.Mobile = Utils.ConvertToString(dr["Mobile"], string.Empty);
                        item.IdCart = Utils.ConvertToString(dr["IdCart"], string.Empty);
                        item.AgencyID = Utils.ConvertToInt32(dr["AgencyID"], 0);
                        item.AgencyID = Utils.ConvertToInt32(dr["AgencyID"], 0);
                        item.TypeInfo = Utils.ConvertToInt32(dr["TypeInfo"], 0);
                        item.Birthday = Utils.ConvertToString(dr["Birthday"],string.Empty);
                        item.Fullname = Utils.ConvertToString(dr["Fullname"], string.Empty);
                        item.MemberCardNo = Utils.ConvertToString(dr["MemberCardNo"], string.Empty);
                        item.Email = Utils.ConvertToString(dr["Email"], string.Empty);
                        item.HeadImg = Utils.ConvertToString(dr["HeadImg"], string.Empty);
                        item.Source = Utils.ConvertToInt32(dr["Source"], 0);
                        DanhSanhUserEntity.Add(item);
                    }
                    dr.Close();
                }
                TotalRow = Utils.ConvertToInt32(parameters[5].Value, 0);
                Result.Status = 1;
                Result.Data = DanhSanhUserEntity;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                throw;
            }
            return Result;
        }

        // Lấy thông tin chi tiết
        public UpdateUserEntityMOD ChiTiet(int Id_user)
        {
            UpdateUserEntityMOD item = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id_user", SqlDbType.Int)
            };
            parameters[0].Value = Id_user;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "UserEntity_ChiTiet", parameters))
                {
                    while (dr.Read())
                    {
                        item = new UpdateUserEntityMOD();
                        item.Id_user = Utils.ConvertToInt32(dr["Id_user"], 0);
                        item.Sex = Utils.ConvertToString(dr["Sex"], string.Empty);
                        item.Nation = Utils.ConvertToString(dr["Nation"], string.Empty);
                        item.Mobile = Utils.ConvertToString(dr["Mobile"], string.Empty);
                        item.IdCart = Utils.ConvertToString(dr["IdCart"], string.Empty);
                        item.AgencyID = Utils.ConvertToInt32(dr["AgencyID"], 0);
                        item.AgencyID = Utils.ConvertToInt32(dr["AgencyID"], 0);
                        item.TypeInfo = Utils.ConvertToInt32(dr["TypeInfo"], 0);
                        item.Birthday = Utils.ConvertToString(dr["Birthday"], string.Empty);
                        item.Fullname = Utils.ConvertToString(dr["Fullname"], string.Empty);
                        item.MemberCardNo = Utils.ConvertToString(dr["MemberCardNo"], string.Empty);
                        item.Email = Utils.ConvertToString(dr["Email"], string.Empty);
                        item.HeadImg = Utils.ConvertToString(dr["HeadImg"], string.Empty);
                        item.Source = Utils.ConvertToInt32(dr["Source"], 0);
                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return item;
        }

        // Thêm mới dữ liệu
        public BaseResultMOD ThemMoi(AddUserEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Password", SqlDbType.NVarChar),
                    new SqlParameter("@Sex", SqlDbType.NVarChar),
                    new SqlParameter("@Nation", SqlDbType.NVarChar),
                    new SqlParameter("@Mobile", SqlDbType.NVarChar),
                    new SqlParameter("@IdCart", SqlDbType.NVarChar),
                    new SqlParameter("@AgencyID", SqlDbType.Int),
                    new SqlParameter("@TypeInfo", SqlDbType.Int),
                    new SqlParameter("@Birthday", SqlDbType.Date),
                    new SqlParameter("@FullName", SqlDbType.NVarChar),
                    new SqlParameter("@MemberCardNo", SqlDbType.NVarChar),
                    new SqlParameter("@Email", SqlDbType.NVarChar),
                    new SqlParameter("@HeadImg", SqlDbType.NVarChar),
                    new SqlParameter("@Source", SqlDbType.Int),
                };
                parameters[0].Value = item.Password;
                parameters[1].Value = item.Sex;
                parameters[2].Value = item.Nation;
                parameters[3].Value = item.Mobile;
                parameters[4].Value = item.IdCart;
                parameters[5].Value = item.AgencyID;
                parameters[6].Value = item.TypeInfo;
                parameters[7].Value = item.Birthday;
                parameters[8].Value = item.Fullname;
                parameters[9].Value = item.MemberCardNo;
                parameters[10].Value = item.Email;
                parameters[11].Value = item.HeadImg;
                parameters[12].Value = item.Source;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UserEntity_ThemMoi", parameters);
                            trans.Commit();
                            Result.Message = "Thêm mới thành công!";
                            Result.Data = ChiTiet(Result.Status);
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

        // update dữ liệu 
        public BaseResultMOD CapNhap(UpdateUserEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id_user", SqlDbType.Int),
                    new SqlParameter("@Sex", SqlDbType.NVarChar),
                    new SqlParameter("@Nation", SqlDbType.NVarChar),
                    new SqlParameter("@Mobile", SqlDbType.NVarChar),
                    new SqlParameter("@IdCart", SqlDbType.NVarChar),
                    new SqlParameter("@AgencyID", SqlDbType.Int),
                    new SqlParameter("@TypeInfo", SqlDbType.Int),
                    new SqlParameter("@Birthday", SqlDbType.Date),
                    new SqlParameter("@FullName", SqlDbType.NVarChar),
                    new SqlParameter("@MemBerCardNo", SqlDbType.NVarChar),
                    new SqlParameter("@Email", SqlDbType.NVarChar),
                    new SqlParameter("@HeadImg", SqlDbType.NVarChar),
                    new SqlParameter("@Source", SqlDbType.Int),
                    //new SqlParameter("@Password", SqlDbType.NVarChar),
                    new SqlParameter("@id_GroupUser", SqlDbType.Int),
                };
                parameters[0].Value = item.Id_user;
                parameters[1].Value = item.Sex;
                parameters[2].Value = item.Nation;
                parameters[3].Value = item.Mobile;
                parameters[4].Value = item.IdCart;
                parameters[5].Value = item.AgencyID;
                parameters[6].Value = item.TypeInfo;
                parameters[7].Value = item.Birthday;
                parameters[8].Value = item.Fullname;
                parameters[9].Value = item.MemberCardNo;
                parameters[10].Value = item.Email;
                parameters[11].Value = item.HeadImg;
                parameters[12].Value = item.Source;
               // parameters[13].Value = item.Password;
                parameters[13].Value = item.id_GroupUser;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UserEntity_CapNhap", parameters);
                            trans.Commit();
                            Result.Message = "Cập nhật thông tin người dùng thành công!";
                            Result.Data = ChiTiet(item.Id_user);
                        }
                        catch (Exception)
                        {
                            Result.Status = -1;
                            Result.Message = Constant.ERR_UPDATE;
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_UPDATE;
                throw;
            }
            return Result;
        }
        
        // xóa người dùng
        public BaseResultMOD Xoa(int Id_user)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("Id_user", SqlDbType.Int)
            };
            parameters[0].Value = Id_user;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var val = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "UserEntity_Xoa", parameters);
                        trans.Commit();
                        if (val < 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Không thể xóa người dùng!";
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

        // Tìm kiếm người dùng
        public BaseResultMOD Search(string Email)
        {
            var Result = new BaseResultMOD();
            try
            {
                List<ListUserMOD> listUser = new List<ListUserMOD>();
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email", SqlDbType.NVarChar)
                };
                parameters[0].Value = Email;
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "UserEntity_TimKiem", parameters))
                            {
                                while (dr.Read())
                                {
                                    ListUserMOD item = new ListUserMOD();
                                    item.Id_user = Utils.ConvertToInt32(dr["Id_user"], 0);
                                    item.Email = Utils.ConvertToString(dr["Email"], string.Empty);
                                    item.Fullname = Utils.ConvertToString(dr["Fullname"], string.Empty);
                                    item.Password = Utils.ConvertToString(dr["Password"], string.Empty);
                                    item.Sex = Utils.ConvertToString(dr["Sex"], String.Empty);
                                    item.Nation = Utils.ConvertToString(dr["Nation"], string.Empty);
                                    item.Mobile = Utils.ConvertToString(dr["Mobile"], string.Empty);
                                    item.IdCart = Utils.ConvertToString(dr["IdCart"], string.Empty);
                                    item.AgencyID = Utils.ConvertToInt32(dr["AgencyID"], 0);
                                    item.TypeInfo = Utils.ConvertToInt32(dr["TypeInfo"], 0);
                                    item.Birthday = Utils.ConvertToString(dr["Birthday"], string.Empty);
                                    item.MemberCardNo = Utils.ConvertToString(dr["MemberCardNo"], string.Empty);
                                    item.HeadImg = Utils.ConvertToString(dr["HeadImg"], string.Empty);
                                    item.Source = Utils.ConvertToInt32(dr["Source"], 0);
                                    listUser.Add(item);
                                }
                                dr.Close();
                            }
                            Result.Status = 0;
                            //Result.Message = "Tìm kiếm thành công!";
                            Result.Data = listUser;
                        }
                        catch (Exception)
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

        // tìm kiếm bằng giới tính
        public BaseResultMOD SearchSex(string Sex)
        {
            var Result = new BaseResultMOD();
            try
            {
                List<ListUserMOD> listUser = new List<ListUserMOD>();
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Sex", SqlDbType.NVarChar)
                };
                parameters[0].Value = Sex;
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "SearchSex", parameters))
                            {
                                while (dr.Read())
                                {
                                    ListUserMOD item = new ListUserMOD();
                                    item.Id_user = Utils.ConvertToInt32(dr["Id_user"], 0);
                                    item.Email = Utils.ConvertToString(dr["Email"], string.Empty);
                                    item.Fullname = Utils.ConvertToString(dr["Fullname"], string.Empty);
                                    item.Password = Utils.ConvertToString(dr["Password"], string.Empty);
                                    item.Sex = Utils.ConvertToString(dr["Sex"], String.Empty);
                                    item.Nation = Utils.ConvertToString(dr["Nation"], string.Empty);
                                    item.Mobile = Utils.ConvertToString(dr["Mobile"], string.Empty);
                                    item.IdCart = Utils.ConvertToString(dr["IdCart"], string.Empty);
                                    item.AgencyID = Utils.ConvertToInt32(dr["AgencyID"], 0);
                                    item.TypeInfo = Utils.ConvertToInt32(dr["TypeInfo"], 0);
                                    item.Birthday = Utils.ConvertToDate(dr["Birthday"]);
                                    item.MemberCardNo = Utils.ConvertToString(dr["MemberCardNo"], string.Empty);
                                    item.HeadImg = Utils.ConvertToString(dr["HeadImg"], string.Empty);
                                    item.Source = Utils.ConvertToInt32(dr["Source"], 0);
                                    listUser.Add(item);
                                }
                                dr.Close();
                            }
                            Result.Status = 0;
                            //Result.Message = "Tìm kiếm thành công!";
                            Result.Data = listUser;
                        }
                        catch (Exception)
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

        // reset mật khẩu
        public BaseResultMOD ResetMatKhau(string Email, string Password)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email", SqlDbType.NVarChar),
                    new SqlParameter("@Password", SqlDbType.VarChar),
                };
                parameters[0].Value = Email;
                parameters[1].Value = Password;
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UserEntity_ResetPassword ", parameters);
                            trans.Commit();
                            Result.Message = "Reset mật khẩu người dùng thành công!";
                        }
                        catch (Exception ex)
                        {
                            Result.Status = -1;
                            Result.Message = Constant.ERR_UPDATE;
                            trans.Rollback();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_UPDATE;
                throw;
            }
            return Result;
        }

        // Xuất file excel
        public List<UserEntityMOD> ListUser()
        {
            List<UserEntityMOD> users = new List<UserEntityMOD>();
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.Text, "SELECT * from UserEntity"))
                {
                    while (dr.Read())
                    {
                        UserEntityMOD item = new UserEntityMOD();
                        item.Id_user = Utils.ConvertToInt32(dr["Id_user"], 0);
                        item.Password = Utils.ConvertToString(dr["Password"], string.Empty);
                        item.Sex = Utils.ConvertToString(dr["Sex"], string.Empty);
                        item.Nation = Utils.ConvertToString(dr["Nation"], string.Empty);
                        item.Mobile = Utils.ConvertToString(dr["Mobile"], string.Empty);
                        item.IdCart = Utils.ConvertToString(dr["IdCart"], string.Empty);
                        item.AgencyID = Utils.ConvertToInt32(dr["AgencyID"], 0);
                        item.AgencyID = Utils.ConvertToInt32(dr["AgencyID"], 0);
                        item.TypeInfo = Utils.ConvertToInt32(dr["TypeInfo"], 0);
                        item.Birthday = Utils.ConvertToDate(dr["Birthday"]);
                        item.Fullname = Utils.ConvertToString(dr["Fullname"], string.Empty);
                        item.MemberCardNo = Utils.ConvertToString(dr["MemberCardNo"], string.Empty);
                        item.Email = Utils.ConvertToString(dr["Email"], string.Empty);
                        item.HeadImg = Utils.ConvertToString(dr["HeadImg"], string.Empty);
                        item.Source = Utils.ConvertToInt32(dr["Source"], 0);
                        users.Add(item);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return users;
        }

        // Kiểm tra tài khoản 
        public int checkAccount(string Email)
        {
            var SoTaiKhoan = 0;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", SqlDbType.NVarChar)
            };
            parameters[0].Value = Email;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "CheckAccount", parameters))
                {
                    while (dr.Read())
                    {
                        SoTaiKhoan = Utils.ConvertToInt32(dr["SoTaiKhoan"], 0);
                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {

            }
            return SoTaiKhoan;
        }

        // Quên mật khẩu 
        
    }
}
