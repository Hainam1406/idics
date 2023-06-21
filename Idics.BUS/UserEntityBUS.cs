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
    public class UserEntityBUS
    {
        // Danh sách dữ liệu 
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new UserEntityDAL().DanhSach(p, ref TotalRow);
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

        // chi tiết dữ liệu
        public BaseResultMOD ChiTiet(int Id_user)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (Id_user == null || Id_user < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id";
                    return Result;
                }
                else
                {
                    Result.Data = new UserEntityDAL().ChiTiet(Id_user);
                    Result.Status = 1;
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

        // thêm mới dữ liệu 
        public BaseResultMOD ThemMoi(AddUserEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null || item.Sex == null || item.Sex == "")
                {
                    Result.Status = 0;
                    Result.Message = "Sex không được để trống!";
                    return Result;
                }
                else if (item.Nation == null || item.Nation == "")
                {
                    Result.Status = 0;
                    Result.Message = "Nation không được để trống";
                    return Result;
                }
                else if (item.Mobile == null || item.Mobile == "")
                {
                    Result.Status = 0;
                    Result.Message = "Mobile không được để trống";
                    return Result;
                }
                else if (item.IdCart == null || item.IdCart == "")
                {
                    Result.Status = 0;
                    Result.Message = "IdCart không được để trống";
                    return Result;
                }
                else if (item.Birthday == null || item.Birthday == "")
                {
                    Result.Status = 0;
                    Result.Message = "Birthday không được để trống";
                    return Result;
                }
                else if (item.Fullname == null || item.Fullname == "")
                {
                    Result.Status = 0;
                    Result.Message = "Fullname không được để trống";
                    return Result;
                }
                else if (item.Email == null || item.Email == "")
                {
                    Result.Status = 0;
                    Result.Message = "Email không được để trống";
                    return Result;
                }
                var CheckAccount = new UserDAL().checkAccount(item.Email);
                if (CheckAccount > 0)
                {
                    Result.Status = 0;
                    Result.Message = "Email đã tồn tại!";
                }
                else
                {
                    return new UserEntityDAL().ThemMoi(item);
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

        // Cập nhập dữ liệu
        public BaseResultMOD CapNhap(UpdateUserEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                    return new UserEntityDAL().CapNhap(item);
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }

        // xóa người dùng
        public BaseResultMOD Xoa(int Id_user)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (Id_user == null || Id_user < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new UserEntityDAL().ChiTiet(Id_user);
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.Id_user < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "ID không tồn tại!";
                        return Result;
                    }
                    else
                        return new UserEntityDAL().Xoa(Id_user);
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
            }
            return Result;
        }

        // tìm kiếm người dùng
        public BaseResultMOD Search(string Email)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (Email == null || Email == "")
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn Email";
                    return Result;
                }
                else
                {
                    Result.Data = new UserEntityDAL().Search(Email);
                    Result.Status = 1;
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

        // Tìm kiếm bằng giới tính
        public BaseResultMOD SearchSex(string Sex)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (Sex == null || Sex == "")
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn Email";
                    return Result;
                }
                else
                {
                    Result.Data = new UserEntityDAL().SearchSex(Sex);
                    Result.Status = 1;
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

        // reset mat khau 
        public BaseResultMOD ResetMatKhau(string Email, string Password)
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
                    var kiemTraTaiKhoan = new UserEntityDAL().ResetMatKhau(Email, Password);
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.Status < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "Người dùng không tồn tại!";
                        return Result;
                    }
                    else
                        return new UserEntityDAL().ResetMatKhau(Email, Password);
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
