namespace DBMS
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.MetroTab = new MetroFramework.Controls.MetroTabControl();
            this.tabConsola = new MetroFramework.Controls.MetroTabPage();
            this.tabPly = new MetroFramework.Controls.MetroTabPage();
            this.btnStart = new MetroFramework.Controls.MetroButton();
            this.btnStop = new MetroFramework.Controls.MetroButton();
            this.btnGrafo = new MetroFramework.Controls.MetroButton();
            this.button1 = new System.Windows.Forms.Button();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.btnAnalizarXml = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtXml = new System.Windows.Forms.RichTextBox();
            this.btnCargaInicial = new MetroFramework.Controls.MetroButton();
            this.txtReset = new MetroFramework.Controls.MetroButton();
            this.MetroTab.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MetroTab
            // 
            this.MetroTab.Controls.Add(this.tabConsola);
            this.MetroTab.Controls.Add(this.tabPly);
            this.MetroTab.Controls.Add(this.metroTabPage1);
            this.MetroTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetroTab.Location = new System.Drawing.Point(20, 60);
            this.MetroTab.Name = "MetroTab";
            this.MetroTab.SelectedIndex = 0;
            this.MetroTab.Size = new System.Drawing.Size(1025, 508);
            this.MetroTab.Style = MetroFramework.MetroColorStyle.Yellow;
            this.MetroTab.TabIndex = 4;
            this.MetroTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.MetroTab.UseSelectable = true;
            // 
            // tabConsola
            // 
            this.tabConsola.HorizontalScrollbarBarColor = true;
            this.tabConsola.HorizontalScrollbarHighlightOnWheel = false;
            this.tabConsola.HorizontalScrollbarSize = 10;
            this.tabConsola.Location = new System.Drawing.Point(4, 38);
            this.tabConsola.Name = "tabConsola";
            this.tabConsola.Size = new System.Drawing.Size(1017, 466);
            this.tabConsola.TabIndex = 0;
            this.tabConsola.Text = "Consola";
            this.tabConsola.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tabConsola.VerticalScrollbarBarColor = true;
            this.tabConsola.VerticalScrollbarHighlightOnWheel = false;
            this.tabConsola.VerticalScrollbarSize = 10;
            this.tabConsola.Click += new System.EventHandler(this.metroTabPage1_Click);
            // 
            // tabPly
            // 
            this.tabPly.HorizontalScrollbarBarColor = true;
            this.tabPly.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPly.HorizontalScrollbarSize = 10;
            this.tabPly.Location = new System.Drawing.Point(4, 38);
            this.tabPly.Name = "tabPly";
            this.tabPly.Size = new System.Drawing.Size(1017, 466);
            this.tabPly.TabIndex = 1;
            this.tabPly.Text = "PlyCs";
            this.tabPly.VerticalScrollbarBarColor = true;
            this.tabPly.VerticalScrollbarHighlightOnWheel = false;
            this.tabPly.VerticalScrollbarSize = 10;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(217, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 34);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnStart.UseSelectable = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(321, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 34);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseSelectable = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnGrafo
            // 
            this.btnGrafo.Location = new System.Drawing.Point(414, 20);
            this.btnGrafo.Name = "btnGrafo";
            this.btnGrafo.Size = new System.Drawing.Size(87, 34);
            this.btnGrafo.TabIndex = 7;
            this.btnGrafo.Text = "Grafo";
            this.btnGrafo.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnGrafo.UseSelectable = true;
            this.btnGrafo.Click += new System.EventHandler(this.btnGrafo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(599, 20);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(87, 34);
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Salir";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.splitContainer1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1017, 466);
            this.metroTabPage1.TabIndex = 2;
            this.metroTabPage1.Text = "Xml";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            this.metroTabPage1.Click += new System.EventHandler(this.metroTabPage1_Click_1);
            // 
            // btnAnalizarXml
            // 
            this.btnAnalizarXml.Location = new System.Drawing.Point(283, 15);
            this.btnAnalizarXml.Name = "btnAnalizarXml";
            this.btnAnalizarXml.Size = new System.Drawing.Size(75, 23);
            this.btnAnalizarXml.TabIndex = 2;
            this.btnAnalizarXml.Text = "Analizar";
            this.btnAnalizarXml.UseVisualStyleBackColor = true;
            this.btnAnalizarXml.Click += new System.EventHandler(this.btnAnalizarXml_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnAnalizarXml);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtXml);
            this.splitContainer1.Size = new System.Drawing.Size(1017, 466);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 4;
            // 
            // txtXml
            // 
            this.txtXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXml.Location = new System.Drawing.Point(0, 0);
            this.txtXml.Name = "txtXml";
            this.txtXml.Size = new System.Drawing.Size(1017, 422);
            this.txtXml.TabIndex = 4;
            this.txtXml.Text = "";
            // 
            // btnCargaInicial
            // 
            this.btnCargaInicial.Location = new System.Drawing.Point(506, 20);
            this.btnCargaInicial.Name = "btnCargaInicial";
            this.btnCargaInicial.Size = new System.Drawing.Size(87, 34);
            this.btnCargaInicial.TabIndex = 10;
            this.btnCargaInicial.Text = "Xml";
            this.btnCargaInicial.UseSelectable = true;
            this.btnCargaInicial.Click += new System.EventHandler(this.btnCargaInicial_Click);
            // 
            // txtReset
            // 
            this.txtReset.Location = new System.Drawing.Point(692, 20);
            this.txtReset.Name = "txtReset";
            this.txtReset.Size = new System.Drawing.Size(95, 34);
            this.txtReset.TabIndex = 11;
            this.txtReset.Text = "Reset DBMS";
            this.txtReset.UseSelectable = true;
            this.txtReset.Click += new System.EventHandler(this.txtReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 588);
            this.Controls.Add(this.txtReset);
            this.Controls.Add(this.btnCargaInicial);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGrafo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.MetroTab);
            this.Name = "Form1";
            this.Text = "DBMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MetroTab.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTabControl MetroTab;
        private MetroFramework.Controls.MetroTabPage tabConsola;
        private MetroFramework.Controls.MetroTabPage tabPly;
        private MetroFramework.Controls.MetroButton btnStart;
        private MetroFramework.Controls.MetroButton btnStop;
        private MetroFramework.Controls.MetroButton btnGrafo;
        private System.Windows.Forms.Button button1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAnalizarXml;
        private System.Windows.Forms.RichTextBox txtXml;
        private MetroFramework.Controls.MetroButton btnCargaInicial;
        private MetroFramework.Controls.MetroButton txtReset;
    }
}

