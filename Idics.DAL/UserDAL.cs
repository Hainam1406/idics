using Idics.MOD;
using Idics.ULT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idics.DAL
{
    public class UserDAL
    {
        //hàm đăng ký
        public BaseResultMOD RegisterDAL(UserMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email", SqlDbType.NVarChar),
                    new SqlParameter("@FullName", SqlDbType.NVarChar),
                    new SqlParameter("@Password", SqlDbType.NVarChar),
                };
                parameters[0].Value = item.Email;
                parameters[1].Value = item.FullName;
                parameters[2].Value = item.Password;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "Register", parameters);
                            trans.Commit();
                            Result.Message = "Đăng ký thành công!";
                            Result.Data = Result.Status;
                        }
                        catch (Exception)
                        {
                            Result.Status = -1;
                            Result.Message = "Đăng ký thất bại!";
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

        // hàm đăng nhập
        public ListUserMOD LoginDAL(string Email, string Password)
        {
            ListUserMOD item = new ListUserMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", SqlDbType.NVarChar),
                new SqlParameter("@Password", SqlDbType.NVarChar),
            };
            parameters[0].Value = Email;
            parameters[1].Value = Password;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "Login", parameters))
                {
                    while (dr.Read())
                    {
                        item = new ListUserMOD();
                        item.Email = Utils.ConvertToString(dr["Email"], string.Empty);
                        item.Password = Utils.ConvertToString(dr["Password"], string.Empty);
                        item.name_GroupUser = Utils.ConvertToString(dr["name_GroupUser"], string.Empty);
                        item.Id_user = Utils.ConvertToInt32(dr["Id_user"], 0);
                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return item;
        }

        // Kiểm tra tài khoản 
        public int checkAccount (string Email)
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

        // tìm kiếm email
        public ListUserMOD Email(string Email)
        {
            ListUserMOD item = new ListUserMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", SqlDbType.NVarChar)
            };
            parameters[0].Value = Email;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "Email", parameters))
                {
                    while (dr.Read())
                    {
                        item = new ListUserMOD();
                        item.Id_user = Utils.ConvertToInt32(dr["Id_user"], 0);
                        item.Email = Utils.ConvertToString(dr["Email"], string.Empty);
                        item.Fullname = Utils.ConvertToString(dr["Fullname"], string.Empty);
                        item.Password = Utils.ConvertToString(dr["Password"], string.Empty);
                        item.name_GroupUser = Utils.ConvertToString(dr["name_GroupUser"], string.Empty);
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

        // Quên mật khẩu
        public int ForgotPassword(string Email, string IdCart)
        {
            var KiemTra = 0;
            SqlParameter[] parameters = new SqlParameter[]
            {
                //new SqlParameter("@Id_user", SqlDbType.Int),
                new SqlParameter("@Email", SqlDbType.NVarChar),
                new SqlParameter("@IdCart", SqlDbType.NVarChar),
            };
            //parameters[0].Value = Id_user;
            parameters[0].Value = Email;
            parameters[1].Value = IdCart;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "ForgotPassword", parameters))
                {
                    while (dr.Read())
                    {
                        KiemTra = Utils.ConvertToInt32(dr["KiemTra"], 0);
                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return KiemTra;
        }

        public List<AuthorizeAttributeMOD> getRole()
        {
            List<AuthorizeAttributeMOD> RoleEntity = new List<AuthorizeAttributeMOD>();
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "PhanQuyen"))
                {
                    while (dr.Read())
                    {
                        AuthorizeAttributeMOD item = new AuthorizeAttributeMOD(Utils.ConvertToInt32(dr["id_user"], 0), Utils.ConvertToInt32(dr["id_Function"], 0),
                            Utils.ConvertToString(dr["name_GroupUser"], string.Empty),
                            Utils.ConvertToString(dr["name_Function"], string.Empty),
                            Utils.ConvertToInt32(dr["role"], 0));
                        //item.TypeInfo = Utils.ConvertToInt32(dr["TypeInfo"], 0);
                        /*item.name_GroupUser = Utils.ConvertToString(dr["name_GroupUser"], String.Empty);
                        item.role = Utils.ConvertToInt32(dr["role"], 0);*/
                        RoleEntity.Add(item);
                    }
                    dr.Close();
                }
            }
            catch
            {
                throw;
            }
            return RoleEntity;

        }

        // reset mật khẩu
        public BaseResultMOD ResetMatKhau(string Email)
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
                parameters[1].Value = "123456";
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
    }
}
