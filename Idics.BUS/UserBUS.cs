using Idics.DAL;
using Idics.MOD;
using Idics.ULT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idics.BUS
{
    public class UserBUS
    {
        // đăng ký người dùng
        public BaseResultMOD RegisterBUS(UserMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if(item == null || item.Email == null || item.Email == "")
                {
                    Result.Status = 0;
                    Result.Message = "Email không được để trống";
                    return Result;
                }
                else if (item.FullName == null || item.FullName == "")
                {
                    Result.Status = 0;
                    Result.Message = "Tên không được để trống";
                    return Result ;
                }
                else if (item.Password == null || item.Password == "")
                {
                    Result.Status = 0;
                    Result.Message = "Mật khẩu không được để trống";
                    return Result;
                }
                else
                {
                    var CheckAccount = new UserDAL().checkAccount(item.Email);
                    if (CheckAccount > 0)
                    {
                        Result.Status = 0;
                        Result.Message = "Tài khoản đã tồn tại!";
                    }
                    else
                    {
                        return new UserDAL().RegisterDAL(item);
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

        // đăng nhập người dùng
        public BaseResultMOD LoginBUS(LoginMOD login)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (login.Email == null || login.Email == "")
                {
                    Result.Status = 0;
                    Result.Message = "Email không được để trống";
                    return Result;
                }
                else if (login.Password == null || login.Password == "")
                {
                    Result.Status = 0;
                    Result.Message = "Mật khẩu không được để trống";
                    return Result;
                }
                else 
                {
                    var userLogin = new UserDAL().LoginDAL(login.Email, login.Password);
                    if (userLogin != null && userLogin.Email != null)
                    {
                        Result.Status = 1;
                        Result.Message = "Đăng nhập thành công";
                        Result.Data = userLogin;
                    }
                    else
                    {
                        Result.Status = 0;
                        Result.Message = "Tài khoản hoặc mật khẩu không đúng!";
                    }
                    return Result;
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

        // chi tiết Email
        public BaseResultMOD Email(string Email)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (Email == null || Email == "")
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng nhập Email";
                    return Result;
                }
                else
                {
                    var email = new UserDAL().Email(Email);
                    if (email != null && email.Email != null)
                    {
                        Result.Status = 1;
                        Result.Message = "Đăng nhập thành công!";
                        Result.Data = email;
                    }
                    else
                    {
                        Result.Status = 0;
                        Result.Message = "";
                    }
                    return Result;

                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                Result.Data = null;
                throw;
            }
            return Result;
        }

        // Quên mật khẩu
        public BaseResultMOD ForgotPassword(string Email, string IdCart)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (Email == null || Email == "")
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng nhập email";
                    return Result;
                }
                else if (IdCart == null || IdCart == "")
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng nhập IdCard";
                    return Result;
                }
                else
                {
                    var KiemTra = new UserDAL().ForgotPassword(Email, IdCart);
                    if (KiemTra > 0)
                    {
                        Result.Status = 1;
                        Result.Message = "Người dùng chính xác!";
                        return Result;
                    }
                    else
                    {
                        Result.Status = 0;
                        Result.Message = "Người dùng không tồn tại!";
                        return Result;
                    }

                    
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public BaseResultMOD ListPhanQuyen()
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new AuthorizeAttributeDAL().PhanQuyen();
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                Result.Data = null;
                throw;
            }
            return Result;
        }

        // reset mat khau 
        public BaseResultMOD ResetMatKhau(string Email)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (Email == null || Email == "")
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn email!";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new UserDAL().ResetMatKhau(Email);
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.Status < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "Người dùng không tồn tại!";
                        return Result;
                    }
                    else
                        return new UserDAL().ResetMatKhau(Email);
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
            }
            return Result;
        }
    }
}
