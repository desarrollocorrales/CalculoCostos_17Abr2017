using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalculoCostos.Modelos;
using FirebirdSql.Data.FirebirdClient;

namespace CalculoCostos.Datos
{
    public class ConsultasFBDatos : IConsultasFBDatos
    {
        // Variable que almacena el estado de la conexión a la base de datos
        IConexionFB _conexionFB;

        public ConsultasFBDatos()
        {
            this._conexionFB = new ConexionFB(Modelos.ConectionString.connFB);
        }

        // realiza una prueba de conexion a la base de datos de FIREBIRD
        public bool pruebaConn()
        {
            using (var conn = this._conexionFB.getConexionFB())
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (FbException)
                {
                    return false;
                }
            }
        }

        public List<Articulos> obtieneArticulos(long almacenId)
        {
            List<Modelos.Articulos> result = new List<Modelos.Articulos>();
            Modelos.Articulos ent;

            string sql =
                "SELECT ca.CLAVE_ARTICULO, a.articulo_id, a.NOMBRE, a.ESTATUS, a.COSTO_ULTIMA_COMPRA, " +
                        "cc.almacen_id, cc.EXISTENCIA, cc.VALOR_TOTAL " +

                "from articulos a " +

                "left join CAPAS_COSTOS cc on (a.ARTICULO_ID = cc.ARTICULO_ID) " +

                "left join claves_articulos ca on (a.articulo_id = ca.ARTICULO_ID) " +

                "WHERE A.ESTATUS = 'A' AND CA.ROL_CLAVE_ART_ID = 17 and cc.almacen_Id = @almacenId " +

                "ORDER BY A.NOMBRE";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionFB.getConexionFB())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new FbCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@almacenId", almacenId);

                    ManejoSql_FB res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        if (res.reader.HasRows)
                            while (res.reader.Read())
                            {
                                ent = new Modelos.Articulos();

                                ent.articuloId = Convert.ToInt64(res.reader["ARTICULO_ID"]);
                                ent.cvearticulo = Convert.ToString(res.reader["CLAVE_ARTICULO"]);
                                ent.articulo = Convert.ToString(res.reader["NOMBRE"]);
                                ent.estatus = Convert.ToString(res.reader["ESTATUS"]);

                                // lista
                                if (res.reader["EXISTENCIA"] is DBNull)
                                {
                                    ent.costo = 0;
                                }
                                else
                                {
                                    if (res.reader["VALOR_TOTAL"] is DBNull)
                                        ent.costo = 0;
                                    else
                                    {
                                        decimal costo = 0;
                                        decimal exis = Convert.ToDecimal(res.reader["EXISTENCIA"]);
                                        decimal valT = Convert.ToDecimal(res.reader["VALOR_TOTAL"]);

                                        if (valT == 0)
                                            ent.costo = costo;
                                        else
                                        {
                                            costo = valT / exis;

                                            ent.costo = Math.Round(costo, 2);
                                        }

                                    }
                                }

                                result.Add(ent);
                            }
                    }
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }


        public List<Almacen> getAlmacen()
        {
            List<Modelos.Almacen> result = new List<Modelos.Almacen>();
            Modelos.Almacen ent;

            string sql =
                "SELECT " +
                        "ALMACENES.ALMACEN_ID, " +
                        "ALMACENES.NOMBRE, " +
                        "ALMACENES.NOMBRE_ABREV " +
                "FROM ALMACENES ";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionFB.getConexionFB())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new FbCommand())
                {
                    cmd.Connection = conn;

                    ManejoSql_FB res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        if (res.reader.HasRows)
                            while (res.reader.Read())
                            {
                                ent = new Modelos.Almacen();

                                ent.almacenId = Convert.ToInt64(res.reader["ALMACEN_ID"]);
                                ent.nombre = Convert.ToString(res.reader["NOMBRE"]);
                                ent.nombreAbr = Convert.ToString(res.reader["NOMBRE_ABREV"]);
                                
                                result.Add(ent);
                            }
                    }
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }
    }
}
