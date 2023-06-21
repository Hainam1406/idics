using Idics.MOD;
using Idics.ULT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Idics.DAL
{
    public class ExaminationDataEntityDAL
    {
        // lấy danh sách người dùng
        public BaseResultMOD DanhSach(CheckMOD UserId)
        {
            var Result = new BaseResultMOD();
            List<ExaminationDataEntityMOD> DanhSanhExaminationDataEntity = new List<ExaminationDataEntityMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                /*new SqlParameter("Keyword",SqlDbType.NVarChar,200),
                new SqlParameter("OrderByName",SqlDbType.NVarChar,50),
                new SqlParameter("OrderByOption",SqlDbType.NVarChar,50),
                new SqlParameter("pLimit",SqlDbType.Int),
                new SqlParameter("pOffset",SqlDbType.Int),
                new SqlParameter("TotalRow",SqlDbType.Int),
                new SqlParameter("TrangThai",SqlDbType.TinyInt),
                new SqlParameter("VaiTro",SqlDbType.TinyInt),*/
                new SqlParameter("User_id",SqlDbType.Int),
            };
            /*parameters[0].Value = p.Keyword != null ? p.Keyword : "";
            parameters[1].Value = p.OrderByName;
            parameters[2].Value = p.OrderByOption;
            parameters[3].Value = p.Limit;
            parameters[4].Value = p.Offset;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[5].Size = 8;
            parameters[6].Value = p.TrangThai ?? Convert.DBNull;
            parameters[7].Value = p.VaiTro;*/
            parameters[0].Value = UserId.User_id;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "ExaminationDataEntity_DanhSach", parameters))
                {
                    while (dr.Read())
                    {
                        ExaminationDataEntityMOD item = new ExaminationDataEntityMOD();
                        item.Id = Utils.ConvertToInt32(dr["Id"], 0);
                        item.User_id = Utils.ConvertToInt32(dr["User_id"], 0);
                        item.BloodPressureTestTime = Utils.ConvertToString(dr["BloodPressureTestTime"], string.Empty);
                        item.BloodSugar = Utils.ConvertToInt32(dr["BloodSugar"], 0);
                        item.BloodSugarTestTime = Utils.ConvertToString(dr["BloodSugarTestTime"], string.Empty);
                        item.BloodSugarType = Utils.ConvertToInt32(dr["BloodSugarType"], 0);
                        item.Bmi = Utils.ConvertToInt32(dr["Bmi"], 0);
                        item.Bmr = Utils.ConvertToInt32(dr["Bmr"], 0);
                        item.Bo = Utils.ConvertToInt32(dr["Bo"], 0);
                        item.BoPulse = Utils.ConvertToInt32(dr["BoPulse"], 0);
                        item.BoTestTime = Utils.ConvertToString(dr["BoTestTime"], string.Empty);
                        item.BodyTemperature = Utils.ConvertToInt32(dr["BodyTemperature"], 0);
                        item.BodyTemperatureTestTime = Utils.ConvertToString(dr["BodyTemperatureTestTime"], string.Empty);
                        item.DataSource = Utils.ConvertToInt32(dr["DataSource"], 0);
                        item.Dbp = Utils.ConvertToInt32(dr["Dbp"], 0);
                        item.Fat = Utils.ConvertToInt32(dr["Fat"], 0);
                        item.FatTestTime = Utils.ConvertToString(dr["FatTestTime"], string.Empty);
                        item.GroupID = Utils.ConvertToInt32(dr["GroupID"], 0);
                        item.GroupIDFrom = Utils.ConvertToInt32(dr["GroupIDFrom"], 0);
                        item.Height = Utils.ConvertToInt32(dr["Height"], 0);
                        item.HeightWeightTestTime = Utils.ConvertToString(dr["HeightWeightTestTime"], string.Empty);
                        item.LDbp = Utils.ConvertToInt32(dr["LDbp"], 0);
                        item.LPulse = Utils.ConvertToInt32(dr["LPulse"], 0);
                        item.LSbp = Utils.ConvertToInt32(dr["LSbp"], 0);
                        item.MoistureContent = Utils.ConvertToInt32(dr["MoistureContent"], 0);
                        item.Pulse = Utils.ConvertToInt32(dr["Pulse"], 0);
                        item.Sbp = Utils.ConvertToInt32(dr["Sbp"], 0);
                        item.TestTime = Utils.ConvertToString(dr["TestTime"], string.Empty);
                        item.Uric = Utils.ConvertToInt32(dr["Uric"], 0);
                        item.UricTestTime = Utils.ConvertToString(dr["UricTestTime"], string.Empty);
                        item.Weight = Utils.ConvertToInt32(dr["Weight"], 0);
                        DanhSanhExaminationDataEntity.Add(item);
                    }
                    dr.Close();
                }
                //TotalRow = Utils.ConvertToInt32(parameters[5].Value, 0);
                Result.Status = 1;
                Result.Data = DanhSanhExaminationDataEntity;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                throw;
            }
            return Result;
        }

        // Thong tin chi tiet
        public DetailMOD ChiTiet(int id)
        {
            DetailMOD item = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.Int)
            };
            parameters[0].Value = id;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "ExaminationDataEntity_ChiTiet", parameters))
                {
                    while (dr.Read())
                    {
                        item = new DetailMOD();
                        item.Id = Utils.ConvertToInt32(dr["Id"], 0);
                        item.User_id = Utils.ConvertToInt32(dr["User_id"], 0);
                        item.Email = Utils.ConvertToString(dr["Email"], string.Empty);
                        item.FullName = Utils.ConvertToString(dr["FullName"], string.Empty);
                        item.Sex = Utils.ConvertToString(dr["Sex"], string.Empty);
                        item.Birthday = Utils.ConvertToString(dr["Birthday"], string.Empty);
                        item.IdCart = Utils.ConvertToString(dr["IdCart"], string.Empty);
                        item.Mobile = Utils.ConvertToString(dr["Mobile"], string.Empty);
                        item.Height = Utils.ConvertToInt32(dr["Height"], 0);
                        item.Weight = Utils.ConvertToInt32(dr["Weight"], 0);
                        item.Bmi = Utils.ConvertToInt32(dr["Bmi"], 0);
                        item.BloodSugar = Utils.ConvertToInt32(dr["BloodSugar"], 0);
                        item.BloodPressure = (float)Utils.ConvertToIntDouble(dr["BloodPressure"], 0.0);
                        item.Dbp = Utils.ConvertToInt32(dr["Dbp"], 0);
                        item.LDbp = Utils.ConvertToInt32(dr["LDbp"], 0);
                        item.Pulse = Utils.ConvertToInt32(dr["Pulse"], 0);
                        item.Uric = (float)Utils.ConvertToIntDouble(dr["Uric"], 0.0);
                        item.LSbp = Utils.ConvertToInt32(dr["LSbp"], 0);
                        item.Bo = Utils.ConvertToInt32(dr["Bo"], 0);
                        item.Time = Utils.ConvertToString(dr["Time"], string.Empty);
                        item.Location = Utils.ConvertToString(dr["Location"], string.Empty);
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
        public BaseResultMOD ThemMoi(AddExaminationDataEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@User_id", SqlDbType.Int),
                    new SqlParameter("@BloodPressureTestTime", SqlDbType.Date),
                    new SqlParameter("@BloodSugar", SqlDbType.Float),
                    new SqlParameter("@BloodSugarTestTime", SqlDbType.Date),
                    new SqlParameter("@BloodSugarType", SqlDbType.Int),
                    new SqlParameter("@Bmi", SqlDbType.Float),
                    new SqlParameter("@Bmr", SqlDbType.Float),
                    new SqlParameter("@Bo", SqlDbType.Int),
                    new SqlParameter("@BoPulse", SqlDbType.Int),
                    new SqlParameter("@BoTestTime", SqlDbType.Date),
                    new SqlParameter("@BodyTemperature", SqlDbType.Float),
                    new SqlParameter("@BodyTemperatureTestTime", SqlDbType.Date),
                    new SqlParameter("@DataSource", SqlDbType.Int),
                    new SqlParameter("@Dbp", SqlDbType.Int),
                    new SqlParameter("@Fat", SqlDbType.Float),
                    new SqlParameter("@FatTestTime", SqlDbType.Date),
                    new SqlParameter("@GroupID", SqlDbType.Int),
                    new SqlParameter("@GroupIDFrom", SqlDbType.Int),
                    new SqlParameter("@Height", SqlDbType.Float),
                    new SqlParameter("@HeightWeightTestTime", SqlDbType.Date),
                    new SqlParameter("@LDbp", SqlDbType.Int),
                    new SqlParameter("@LPulse", SqlDbType.Int),
                    new SqlParameter("@LSbp", SqlDbType.Int),
                    new SqlParameter("@MoistureContent", SqlDbType.Float),
                    new SqlParameter("@Pulse", SqlDbType.Int),
                    new SqlParameter("@Sbp", SqlDbType.Int),
                    new SqlParameter("@TestTime", SqlDbType.Date),
                    new SqlParameter("@Uric", SqlDbType.Float),
                    new SqlParameter("@UricTestTime", SqlDbType.Date),
                    new SqlParameter("@Weight", SqlDbType.Float),
                    new SqlParameter("@Device", SqlDbType.NVarChar),
                    new SqlParameter("@Location", SqlDbType.NVarChar),
                    new SqlParameter("@Time", SqlDbType.Date)
                };
                parameters[0].Value = item.User_id;
                parameters[1].Value = item.BloodPressureTestTime;
                parameters[2].Value = item.BloodSugar;
                parameters[3].Value = item.BloodSugarTestTime;
                parameters[4].Value = item.BloodSugarType;
                parameters[5].Value = item.Bmi;
                parameters[6].Value = item.Bmr;
                parameters[7].Value = item.Bo;
                parameters[8].Value = item.BoPulse;
                parameters[9].Value = item.BoTestTime;
                parameters[10].Value = item.BodyTemperature;
                parameters[11].Value = item.BodyTemperatureTestTime;
                parameters[12].Value = item.DataSource;
                parameters[13].Value = item.Dbp;
                parameters[14].Value = item.Fat;
                parameters[15].Value = item.FatTestTime;
                parameters[16].Value = item.GroupID;
                parameters[17].Value = item.GroupIDFrom;
                parameters[18].Value = item.Height;
                parameters[19].Value = item.HeightWeightTestTime;
                parameters[20].Value = item.LDbp;
                parameters[21].Value = item.LPulse;
                parameters[22].Value = item.LSbp;
                parameters[23].Value = item.MoistureContent;
                parameters[24].Value = item.Pulse;
                parameters[25].Value = item.Sbp;
                parameters[26].Value = item.TestTime;
                parameters[27].Value = item.Uric;
                parameters[28].Value = item.UricTestTime;
                parameters[29].Value = item.Weight;
                parameters[30].Value = item.Device;
                parameters[31].Value = item.Location;
                parameters[32].Value = item.Time;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            //Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ExaminationDataEntity_ThemMoi", parameters);
                            Result.Status = ULT.Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "ExaminationDataEntity_ThemMoi", parameters).ToString(), 0);
                            trans.Commit();
                            Result.Message = "Thêm mới thành công!";
                            Result.Data = ChiTiet(Result.Status);
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

        // update dữ liệu 
        public BaseResultMOD CapNhap(UpdateExaminationDataEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("Id", SqlDbType.Int),
                    new SqlParameter("User_id", SqlDbType.Int),
                    new SqlParameter("@BloodPressureTestTime", SqlDbType.Date),
                    new SqlParameter("@BloodSugar", SqlDbType.Float),
                    new SqlParameter("@BloodSugarTestTime", SqlDbType.Date),
                    new SqlParameter("@BloodSugarType", SqlDbType.Int),
                    new SqlParameter("@Bmi", SqlDbType.Float),
                    new SqlParameter("@Bmr", SqlDbType.Float),
                    new SqlParameter("@Bo", SqlDbType.Int),
                    new SqlParameter("@BoPulse", SqlDbType.Int),
                    new SqlParameter("@BoTestTime", SqlDbType.Date),
                    new SqlParameter("@BodyTemperature", SqlDbType.Float),
                    new SqlParameter("@BodyTemperatureTestTime", SqlDbType.Date),
                    new SqlParameter("@DataSource", SqlDbType.Int),
                    new SqlParameter("@Dbp", SqlDbType.Int),
                    new SqlParameter("@Fat", SqlDbType.Float),
                    new SqlParameter("@FatTestTime", SqlDbType.Date),
                    new SqlParameter("@GroupID", SqlDbType.Int),
                    new SqlParameter("@GroupIDFrom", SqlDbType.Int),
                    new SqlParameter("@Height", SqlDbType.Float),
                    new SqlParameter("@HeightWeightTestTime", SqlDbType.Date),
                    new SqlParameter("@LDbp", SqlDbType.Int),
                    new SqlParameter("@LPulse", SqlDbType.Int),
                    new SqlParameter("@LSbp", SqlDbType.Int),
                    new SqlParameter("@MoistureContent", SqlDbType.Float),
                    new SqlParameter("@Pulse", SqlDbType.Int),
                    new SqlParameter("@Sbp", SqlDbType.Int),
                    new SqlParameter("@TestTime", SqlDbType.Date),
                    new SqlParameter("@Uric", SqlDbType.Float),
                    new SqlParameter("@UricTestTime", SqlDbType.Date),
                    new SqlParameter("@Weight", SqlDbType.Float),
                };
                parameters[0].Value = item.Id;
                parameters[1].Value = item.User_id;
                parameters[2].Value = item.BloodPressureTestTime;
                parameters[3].Value = item.BloodSugar;
                parameters[4].Value = item.BloodSugarTestTime;
                parameters[5].Value = item.BloodSugarType;
                parameters[6].Value = item.Bmi;
                parameters[7].Value = item.Bmr;
                parameters[8].Value = item.Bo;
                parameters[9].Value = item.BoPulse;
                parameters[10].Value = item.BoTestTime;
                parameters[11].Value = item.BodyTemperature;
                parameters[12].Value = item.BodyTemperatureTestTime;
                parameters[13].Value = item.DataSource;
                parameters[14].Value = item.Dbp;
                parameters[15].Value = item.Fat;
                parameters[16].Value = item.FatTestTime;
                parameters[17].Value = item.GroupID;
                parameters[18].Value = item.GroupIDFrom;
                parameters[19].Value = item.Height;
                parameters[20].Value = item.HeightWeightTestTime;
                parameters[21].Value = item.LDbp;
                parameters[22].Value = item.LPulse;
                parameters[23].Value = item.LSbp;
                parameters[24].Value = item.MoistureContent;
                parameters[25].Value = item.Pulse;
                parameters[26].Value = item.Sbp;
                parameters[27].Value = item.TestTime;
                parameters[28].Value = item.Uric;
                parameters[29].Value = item.UricTestTime;
                parameters[30].Value = item.Weight;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ExaminationDataEntity_CapNhap", parameters);
                            trans.Commit();
                            Result.Message = "Cập nhật thông tin người dùng thành công!";
                            //Result.Data = ChiTiet(item.Id);
                        }
                        catch (Exception)
                        {
                            Result.Status = -1;
                            Result.Message = Constant.ERR_UPDATE;
                            trans.Rollback();
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

        // xóa dữ liệu 
        public BaseResultMOD Xoa(int id)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("id", SqlDbType.Int)
            };
            parameters[0].Value = id;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var val = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "ExaminationDataEntity_Xoa", parameters);
                        trans.Commit();
                        if (val < 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Không thể xóa dữ liệu!";
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
            Result.Message = "Xóa dữ liệu thành công!";
            return Result;
        }
    }
}
