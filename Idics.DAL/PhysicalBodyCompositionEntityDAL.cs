using Idics.MOD;
using Idics.ULT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idics.DAL
{
    public class PhysicalBodyCompositionEntityDAL
    {
        // lấy danh sách người dùng
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<PhysicalBodyCompositionEntityMOD> DanhSanhPhysicalBodyCompositionEntity = new List<PhysicalBodyCompositionEntityMOD>();
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
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "PhysicalBodyCompositionEntity_DanhSach", parameters))
                {
                    while (dr.Read())
                    {
                        PhysicalBodyCompositionEntityMOD item = new PhysicalBodyCompositionEntityMOD();
                        item.Id = Utils.ConvertToInt32(dr["Id"], 0);
                        item.FAT = Utils.ConvertToInt32(dr["FAT"], 0);
                        item.Intracellular = Utils.ConvertToInt32(dr["Intracellular"], 0);
                        item.Extracellular = Utils.ConvertToInt32(dr["Extracellular"], 0);
                        item.Bone = Utils.ConvertToInt32(dr["Bone"], 0);
                        item.Protein = Utils.ConvertToInt32(dr["Protein"], 0);
                        item.TBW = Utils.ConvertToInt32(dr["TBW"], 0);
                        item.Muscle = Utils.ConvertToInt32(dr["Muscle"], 0);
                        item.Pbf = Utils.ConvertToInt32(dr["Pbf"], 0);
                        item.SMM = Utils.ConvertToInt32(dr["SMM"], 0);
                        item.BMI = Utils.ConvertToInt32(dr["BMI"], 0);
                        item.WHR = Utils.ConvertToInt32(dr["WHR"], 0);
                        item.Edema = Utils.ConvertToInt32(dr["Edema"], 0);
                        item.VFI = Utils.ConvertToInt32(dr["VFI"], 0);
                        item.BodyFatMass = Utils.ConvertToInt32(dr["BodyFatMass"], 0);
                        item.FatRegulation = Utils.ConvertToInt32(dr["FatRegulation"], 0);
                        item.BodyWaterComponent = Utils.ConvertToInt32(dr["BodyWaterComponent"], 0);
                        item.BodyWaterRate = Utils.ConvertToInt32(dr["BodyWaterRate"], 0);
                        item.BasalMetabolism = Utils.ConvertToInt32(dr["BasalMetabolism"], 0);
                        item.Mineral = Utils.ConvertToInt32(dr["Mineral"], 0);
                        item.OtherComponentValue = Utils.ConvertToInt32(dr["OtherComponentValue"], 0);
                        item.VisceralFatLevel = Utils.ConvertToInt32(dr["VisceralFatLevel"], 0);
                        item.WeightRegulation = Utils.ConvertToInt32(dr["WeightRegulation"], 0);
                        item.FatRegulation = Utils.ConvertToInt32(dr["FatRegulation"], 0);
                        item.MuscleRegulation = Utils.ConvertToInt32(dr["MuscleRegulation"], 0);
                        item.CheckDate = Utils.ConvertToString(dr["CheckDate"], string.Empty);
                        item.Height = Utils.ConvertToInt32(dr["Height"], 0);
                        item.Weight = Utils.ConvertToInt32(dr["Weight"], 0);
                        item.SubcutaneousFatRate = Utils.ConvertToInt32(dr["SubcutaneousFatRate"], 0);
                        item.SkeletalMuscleRate = Utils.ConvertToInt32(dr["SkeletalMuscleRate"], 0);
                        item.BoneMass = Utils.ConvertToInt32(dr["BoneMass"], 0);
                        item.LeanBodyWeight = Utils.ConvertToInt32(dr["LeanBodyWeight"], 0);
                        DanhSanhPhysicalBodyCompositionEntity.Add(item);
                    }
                    dr.Close();
                }
                TotalRow = Utils.ConvertToInt32(parameters[5].Value, 0);
                Result.Status = 1;
                Result.Data = DanhSanhPhysicalBodyCompositionEntity;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                throw;
            }
            return Result;
        }

        public BaseResultMOD ThemMoi(AddPhysicalBodyCompositionEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FAT", SqlDbType.Int),
                    new SqlParameter("@Intracellular", SqlDbType.Int),
                    new SqlParameter("@Extracellular", SqlDbType.Int),
                    new SqlParameter("@Bone", SqlDbType.Int),
                    new SqlParameter("@Protein", SqlDbType.Int),
                    new SqlParameter("@TBW", SqlDbType.Int),
                    new SqlParameter("@Muscle", SqlDbType.Int),
                    new SqlParameter("@Pbf", SqlDbType.Int),
                    new SqlParameter("@SMM", SqlDbType.Int),
                    new SqlParameter("@BMI", SqlDbType.Int),
                    new SqlParameter("@WHR", SqlDbType.Int),
                    new SqlParameter("@Edema", SqlDbType.Int),
                    new SqlParameter("@VFI", SqlDbType.Int),
                    new SqlParameter("@BodyFatMass", SqlDbType.Int),
                    new SqlParameter("@Fatremoval", SqlDbType.Int),
                    new SqlParameter("@BodyWaterRate", SqlDbType.Int),
                    new SqlParameter("@BodyWaterComponent", SqlDbType.Int),
                    new SqlParameter("@BasalMetabolism", SqlDbType.Int),
                    new SqlParameter("@Mineral", SqlDbType.Int),
                    new SqlParameter("@OtherComponentValue", SqlDbType.Int),
                    new SqlParameter("@VisceralFatLevel", SqlDbType.Int),
                    new SqlParameter("@WeightRegulation", SqlDbType.Int),
                    new SqlParameter("@FatRegulation", SqlDbType.Int),
                    new SqlParameter("@MuscleRegulation", SqlDbType.Int),
                    new SqlParameter("@CheckDate", SqlDbType.Date),
                    new SqlParameter("@Height", SqlDbType.Int),
                    new SqlParameter("@Weight", SqlDbType.Int),
                    new SqlParameter("@SubcutaneousFatRate", SqlDbType.Int),
                    new SqlParameter("@SkeletalMuscleRate", SqlDbType.Int),
                    new SqlParameter("@BoneMass", SqlDbType.Int),
                    new SqlParameter("@LeanBodyWeight", SqlDbType.Int),
                };
                parameters[0].Value = item.FAT;
                parameters[1].Value = item.Intracellular;
                parameters[2].Value = item.Extracellular;
                parameters[3].Value = item.Bone;
                parameters[4].Value = item.Protein;
                parameters[5].Value = item.TBW;
                parameters[6].Value = item.Muscle;
                parameters[7].Value = item.Pbf;
                parameters[8].Value = item.SMM;
                parameters[9].Value = item.BMI;
                parameters[10].Value = item.WHR;
                parameters[11].Value = item.Edema;
                parameters[12].Value = item.VFI;
                parameters[13].Value = item.BodyFatMass;
                parameters[14].Value = item.Fatremoval;
                parameters[15].Value = item.BodyWaterRate;
                parameters[16].Value = item.BodyWaterComponent;
                parameters[17].Value = item.BasalMetabolism;
                parameters[18].Value = item.Mineral;
                parameters[19].Value = item.OtherComponentValue;
                parameters[20].Value = item.VisceralFatLevel;
                parameters[21].Value = item.WeightRegulation;
                parameters[22].Value = item.FatRegulation;
                parameters[23].Value = item.MuscleRegulation;
                parameters[24].Value = item.CheckDate;
                parameters[25].Value = item.Height;
                parameters[26].Value = item.Weight;
                parameters[27].Value = item.SubcutaneousFatRate;
                parameters[28].Value = item.SkeletalMuscleRate;
                parameters[29].Value = item.BoneMass;
                parameters[30].Value = item.LeanBodyWeight;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "PhysicalBodyCompositionEntity_ThemMoi", parameters);
                            trans.Commit();
                            Result.Message = "Thêm mới thành công!";
                            //Result.Data = ChiTiet(Result.Status);
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

        public BaseResultMOD CapNhap(UpdatePhysicalBodyCompositionEntityMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", SqlDbType.Int),
                    new SqlParameter("@FAT", SqlDbType.Int),
                    new SqlParameter("@Intracellular", SqlDbType.Int),
                    new SqlParameter("@Extracellular", SqlDbType.Int),
                    new SqlParameter("@Bone", SqlDbType.Int),
                    new SqlParameter("@Protein", SqlDbType.Int),
                    new SqlParameter("@TBW", SqlDbType.Int),
                    new SqlParameter("@Muscle", SqlDbType.Int),
                    new SqlParameter("@Pbf", SqlDbType.Int),
                    new SqlParameter("@SMM", SqlDbType.Int),
                    new SqlParameter("@BMI", SqlDbType.Int),
                    new SqlParameter("@WHR", SqlDbType.Int),
                    new SqlParameter("@Edema", SqlDbType.Int),
                    new SqlParameter("@VFI", SqlDbType.Int),
                    new SqlParameter("@BodyFatMass", SqlDbType.Int),
                    new SqlParameter("@Fatremoval", SqlDbType.Int),
                    new SqlParameter("@BodyWaterRate", SqlDbType.Int),
                    new SqlParameter("@BodyWaterComponent", SqlDbType.Int),
                    new SqlParameter("@BasalMetabolism", SqlDbType.Int),
                    new SqlParameter("@Mineral", SqlDbType.Int),
                    new SqlParameter("@OtherComponentValue", SqlDbType.Int),
                    new SqlParameter("@VisceralFatLevel", SqlDbType.Int),
                    new SqlParameter("@WeightRegulation", SqlDbType.Int),
                    new SqlParameter("@FatRegulation", SqlDbType.Int),
                    new SqlParameter("@MuscleRegulation", SqlDbType.Int),
                    new SqlParameter("@CheckDate", SqlDbType.Date),
                    new SqlParameter("@Height", SqlDbType.Int),
                    new SqlParameter("@Weight", SqlDbType.Int),
                    new SqlParameter("@SubcutaneousFatRate", SqlDbType.Int),
                    new SqlParameter("@SkeletalMuscleRate", SqlDbType.Int),
                    new SqlParameter("@BoneMass", SqlDbType.Int),
                    new SqlParameter("@LeanBodyWeight", SqlDbType.Int),
                };
                parameters[0].Value = item.Id;
                parameters[1].Value = item.FAT;
                parameters[2].Value = item.Intracellular;
                parameters[3].Value = item.Extracellular;
                parameters[4].Value = item.Bone;
                parameters[5].Value = item.Protein;
                parameters[6].Value = item.TBW;
                parameters[7].Value = item.Muscle;
                parameters[8].Value = item.Pbf;
                parameters[9].Value = item.SMM;
                parameters[10].Value = item.BMI;
                parameters[11].Value = item.WHR;
                parameters[12].Value = item.Edema;
                parameters[13].Value = item.VFI;
                parameters[14].Value = item.BodyFatMass;
                parameters[15].Value = item.Fatremoval;
                parameters[16].Value = item.BodyWaterRate;
                parameters[17].Value = item.BodyWaterComponent;
                parameters[18].Value = item.BasalMetabolism;
                parameters[19].Value = item.Mineral;
                parameters[20].Value = item.OtherComponentValue;
                parameters[21].Value = item.VisceralFatLevel;
                parameters[22].Value = item.WeightRegulation;
                parameters[23].Value = item.FatRegulation;
                parameters[24].Value = item.MuscleRegulation;
                parameters[25].Value = item.CheckDate;
                parameters[26].Value = item.Height;
                parameters[27].Value = item.Weight;
                parameters[28].Value = item.SubcutaneousFatRate;
                parameters[29].Value = item.SkeletalMuscleRate;
                parameters[30].Value = item.BoneMass;
                parameters[31].Value = item.LeanBodyWeight;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "PhysicalBodyCompositionEntity_CapNhap", parameters);
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
    }
}
