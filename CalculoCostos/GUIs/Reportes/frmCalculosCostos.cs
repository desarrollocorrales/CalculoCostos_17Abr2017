using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CalculoCostos.GUIs.Reportes
{
    public partial class frmCalculosCostos : Form
    {
        public decimal _costoTotal;
        public int _partes;

        public List<Modelos.Articulos> _articulos = new List<Modelos.Articulos>();

        public frmCalculosCostos()
        {
            InitializeComponent();
        }

        private void frmCalculosCostos_Load(object sender, EventArgs e)
        {
            //Limpiemos el DataSource del informe
            reportViewer1.LocalReport.DataSources.Clear();
            //
            //Establezcamos los parámetros que enviaremos al reporte
            //recuerde que son dos para el titulo del reporte y para el nombre de la empresa
            //
            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("pCostoTotal", Convert.ToString(Math.Round(this._costoTotal, 2)));
            parameters[1] = new ReportParameter("pPartes", Convert.ToString(this._partes));
            //
            //Establezcamos la lista como Datasource del informe
            //
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCalcDatos", this._articulos));
            //
            //Enviemos la lista de parametros
            //
            reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.RefreshReport();
        }

        private void frmCalculosCostos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
