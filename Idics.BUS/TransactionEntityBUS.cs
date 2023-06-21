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
    public class TransactionEntityBUS
    {
        // Danh sách dữ liệu 
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new TransactionEntityDAL().DanhSach(p, ref TotalRow);
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                Result.Data = null;
            }
            return Result;
        }

        // thêm mới dữ liệu
        public BaseResultMOD ThemMoi(ADDTransactionEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null || item.id_user == null || item.id_user < 1)
                {
                    Result.Status = 0;
                    Result.Message = "ID không được để trống!";
                    return Result;
                }
                else
                {
                    return new TransactionEntityDAL().ThemMoi(item);
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

        // Tìm kiếm bằng ngày/tháng/năm
        public BaseResultMOD Search(string Time1, string Time2)
        {
            var Result = new BaseResultMOD();
            try
            {
                    Result.Data = new TransactionEntityDAL().Search(Time1, Time2);
                    Result.Status = 1;
                    return Result;
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

        public BaseResultMOD Xoa(int id_giaodich)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_giaodich == null || id_giaodich < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new TransactionEntityDAL().Xoa(id_giaodich);
                    if (kiemTraTaiKhoan == null)
                    {
                        Result.Status = 0;
                        Result.Message = "ID không được để trống!";
                        return Result;
                    }
                    else
                    {
                        Result.Status = 1;
                        Result.Message = "Xóa thành công!";
                        return Result;
                    }
                    //return new TransactionEntityDAL().Xoa(id);
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
