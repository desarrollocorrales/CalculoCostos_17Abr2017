using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoCostos.Modelos
{
    public class Articulos
    {
        public bool seleccionado { get; set; }
        public long articuloId { get; set; }
        public string cvearticulo { get; set; }
        public string articulo { get; set; }
        public string estatus { get; set; }
        public decimal? costo { get; set; }

        public decimal calculo { get; set; }
    }
}
