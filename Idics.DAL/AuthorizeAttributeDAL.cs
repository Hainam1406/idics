using Idics.MOD;
using Idics.ULT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idics.DAL
{
    public class AuthorizeAttributeDAL
    {
        //public AuthorizeAttributeMOD PhanQuyen(int id_GroupUser)
        //{
        //    AuthorizeAttributeMOD item = new AuthorizeAttributeMOD();
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("id_GroupUser", SqlDbType.Int)
        //    };
        //    parameters[0].Value = id_GroupUser;

        //    try
        //    {
        //        using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "PhanQuyen", parameters))
        //        {
        //            while (dr.Read())
        //            {
        //                item = new AuthorizeAttributeMOD(Utils.ConvertToInt32(dr["id_Function"], 0),
        //                    Utils.ConvertToInt32(dr["id_Function"], 0),
        //                    Utils.ConvertToString(dr["name_Function"], string.Empty),
        //                    Utils.ConvertToInt32(dr["role"], 0));


        //                break;
        //            }
        //            dr.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    return item;
        //}

        public BaseResultMOD PhanQuyen()
        {
            var Result = new BaseResultMOD();
            List<AuthorizeAttributeMOD> PhanQuyen = new List<AuthorizeAttributeMOD>();
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "PhanQuyen"))
                {
                    while (dr.Read())
                    {
                        AuthorizeAttributeMOD item = new AuthorizeAttributeMOD(Utils.ConvertToInt32(dr["id_user"], 0), Utils.ConvertToInt32(dr["id_Function"], 0),
                            Utils.ConvertToString(dr["name_GroupUser"], string.Empty),
                            Utils.ConvertToString(dr["name_Function"], string.Empty),
                            Utils.ConvertToInt32(dr["role"], 0));
                        /*item.id_Function = Utils.ConvertToInt32(dr["id_Function"], 0);
                        item.id_GroupUser = Utils.ConvertToInt32(dr["id_Function"], 0);
                        item.*/
                        PhanQuyen.Add(item);
                    }
                    dr.Close();
                }
                Result.Status = 1;
                Result.Data = PhanQuyen;

            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                throw;
            }
            return Result;
        }
    }
}
