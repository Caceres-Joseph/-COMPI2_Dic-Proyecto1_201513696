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
            this.MetroTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MetroTab
            // 
            this.MetroTab.Controls.Add(this.tabConsola);
            this.MetroTab.Controls.Add(this.tabPly);
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
            this.btnStart.Location = new System.Drawing.Point(465, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 34);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnStart.UseSelectable = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(577, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 34);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseSelectable = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnGrafo
            // 
            this.btnGrafo.Location = new System.Drawing.Point(670, 20);
            this.btnGrafo.Name = "btnGrafo";
            this.btnGrafo.Size = new System.Drawing.Size(86, 34);
            this.btnGrafo.TabIndex = 7;
            this.btnGrafo.Text = "Grafo";
            this.btnGrafo.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnGrafo.UseSelectable = true;
            this.btnGrafo.Click += new System.EventHandler(this.btnGrafo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 588);
            this.Controls.Add(this.btnGrafo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.MetroTab);
            this.Name = "Form1";
            this.Text = "DBMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MetroTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTabControl MetroTab;
        private MetroFramework.Controls.MetroTabPage tabConsola;
        private MetroFramework.Controls.MetroTabPage tabPly;
        private MetroFramework.Controls.MetroButton btnStart;
        private MetroFramework.Controls.MetroButton btnStop;
        private MetroFramework.Controls.MetroButton btnGrafo;
    }
}

