using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idics.MOD
{
    public class UserMOD
    {
        public  string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }

    public class LoginMOD
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ListUserMOD
    {
        public int Id_user { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public string Nation { get; set; }
        public string Mobile { get; set; }
        public string IdCart { get; set; }
        public int AgencyID { get; set; }
        public int TypeInfo { get; set; }
        public string Birthday { get; set; }
        public string Fullname { get; set; }
        public string MemberCardNo { get; set; }
        public string Email { get; set; }
        public string HeadImg { get; set; }
        public int Source { get; set; }
        public string name_GroupUser { get; set; }
    }


    public class ListUser1MOD
    {
        //public int Id_user { get; set; }
        public string Password { get; set; }
        //public string Sex { get; set; }
        // public string Nation { get; set; }
        //public string Mobile { get; set; }
        //public string IdCart { get; set; }
        //public int AgencyID { get; set; }
        //public int TypeInfo { get; set; }
        //public string Birthday { get; set; }
        public string Fullname { get; set; }
        //public string MemberCardNo { get; set; }
        public string Email { get; set; }
        //public string HeadImg { get; set; }
        //public int Source { get; set; }
        public string name_GroupUser { get; set; }
    }


    public class ForgotPasswordMOD
    {
        public string Email { get; set; }
        public string IdCart { get; set; }
    }
}
