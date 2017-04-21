using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoCostos.Negocio
{
    public interface IConsultasFBNegocio
    {
        bool pruebaConn();

        List<Modelos.Articulos> obtieneArticulos(long almacenId);

        List<Modelos.Almacen> getAlmacenes();
    }
}
