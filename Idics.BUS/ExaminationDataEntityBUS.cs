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
    public class ExaminationDataEntityBUS
    {
        // Danh sách dữ liệu 
        public BaseResultMOD DanhSach(CheckMOD UserId)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new ExaminationDataEntityDAL().DanhSach(UserId);
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

        // Thong tin chi tiet
        public BaseResultMOD ChiTiet(int id)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id == null || id < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id";
                    return Result;
                }
                else
                {
                    var KiemTraID = new ExaminationDataEntityDAL().ChiTiet(id);
                    if(KiemTraID == null || KiemTraID.Id < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "ID không tồn tại";
                        return Result;
                    }
                    else
                    {
                        Result.Status = 1;
                        Result.Data = KiemTraID;
                        return Result;
                    }
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
        public BaseResultMOD ThemMoi(AddExaminationDataEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                return new ExaminationDataEntityDAL().ThemMoi(item);
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }

        // Cập nhập dữ liệu
        public BaseResultMOD CapNhap(UpdateExaminationDataEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
               
                    return new ExaminationDataEntityDAL().CapNhap(item);
               
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }

        // xoa du lieu
        public BaseResultMOD Xoa(int id)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id == null || id < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new ExaminationDataEntityDAL().ChiTiet(id);
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.Id < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "ID không tồn tại!";
                        return Result;
                    }
                    else
                        return new ExaminationDataEntityDAL().Xoa(id);
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
