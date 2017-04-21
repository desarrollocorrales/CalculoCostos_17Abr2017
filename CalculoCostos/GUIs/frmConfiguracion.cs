using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CalculoCostos.Negocio;

namespace CalculoCostos.GUIs
{
    public partial class frmConfiguracion : Form
    {
        private string _path = string.Empty;
        private IConsultasFBNegocio _consultasFBNegocio;

        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                string fileName = "config.dat";
                string pathConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CalcCostos\";

                // si no existe el directorio, lo crea
                bool exists = System.IO.Directory.Exists(pathConfigFile);

                if (!exists) System.IO.Directory.CreateDirectory(pathConfigFile);

                // busca en el directorio si exite el archivo con el nombre dado
                var file = Directory.GetFiles(pathConfigFile, fileName, SearchOption.AllDirectories)
                        .FirstOrDefault();

                this._path = pathConfigFile + fileName;

                if (file != null)
                {
                    // si existe
                    // cargar los datos en los campos
                    FEncrypt.Respuesta result = FEncrypt.EncryptDncrypt.DecryptFile(this._path, "milagros");

                    if (result.status == FEncrypt.Estatus.ERROR)
                        throw new Exception(result.error);

                    if (result.status == FEncrypt.Estatus.OK)
                    {
                        string[] list = result.resultado.Split(new string[] { "||" }, StringSplitOptions.None);

                        if (list.Count() < 5)
                        {
                            foreach (Control x in this.Controls)
                            {
                                if (x is TextBox)
                                {
                                    ((TextBox)x).Text = string.Empty;
                                }
                            }
                        }
                        else
                        {
                            // MICROSIP
                            this.tbServidorM.Text = list[0].Substring(2);       // SERVIDOR
                            this.tbUsuarioM.Text = list[1].Substring(2);        // USUARIO
                            this.tbContraseniaM.Text = list[2].Substring(2);    // CONTRASEÑA
                            this.tbPuertoM.Text = list[3].Substring(2);         // PUERTO
                            this.tbBaseDatosM.Text = list[4].Substring(2);      // BASE DE DATOS

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnProbarConnMicrosip_Click(object sender, EventArgs e)
        {
            try
            {
                Modelos.ConectionString.connFB = string.Format(
                            "User={0};Password={1};Database={2};DataSource={3};Port={4}",
                            this.tbUsuarioM.Text,
                            this.tbContraseniaM.Text,
                            this.tbBaseDatosM.Text,
                            this.tbServidorM.Text,
                            this.tbPuertoM.Text);

                this._consultasFBNegocio = new ConsultasFBNegocio();

                bool pruebaConn = this._consultasFBNegocio.pruebaConn();

                if (pruebaConn)
                    MessageBox.Show("Conexión Exitosa!!!", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    throw new Exception("Falló la conexión a la base de datos del Microsip");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // validaciones
                foreach (Control x in this.groupBox1.Controls)
                {
                    if (x is TextBox)
                    {
                        if (string.IsNullOrEmpty(((TextBox)x).Text))
                            throw new Exception("Campos incompletos, Por favor verifique");
                    }
                }


                // define texto del archivo
                string cadena = string.Empty;

                // MICROSIP
                cadena += "S_" + this.tbServidorM.Text + "||";
                cadena += "U_" + this.tbUsuarioM.Text + "||";
                cadena += "C_" + this.tbContraseniaM.Text + "||";
                cadena += "P_" + this.tbPuertoM.Text + "||";
                cadena += "B_" + this.tbBaseDatosM.Text + "||";

                // prosigue con la creación del archivo
                FEncrypt.Respuesta result = FEncrypt.EncryptDncrypt.EncryptFile("milagros", cadena, this._path);

                if (result.status == FEncrypt.Estatus.ERROR)
                    throw new Exception(result.error);

                if (result.status == FEncrypt.Estatus.OK)
                {
                    // firebird
                    Modelos.ConectionString.connFB = string.Format(
                                "User={0};Password={1};Database={2};DataSource={3};Port={4}",
                                this.tbUsuarioM.Text,
                                this.tbContraseniaM.Text,
                                this.tbBaseDatosM.Text,
                                this.tbServidorM.Text,
                                this.tbPuertoM.Text);

                    MessageBox.Show("Se cargó correctamente la información", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
