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
    public class PhysicalBodyCompositionEntityBUS
    {
        // Danh sách dữ liệu 
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new PhysicalBodyCompositionEntityDAL().DanhSach(p, ref TotalRow);
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

        // thêm mới dữ liệu 
        public BaseResultMOD ThemMoi(AddPhysicalBodyCompositionEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                
                    return new PhysicalBodyCompositionEntityDAL().ThemMoi(item);
                
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
        public BaseResultMOD CapNhap(UpdatePhysicalBodyCompositionEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                
                    return new PhysicalBodyCompositionEntityDAL().CapNhap(item);
               
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }
    }
}
