using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CalculoCostos.GUIs;
using CalculoCostos.Negocio;
using DevExpress.XtraEditors.Repository;

namespace CalculoCostos
{
    public partial class FormPrincipal : Form
    {
        private bool _defConfig;
        private IConsultasFBNegocio _consultasFBNegocio;
        private List<Modelos.Articulos> _articulos = new List<Modelos.Articulos>();

        public FormPrincipal()
        {
            InitializeComponent();
            this.gcCalcCosto.DataSource = this._articulos;
            this.gcArticulos.DataSource = this._articulos;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                // valida si ya tiene alguna clave guardada para el archivo
                string cveActual = Properties.Settings.Default.accesoConfig;

                if (string.IsNullOrEmpty(cveActual))
                {
                    string acceso = Modelos.Utilerias.Transform("p4ssw0rd");

                    Properties.Settings.Default.accesoConfig = acceso;
                    Properties.Settings.Default.Save();
                }

                string fileName = "config.dat";
                string pathConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CalcCostos\";

                // si no existe el directorio, lo crea
                bool exists = System.IO.Directory.Exists(pathConfigFile);

                if (!exists) System.IO.Directory.CreateDirectory(pathConfigFile);

                // busca en el directorio si exite el archivo con el nombre dado
                var file = Directory.GetFiles(pathConfigFile, fileName, SearchOption.AllDirectories)
                        .FirstOrDefault();

                if (file == null)
                {
                    // no existe
                    // abrir el formulario para llenar la configuracion de conexion 
                    frmConfiguracion form = new frmConfiguracion();
                    var resultado = form.ShowDialog();

                    if (resultado != System.Windows.Forms.DialogResult.OK)
                    {
                        this._defConfig = false;
                        throw new Exception("No se ha definido la configuración");
                    }
                }

                file = Directory.GetFiles(pathConfigFile, fileName, SearchOption.AllDirectories)
                        .FirstOrDefault();

                // si existe
                // obtener la cadena de conexion del archivo
                FEncrypt.Respuesta result = FEncrypt.EncryptDncrypt.DecryptFile(file, "milagros");

                if (result.status == FEncrypt.Estatus.ERROR)
                    throw new Exception(result.error);

                if (result.status == FEncrypt.Estatus.OK)
                {
                    string[] list = result.resultado.Split(new string[] { "||" }, StringSplitOptions.None);

                    // FIREBIRD
                    string servidorM = list[0].Substring(2);    // servidor microsip
                    string usuarioM = list[1].Substring(2);     // usuario microsip
                    string contraM = list[2].Substring(2);      // contraseña microsip
                    string puertoM = list[3].Substring(2);      // puerto microsip
                    string baseDatosM = list[4].Substring(2);   // base de datos microsip

                    Modelos.ConectionString.connFB = string.Format(
                                "User={0};Password={1};Database={2};DataSource={3};Port={4}",
                                usuarioM,
                                contraM,
                                baseDatosM,
                                servidorM,
                                puertoM);

                }

                this._defConfig = true;

                this._consultasFBNegocio = new ConsultasFBNegocio();

                // carga combo de almacenes
                this.cmbAlmacen.DataSource = this._consultasFBNegocio.getAlmacenes();
                this.cmbAlmacen.DisplayMember = "nombre";
                this.cmbAlmacen.ValueMember = "almacenId";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Calcular Costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmAcceso formA = new frmAcceso();

            var respuesta = formA.ShowDialog();

            if (respuesta == System.Windows.Forms.DialogResult.OK)
            {
                frmConfiguracion form = new frmConfiguracion();
                var resultado = form.ShowDialog();

                if (resultado == System.Windows.Forms.DialogResult.OK)
                    this.FormPrincipal_Load(null, null);
            }
        }

        private void btnCargaArt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this._defConfig)
                    throw new Exception("No se ha definido la configuración");

                // this._consultasFBNegocio = new ConsultasFBNegocio();

                if (this.cmbAlmacen.SelectedIndex == -1)
                    throw new Exception("Seleccione un Almacen");

                long almacenId = (long)this.cmbAlmacen.SelectedValue;

                // consulta articulos de microsip
                this._articulos = this._consultasFBNegocio.obtieneArticulos(almacenId);

                this.gcArticulos.DataSource = this._articulos;

                this.gridView1.BestFitColumns();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Calcular Costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgrega_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this._defConfig)
                    throw new Exception("No se ha definido la configuración");

                this.tbTotal.Text = string.Empty;

                // obtiene los articulos seleccionadas del grid de articulos
                List<Modelos.Articulos> seleccionados = 
                    ((List<Modelos.Articulos>)this.gridView1.DataSource).Where(w => w.seleccionado == true).Select(s => s).ToList();

                if (seleccionados.Count == 0) return;

                // obtiene los articulos agregados
                List<Modelos.Articulos> agregados = ((List<Modelos.Articulos>)this.gridView2.DataSource).ToList();

                foreach (Modelos.Articulos art in seleccionados)
                {
                    if (agregados.Where(w => w.articuloId == art.articuloId).ToList().Count == 0)
                    {
                        agregados.Add(new Modelos.Articulos
                        {
                            articulo = art.articulo,
                            articuloId = art.articuloId,
                            costo = art.costo,
                            cvearticulo = art.cvearticulo,
                            estatus = art.estatus,
                            seleccionado = false
                        });
                    }
                }

                this.gcCalcCosto.DataSource = null;
                this.gcCalcCosto.DataSource = agregados;

                RepositoryItemTextEdit edit = new RepositoryItemTextEdit();
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.Mask.EditMask = "###,##0.0###";
                this.gcCalcCosto.RepositoryItems.Add(edit);
                gridView2.Columns["calculo"].ColumnEdit = edit;


                this.gridView2.BestFitColumns();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Calcular Costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnQuita_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this._defConfig)
                    throw new Exception("No se ha definido la configuración");

                this.tbTotal.Text = string.Empty;

                // obtiene los articulos seleccionadas del grid de articulos
                List<Modelos.Articulos> seleccionados = 
                    ((List<Modelos.Articulos>)this.gridView2.DataSource).Where(w => w.seleccionado == false).Select(s => s).ToList();

                if (seleccionados.Count == 0)
                    if (((List<Modelos.Articulos>)this.gridView2.DataSource).Count > 1) return;
                    else
                        this.gcCalcCosto.DataSource = new List<Modelos.Articulos>();

                this.gcCalcCosto.DataSource = null;
                this.gcCalcCosto.DataSource = seleccionados;

                this.gridView2.BestFitColumns();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Calcular Costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnQuitarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this._defConfig)
                    throw new Exception("No se ha definido la configuración");

                this.tbTotal.Text = string.Empty;
                this.gcCalcCosto.DataSource = new List<Modelos.Articulos>();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Calcular Costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this._defConfig)
                    throw new Exception("No se ha definido la configuración");

                List<Modelos.Articulos> seleccionados =
                    ((List<Modelos.Articulos>)this.gridView2.DataSource).Select(s => s).ToList();

                decimal total = 0;

                foreach (Modelos.Articulos sel in seleccionados)
                {
                    decimal calculo = (sel.costo ?? 0) * sel.calculo;

                    total += calculo;
                }

                decimal partes = total / this.nudDivPiezas.Value;

                this.tbTotal.Text = partes.ToString("C", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Calcular Costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }
}
