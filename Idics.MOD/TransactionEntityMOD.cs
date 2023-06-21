using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idics.MOD
{
    public class TransactionEntityMOD
    {
        public int id_giaodich { get; set; }
        public int id_user { get; set; }
        public string FullName { get; set; }
        public string Device { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
    }

    public class ADDTransactionEntityMOD
    {
        public int id_user { get; set; }
        public string Device { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
    }

}
