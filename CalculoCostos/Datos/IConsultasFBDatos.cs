using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoCostos.Datos
{
    public interface IConsultasFBDatos
    {
        bool pruebaConn();

        List<Modelos.Articulos> obtieneArticulos(long almacenId);

        List<Modelos.Almacen> getAlmacen();
    }
}
