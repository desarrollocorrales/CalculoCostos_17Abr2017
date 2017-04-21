using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;

namespace CalculoCostos.Modelos
{
    public class ManejoSql_FB
    {
        public bool ok { get; set; }
        public FbDataReader reader { get; set; }
        public int numErr { get; set; }
        public string descErr { get; set; }
    }
}
