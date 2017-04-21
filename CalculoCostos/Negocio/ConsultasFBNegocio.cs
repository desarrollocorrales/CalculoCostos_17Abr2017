using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalculoCostos.Datos;

namespace CalculoCostos.Negocio
{
    public class ConsultasFBNegocio : IConsultasFBNegocio
    {
        private IConsultasFBDatos _consultasFBDatos;

        public ConsultasFBNegocio()
        {
            this._consultasFBDatos = new ConsultasFBDatos();
        }

        public bool pruebaConn()
        {
            return this._consultasFBDatos.pruebaConn();
        }

        public List<Modelos.Articulos> obtieneArticulos(long almacenId)
        {
            return this._consultasFBDatos.obtieneArticulos(almacenId);
        }

        public List<Modelos.Almacen> getAlmacenes()
        {
            return this._consultasFBDatos.getAlmacen();
        }
    }
}
