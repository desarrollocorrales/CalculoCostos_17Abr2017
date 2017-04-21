using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;

namespace CalculoCostos.Modelos
{
    public interface IConexionFB
    {
        FbConnection getConexionFB();
    }
}
