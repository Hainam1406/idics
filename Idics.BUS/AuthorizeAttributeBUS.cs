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
    public class AuthorizeAttributeBUS
    {
        //public BaseResultMOD PhanQuyen(int id_GroupUser)
        //{
        //    var Result = new BaseResultMOD();
        //    try
        //    {
        //        if (id_GroupUser == null || id_GroupUser < 1)
        //        {
        //            Result.Status = 0;
        //            Result.Message = "Vui lòng nhập id";
        //            return Result;
        //        }
        //        else
        //        {
        //            Result.Data = new AuthorizeAttributeDAL().PhanQuyen(id_GroupUser);
        //            Result.Status = 1;
        //            return Result;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Result.Status = -1;
        //        Result.Message = Constant.ERR_INSERT;
        //        Result.Data = null;
        //        throw;
        //    }
        //    return Result;
        //}

        public BaseResultMOD PhanQuyen()
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
    }
}
