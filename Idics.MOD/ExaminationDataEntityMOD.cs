using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idics.MOD
{
    public class ExaminationDataEntityMOD
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public string? BloodPressureTestTime { get; set; }
        public float? BloodSugar { get; set; }
        public string? BloodSugarTestTime { get; set; }
        public int? BloodSugarType { get; set; }
        public float? Bmi { get; set; }
        public float? Bmr { get; set; }
        public int? Bo { get; set; }
        public int? BoPulse { get; set; }
        public string? BoTestTime { get; set; }
        public float? BodyTemperature { get; set; }
        public string? BodyTemperatureTestTime { get; set; }
        public int? DataSource { get; set; }
        public int? Dbp { get; set; }
        public float? Fat { get; set; }
        public string? FatTestTime { get; set; }
        public int? GroupID { get; set; }
        public int? GroupIDFrom { get; set; }
        public float? Height { get; set; }
        public string? HeightWeightTestTime { get; set; }
        public int? LDbp { get; set; }
        public int? LPulse { get; set; }
        public int? LSbp { get; set; }
        public float? MoistureContent { get; set; }
        public int? Pulse { get; set; }
        public int? Sbp { get; set; }
        public string? TestTime { get; set; }
        public float? Uric { get; set; }
        public string? UricTestTime { get; set; }
        public float? Weight { get; set; }
    }

    public class AddExaminationDataEntityMOD
    {
        public int User_id { get; set; }
        public string? BloodPressureTestTime { get; set; }
        public float? BloodSugar { get; set; }
        public string? BloodSugarTestTime { get; set; }
        public int? BloodSugarType { get; set; }
        public float? Bmi { get; set; }
        public float? Bmr { get; set; }
        public int? Bo { get; set; }
        public int? BoPulse { get; set; }
        public string? BoTestTime { get; set; }
        public float? BodyTemperature { get; set; }
        public string? BodyTemperatureTestTime { get; set; }
        public int? DataSource { get; set; }
        public int? Dbp { get; set; }
        public float? Fat { get; set; }
        public string? FatTestTime { get; set; }
        public int? GroupID { get; set; }
        public int? GroupIDFrom { get; set; }
        public float? Height { get; set; }
        public string? HeightWeightTestTime { get; set; }
        public int? LDbp { get; set; }
        public int? LPulse { get; set; }
        public int? LSbp { get; set; }
        public float? MoistureContent { get; set; }
        public int? Pulse { get; set; }
        public int? Sbp { get; set; }
        public string? TestTime { get; set; }
        public float? Uric { get; set; }
        public string? UricTestTime { get; set; }
        public float? Weight { get; set; }

        public string Device { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
    }

    public class UpdateExaminationDataEntityMOD
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public string? BloodPressureTestTime { get; set; }
        public float? BloodSugar { get; set; }
        public string? BloodSugarTestTime { get; set; }
        public int? BloodSugarType { get; set; }
        public float? Bmi { get; set; }
        public float? Bmr { get; set; }
        public int? Bo { get; set; }
        public int? BoPulse { get; set; }
        public string? BoTestTime { get; set; }
        public float? BodyTemperature { get; set; }
        public string? BodyTemperatureTestTime { get; set; }
        public int? DataSource { get; set; }
        public int? Dbp { get; set; }
        public float? Fat { get; set; }
        public string? FatTestTime { get; set; }
        public int? GroupID { get; set; }
        public int? GroupIDFrom { get; set; }
        public float? Height { get; set; }
        public string? HeightWeightTestTime { get; set; }
        public int? LDbp { get; set; }
        public int? LPulse { get; set; }
        public int? LSbp { get; set; }
        public float? MoistureContent { get; set; }
        public int? Pulse { get; set; }
        public int? Sbp { get; set; }
        public string? TestTime { get; set; }
        public float? Uric { get; set; }
        public string? UricTestTime { get; set; }
        public float? Weight { get; set; }
    }

    public class DetailMOD
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Birthday { get; set; }
        public string IdCart { get; set; }
        public string Mobile { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float Bmi { get; set; }
        public float BloodPressure { get; set; }
        public float BloodSugar { get; set; }
        public int Dbp { get; set; }
        public int LDbp { get; set; }
        public int Pulse { get; set; }
        public float Uric { get; set; }
        public int LSbp { get; set; }
        public int Bo { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
    }

    public class CheckMOD
    {
        public int User_id { get; set; }
    }

}
