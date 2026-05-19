namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTipoArtigos = new System.Windows.Forms.Button();
            this.btnArtigo = new System.Windows.Forms.Button();
            this.btnOrcamentos = new System.Windows.Forms.Button();
            this.btnEstatisticas = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnModoCompra = new System.Windows.Forms.Button();
            this.btnPlaneamento = new System.Windows.Forms.Button();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelComprimento = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTipoArtigos
            // 
            this.btnTipoArtigos.Location = new System.Drawing.Point(6, 23);
            this.btnTipoArtigos.Name = "btnTipoArtigos";
            this.btnTipoArtigos.Size = new System.Drawing.Size(120, 49);
            this.btnTipoArtigos.TabIndex = 0;
            this.btnTipoArtigos.Text = "Tipos de artigo";
            this.btnTipoArtigos.UseVisualStyleBackColor = true;
            this.btnTipoArtigos.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnArtigo
            // 
            this.btnArtigo.Location = new System.Drawing.Point(134, 23);
            this.btnArtigo.Name = "btnArtigo";
            this.btnArtigo.Size = new System.Drawing.Size(120, 49);
            this.btnArtigo.TabIndex = 0;
            this.btnArtigo.Text = "Artigos";
            this.btnArtigo.UseVisualStyleBackColor = true;
            this.btnArtigo.Click += new System.EventHandler(this.btnArtigo_Click);
            // 
            // btnOrcamentos
            // 
            this.btnOrcamentos.Location = new System.Drawing.Point(262, 23);
            this.btnOrcamentos.Name = "btnOrcamentos";
            this.btnOrcamentos.Size = new System.Drawing.Size(120, 49);
            this.btnOrcamentos.TabIndex = 0;
            this.btnOrcamentos.Text = "Orçamentos";
            this.btnOrcamentos.UseVisualStyleBackColor = true;
            this.btnOrcamentos.Click += new System.EventHandler(this.btnOrcamentos_Click);
            // 
            // btnEstatisticas
            // 
            this.btnEstatisticas.Location = new System.Drawing.Point(6, 91);
            this.btnEstatisticas.Name = "btnEstatisticas";
            this.btnEstatisticas.Size = new System.Drawing.Size(376, 49);
            this.btnEstatisticas.TabIndex = 0;
            this.btnEstatisticas.Text = "Estatisticas";
            this.btnEstatisticas.UseVisualStyleBackColor = true;
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(393, 91);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(376, 49);
            this.btnCSV.TabIndex = 1;
            this.btnCSV.Text = "Exportar CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            // 
            // btnModoCompra
            // 
            this.btnModoCompra.Location = new System.Drawing.Point(649, 23);
            this.btnModoCompra.Name = "btnModoCompra";
            this.btnModoCompra.Size = new System.Drawing.Size(120, 49);
            this.btnModoCompra.TabIndex = 2;
            this.btnModoCompra.Text = "Modo Compra";
            this.btnModoCompra.UseVisualStyleBackColor = true;
            // 
            // btnPlaneamento
            // 
            this.btnPlaneamento.Location = new System.Drawing.Point(521, 23);
            this.btnPlaneamento.Name = "btnPlaneamento";
            this.btnPlaneamento.Size = new System.Drawing.Size(120, 49);
            this.btnPlaneamento.TabIndex = 3;
            this.btnPlaneamento.Text = "Planeamento";
            this.btnPlaneamento.UseVisualStyleBackColor = true;
            // 
            // btnHistorico
            // 
            this.btnHistorico.Location = new System.Drawing.Point(393, 23);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(120, 49);
            this.btnHistorico.TabIndex = 4;
            this.btnHistorico.Text = "Historico Orçamento";
            this.btnHistorico.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCSV);
            this.groupBox1.Controls.Add(this.btnTipoArtigos);
            this.groupBox1.Controls.Add(this.btnModoCompra);
            this.groupBox1.Controls.Add(this.btnArtigo);
            this.groupBox1.Controls.Add(this.btnPlaneamento);
            this.groupBox1.Controls.Add(this.btnOrcamentos);
            this.groupBox1.Controls.Add(this.btnHistorico);
            this.groupBox1.Controls.Add(this.btnEstatisticas);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 165);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acesso rápido";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 214);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compras em aberto";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(763, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // labelComprimento
            // 
            this.labelComprimento.AutoSize = true;
            this.labelComprimento.Location = new System.Drawing.Point(15, 24);
            this.labelComprimento.Name = "labelComprimento";
            this.labelComprimento.Size = new System.Drawing.Size(553, 16);
            this.labelComprimento.TabIndex = 7;
            this.labelComprimento.Text = "Bem vindo/a. Tens 3 compras em aberto este mês. Orçamento disponivel: xxx.xx€ de " +
    "xxx.xx€";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(622, 21);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(166, 23);
            this.button9.TabIndex = 8;
            this.button9.Text = "Terminar Sessão";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.labelComprimento);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTipoArtigos;
        private System.Windows.Forms.Button btnArtigo;
        private System.Windows.Forms.Button btnEstatisticas;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.Button btnModoCompra;
        private System.Windows.Forms.Button btnPlaneamento;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelComprimento;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnOrcamentos;
    }
}