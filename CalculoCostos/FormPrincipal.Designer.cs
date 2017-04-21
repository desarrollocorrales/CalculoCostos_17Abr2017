namespace CalculoCostos
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnCargaArt = new System.Windows.Forms.Button();
            this.gcArticulos = new DevExpress.XtraGrid.GridControl();
            this.articulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colseleccionado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colarticuloId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcvearticulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colarticulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colestatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcostoUltCom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAgrega = new System.Windows.Forms.Button();
            this.btnQuita = new System.Windows.Forms.Button();
            this.btnQuitarTodos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.gcCalcCosto = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colseleccionado1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colarticuloId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcvearticulo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colarticulo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colestatus1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcostoUltCom1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.calculo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbAlmacen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudDivPiezas = new System.Windows.Forms.NumericUpDown();
            this.btnImpresion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCalcCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDivPiezas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 22F);
            this.label1.Location = new System.Drawing.Point(78, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cálculo de Costos";
            // 
            // btnConfig
            // 
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.Location = new System.Drawing.Point(12, 12);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(60, 60);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnCargaArt
            // 
            this.btnCargaArt.Location = new System.Drawing.Point(841, 23);
            this.btnCargaArt.Name = "btnCargaArt";
            this.btnCargaArt.Size = new System.Drawing.Size(250, 38);
            this.btnCargaArt.TabIndex = 2;
            this.btnCargaArt.Text = "Cargar Artículos";
            this.btnCargaArt.UseVisualStyleBackColor = true;
            this.btnCargaArt.Click += new System.EventHandler(this.btnCargaArt_Click);
            // 
            // gcArticulos
            // 
            this.gcArticulos.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcArticulos.DataSource = this.articulosBindingSource;
            this.gcArticulos.Location = new System.Drawing.Point(12, 78);
            this.gcArticulos.MainView = this.gridView1;
            this.gcArticulos.Name = "gcArticulos";
            this.gcArticulos.Size = new System.Drawing.Size(583, 407);
            this.gcArticulos.TabIndex = 3;
            this.gcArticulos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // articulosBindingSource
            // 
            this.articulosBindingSource.DataSource = typeof(CalculoCostos.Modelos.Articulos);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colseleccionado,
            this.colarticuloId,
            this.colcvearticulo,
            this.colarticulo,
            this.colestatus,
            this.colcostoUltCom});
            this.gridView1.GridControl = this.gcArticulos;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Artículos";
            // 
            // colseleccionado
            // 
            this.colseleccionado.Caption = " ";
            this.colseleccionado.FieldName = "seleccionado";
            this.colseleccionado.Name = "colseleccionado";
            this.colseleccionado.Visible = true;
            this.colseleccionado.VisibleIndex = 0;
            this.colseleccionado.Width = 30;
            // 
            // colarticuloId
            // 
            this.colarticuloId.FieldName = "articuloId";
            this.colarticuloId.Name = "colarticuloId";
            // 
            // colcvearticulo
            // 
            this.colcvearticulo.Caption = "Clave";
            this.colcvearticulo.FieldName = "cvearticulo";
            this.colcvearticulo.Name = "colcvearticulo";
            this.colcvearticulo.OptionsColumn.AllowEdit = false;
            this.colcvearticulo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colcvearticulo.Visible = true;
            this.colcvearticulo.VisibleIndex = 1;
            // 
            // colarticulo
            // 
            this.colarticulo.Caption = "Artículo";
            this.colarticulo.FieldName = "articulo";
            this.colarticulo.Name = "colarticulo";
            this.colarticulo.OptionsColumn.AllowEdit = false;
            this.colarticulo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colarticulo.Visible = true;
            this.colarticulo.VisibleIndex = 2;
            // 
            // colestatus
            // 
            this.colestatus.FieldName = "estatus";
            this.colestatus.Name = "colestatus";
            // 
            // colcostoUltCom
            // 
            this.colcostoUltCom.Caption = "Costo";
            this.colcostoUltCom.FieldName = "costo";
            this.colcostoUltCom.Name = "colcostoUltCom";
            this.colcostoUltCom.OptionsColumn.AllowEdit = false;
            this.colcostoUltCom.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colcostoUltCom.Visible = true;
            this.colcostoUltCom.VisibleIndex = 3;
            // 
            // btnAgrega
            // 
            this.btnAgrega.Image = ((System.Drawing.Image)(resources.GetObject("btnAgrega.Image")));
            this.btnAgrega.Location = new System.Drawing.Point(601, 155);
            this.btnAgrega.Name = "btnAgrega";
            this.btnAgrega.Size = new System.Drawing.Size(45, 45);
            this.btnAgrega.TabIndex = 5;
            this.btnAgrega.UseVisualStyleBackColor = true;
            this.btnAgrega.Click += new System.EventHandler(this.btnAgrega_Click);
            // 
            // btnQuita
            // 
            this.btnQuita.Image = ((System.Drawing.Image)(resources.GetObject("btnQuita.Image")));
            this.btnQuita.Location = new System.Drawing.Point(601, 206);
            this.btnQuita.Name = "btnQuita";
            this.btnQuita.Size = new System.Drawing.Size(45, 45);
            this.btnQuita.TabIndex = 6;
            this.btnQuita.UseVisualStyleBackColor = true;
            this.btnQuita.Click += new System.EventHandler(this.btnQuita_Click);
            // 
            // btnQuitarTodos
            // 
            this.btnQuitarTodos.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarTodos.Image")));
            this.btnQuitarTodos.Location = new System.Drawing.Point(601, 257);
            this.btnQuitarTodos.Name = "btnQuitarTodos";
            this.btnQuitarTodos.Size = new System.Drawing.Size(45, 45);
            this.btnQuitarTodos.TabIndex = 7;
            this.btnQuitarTodos.UseVisualStyleBackColor = true;
            this.btnQuitarTodos.Click += new System.EventHandler(this.btnQuitarTodos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(798, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Costo Total";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(906, 455);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(185, 30);
            this.tbTotal.TabIndex = 10;
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(959, 411);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(120, 38);
            this.btnCalcular.TabIndex = 11;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // gcCalcCosto
            // 
            this.gcCalcCosto.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcCalcCosto.DataSource = this.articulosBindingSource;
            this.gcCalcCosto.Location = new System.Drawing.Point(652, 78);
            this.gcCalcCosto.MainView = this.gridView2;
            this.gcCalcCosto.Name = "gcCalcCosto";
            this.gcCalcCosto.Size = new System.Drawing.Size(439, 281);
            this.gcCalcCosto.TabIndex = 12;
            this.gcCalcCosto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colseleccionado1,
            this.colarticuloId1,
            this.colcvearticulo1,
            this.colarticulo1,
            this.colestatus1,
            this.colcostoUltCom1,
            this.calculo});
            this.gridView2.GridControl = this.gcCalcCosto;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowViewCaption = true;
            this.gridView2.ViewCaption = "Cálculo Costo";
            // 
            // colseleccionado1
            // 
            this.colseleccionado1.Caption = " ";
            this.colseleccionado1.FieldName = "seleccionado";
            this.colseleccionado1.Name = "colseleccionado1";
            this.colseleccionado1.Visible = true;
            this.colseleccionado1.VisibleIndex = 0;
            this.colseleccionado1.Width = 30;
            // 
            // colarticuloId1
            // 
            this.colarticuloId1.FieldName = "articuloId";
            this.colarticuloId1.Name = "colarticuloId1";
            // 
            // colcvearticulo1
            // 
            this.colcvearticulo1.Caption = "Clave";
            this.colcvearticulo1.FieldName = "cvearticulo";
            this.colcvearticulo1.Name = "colcvearticulo1";
            this.colcvearticulo1.OptionsColumn.AllowEdit = false;
            this.colcvearticulo1.Visible = true;
            this.colcvearticulo1.VisibleIndex = 1;
            // 
            // colarticulo1
            // 
            this.colarticulo1.Caption = "Artículo";
            this.colarticulo1.FieldName = "articulo";
            this.colarticulo1.Name = "colarticulo1";
            this.colarticulo1.OptionsColumn.AllowEdit = false;
            this.colarticulo1.Visible = true;
            this.colarticulo1.VisibleIndex = 2;
            // 
            // colestatus1
            // 
            this.colestatus1.FieldName = "estatus";
            this.colestatus1.Name = "colestatus1";
            // 
            // colcostoUltCom1
            // 
            this.colcostoUltCom1.Caption = "Costo";
            this.colcostoUltCom1.FieldName = "costo";
            this.colcostoUltCom1.Name = "colcostoUltCom1";
            this.colcostoUltCom1.OptionsColumn.AllowEdit = false;
            this.colcostoUltCom1.Visible = true;
            this.colcostoUltCom1.VisibleIndex = 3;
            // 
            // calculo
            // 
            this.calculo.AppearanceCell.Options.UseTextOptions = true;
            this.calculo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.calculo.AppearanceHeader.Options.UseTextOptions = true;
            this.calculo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.calculo.Caption = "Cantidad";
            this.calculo.FieldName = "calculo";
            this.calculo.Name = "calculo";
            this.calculo.Visible = true;
            this.calculo.VisibleIndex = 4;
            // 
            // cmbAlmacen
            // 
            this.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlmacen.DropDownWidth = 600;
            this.cmbAlmacen.FormattingEnabled = true;
            this.cmbAlmacen.Location = new System.Drawing.Point(496, 28);
            this.cmbAlmacen.Name = "cmbAlmacen";
            this.cmbAlmacen.Size = new System.Drawing.Size(339, 31);
            this.cmbAlmacen.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Almacen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(856, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Dividir en partes:";
            // 
            // nudDivPiezas
            // 
            this.nudDivPiezas.Location = new System.Drawing.Point(1016, 365);
            this.nudDivPiezas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDivPiezas.Name = "nudDivPiezas";
            this.nudDivPiezas.ReadOnly = true;
            this.nudDivPiezas.Size = new System.Drawing.Size(75, 30);
            this.nudDivPiezas.TabIndex = 17;
            this.nudDivPiezas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDivPiezas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnImpresion
            // 
            this.btnImpresion.Location = new System.Drawing.Point(652, 447);
            this.btnImpresion.Name = "btnImpresion";
            this.btnImpresion.Size = new System.Drawing.Size(126, 38);
            this.btnImpresion.TabIndex = 18;
            this.btnImpresion.Text = "Impresión";
            this.btnImpresion.UseVisualStyleBackColor = true;
            this.btnImpresion.Click += new System.EventHandler(this.btnImpresion_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 497);
            this.Controls.Add(this.btnImpresion);
            this.Controls.Add(this.nudDivPiezas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAlmacen);
            this.Controls.Add(this.gcCalcCosto);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnQuitarTodos);
            this.Controls.Add(this.btnQuita);
            this.Controls.Add(this.btnAgrega);
            this.Controls.Add(this.gcArticulos);
            this.Controls.Add(this.btnCargaArt);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cálculo de Costos";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCalcCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDivPiezas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnCargaArt;
        private DevExpress.XtraGrid.GridControl gcArticulos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnAgrega;
        private System.Windows.Forms.Button btnQuita;
        private System.Windows.Forms.Button btnQuitarTodos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.BindingSource articulosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colseleccionado;
        private DevExpress.XtraGrid.Columns.GridColumn colarticuloId;
        private DevExpress.XtraGrid.Columns.GridColumn colcvearticulo;
        private DevExpress.XtraGrid.Columns.GridColumn colarticulo;
        private DevExpress.XtraGrid.Columns.GridColumn colestatus;
        private DevExpress.XtraGrid.Columns.GridColumn colcostoUltCom;
        private System.Windows.Forms.Button btnCalcular;
        private DevExpress.XtraGrid.GridControl gcCalcCosto;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colseleccionado1;
        private DevExpress.XtraGrid.Columns.GridColumn colarticuloId1;
        private DevExpress.XtraGrid.Columns.GridColumn colcvearticulo1;
        private DevExpress.XtraGrid.Columns.GridColumn colarticulo1;
        private DevExpress.XtraGrid.Columns.GridColumn colestatus1;
        private DevExpress.XtraGrid.Columns.GridColumn colcostoUltCom1;
        private DevExpress.XtraGrid.Columns.GridColumn calculo;
        private System.Windows.Forms.ComboBox cmbAlmacen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudDivPiezas;
        private System.Windows.Forms.Button btnImpresion;
    }
}

