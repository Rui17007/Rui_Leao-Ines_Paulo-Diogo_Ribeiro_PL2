namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views
{
    partial class ModoCompra
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
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.progressbar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOrcamentoData = new System.Windows.Forms.Label();
            this.txtOrcamentoDinheiro = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalQuantidade = new System.Windows.Forms.Label();
            this.txtTotalDinheiro = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtGasto = new System.Windows.Forms.Label();
            this.txtGastoDinheiro = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRestante = new System.Windows.Forms.Label();
            this.txtRestanteDinheiro = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelQuantidade = new System.Windows.Forms.Label();
            this.cbTipoArtigo = new System.Windows.Forms.ComboBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.labelTipo = new System.Windows.Forms.Label();
            this.txtNomeArtigo = new System.Windows.Forms.TextBox();
            this.labelNomeArtigo = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.Location = new System.Drawing.Point(11, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Voltar para o menu inicial";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Percentagem utilizada";
            // 
            // progressbar
            // 
            this.progressbar.ForeColor = System.Drawing.Color.Chartreuse;
            this.progressbar.Location = new System.Drawing.Point(11, 153);
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(777, 23);
            this.progressbar.Step = 2;
            this.progressbar.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOrcamentoData);
            this.groupBox1.Controls.Add(this.txtOrcamentoDinheiro);
            this.groupBox1.Location = new System.Drawing.Point(9, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 85);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orçamento do Mês";
            // 
            // txtOrcamentoData
            // 
            this.txtOrcamentoData.AutoSize = true;
            this.txtOrcamentoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrcamentoData.Location = new System.Drawing.Point(10, 57);
            this.txtOrcamentoData.Name = "txtOrcamentoData";
            this.txtOrcamentoData.Size = new System.Drawing.Size(72, 15);
            this.txtOrcamentoData.TabIndex = 1;
            this.txtOrcamentoData.Text = "Junho 2026";
            // 
            // txtOrcamentoDinheiro
            // 
            this.txtOrcamentoDinheiro.AutoSize = true;
            this.txtOrcamentoDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrcamentoDinheiro.Location = new System.Drawing.Point(48, 22);
            this.txtOrcamentoDinheiro.Name = "txtOrcamentoDinheiro";
            this.txtOrcamentoDinheiro.Size = new System.Drawing.Size(87, 33);
            this.txtOrcamentoDinheiro.TabIndex = 0;
            this.txtOrcamentoDinheiro.Text = "0.00€";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTotalQuantidade);
            this.groupBox2.Controls.Add(this.txtTotalDinheiro);
            this.groupBox2.Location = new System.Drawing.Point(207, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 85);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total desta Compra";
            // 
            // txtTotalQuantidade
            // 
            this.txtTotalQuantidade.AutoSize = true;
            this.txtTotalQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQuantidade.Location = new System.Drawing.Point(10, 57);
            this.txtTotalQuantidade.Name = "txtTotalQuantidade";
            this.txtTotalQuantidade.Size = new System.Drawing.Size(43, 15);
            this.txtTotalQuantidade.TabIndex = 1;
            this.txtTotalQuantidade.Text = "0 itens";
            // 
            // txtTotalDinheiro
            // 
            this.txtTotalDinheiro.AutoSize = true;
            this.txtTotalDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDinheiro.Location = new System.Drawing.Point(48, 22);
            this.txtTotalDinheiro.Name = "txtTotalDinheiro";
            this.txtTotalDinheiro.Size = new System.Drawing.Size(87, 33);
            this.txtTotalDinheiro.TabIndex = 0;
            this.txtTotalDinheiro.Text = "0.00€";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtGasto);
            this.groupBox3.Controls.Add(this.txtGastoDinheiro);
            this.groupBox3.Location = new System.Drawing.Point(405, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 85);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Já Gasto no Mês";
            // 
            // txtGasto
            // 
            this.txtGasto.AutoSize = true;
            this.txtGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGasto.Location = new System.Drawing.Point(10, 57);
            this.txtGasto.Name = "txtGasto";
            this.txtGasto.Size = new System.Drawing.Size(145, 15);
            this.txtGasto.TabIndex = 1;
            this.txtGasto.Text = "Inclui compras anteriores";
            // 
            // txtGastoDinheiro
            // 
            this.txtGastoDinheiro.AutoSize = true;
            this.txtGastoDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastoDinheiro.Location = new System.Drawing.Point(48, 22);
            this.txtGastoDinheiro.Name = "txtGastoDinheiro";
            this.txtGastoDinheiro.Size = new System.Drawing.Size(87, 33);
            this.txtGastoDinheiro.TabIndex = 0;
            this.txtGastoDinheiro.Text = "0.00€";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRestante);
            this.groupBox4.Controls.Add(this.txtRestanteDinheiro);
            this.groupBox4.Location = new System.Drawing.Point(603, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(187, 85);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Restante";
            // 
            // txtRestante
            // 
            this.txtRestante.AutoSize = true;
            this.txtRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestante.Location = new System.Drawing.Point(10, 57);
            this.txtRestante.Name = "txtRestante";
            this.txtRestante.Size = new System.Drawing.Size(125, 15);
            this.txtRestante.TabIndex = 1;
            this.txtRestante.Text = "Dentro do Orçamento";
            // 
            // txtRestanteDinheiro
            // 
            this.txtRestanteDinheiro.AutoSize = true;
            this.txtRestanteDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestanteDinheiro.Location = new System.Drawing.Point(48, 22);
            this.txtRestanteDinheiro.Name = "txtRestanteDinheiro";
            this.txtRestanteDinheiro.Size = new System.Drawing.Size(87, 33);
            this.txtRestanteDinheiro.TabIndex = 0;
            this.txtRestanteDinheiro.Text = "0.00€";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAdicionar);
            this.groupBox5.Controls.Add(this.txtPreco);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.labelQuantidade);
            this.groupBox5.Controls.Add(this.cbTipoArtigo);
            this.groupBox5.Controls.Add(this.txtQuantidade);
            this.groupBox5.Controls.Add(this.labelTipo);
            this.groupBox5.Controls.Add(this.txtNomeArtigo);
            this.groupBox5.Controls.Add(this.labelNomeArtigo);
            this.groupBox5.Location = new System.Drawing.Point(9, 183);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(781, 81);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Adicionar artigo não previsto";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(555, 44);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(202, 23);
            this.btnAdicionar.TabIndex = 8;
            this.btnAdicionar.Text = "Adicionar Item não Previsto";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(418, 45);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(116, 22);
            this.txtPreco.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Preço Unitário (€)";
            // 
            // labelQuantidade
            // 
            this.labelQuantidade.AutoSize = true;
            this.labelQuantidade.Location = new System.Drawing.Point(278, 22);
            this.labelQuantidade.Name = "labelQuantidade";
            this.labelQuantidade.Size = new System.Drawing.Size(77, 16);
            this.labelQuantidade.TabIndex = 5;
            this.labelQuantidade.Text = "Quantidade";
            // 
            // cbTipoArtigo
            // 
            this.cbTipoArtigo.FormattingEnabled = true;
            this.cbTipoArtigo.Location = new System.Drawing.Point(144, 43);
            this.cbTipoArtigo.Name = "cbTipoArtigo";
            this.cbTipoArtigo.Size = new System.Drawing.Size(116, 24);
            this.cbTipoArtigo.TabIndex = 4;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(281, 45);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(116, 22);
            this.txtQuantidade.TabIndex = 3;
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(141, 22);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(73, 16);
            this.labelTipo.TabIndex = 2;
            this.labelTipo.Text = "Tipo Artigo";
            // 
            // txtNomeArtigo
            // 
            this.txtNomeArtigo.Location = new System.Drawing.Point(7, 45);
            this.txtNomeArtigo.Name = "txtNomeArtigo";
            this.txtNomeArtigo.Size = new System.Drawing.Size(116, 22);
            this.txtNomeArtigo.TabIndex = 1;
            // 
            // labelNomeArtigo
            // 
            this.labelNomeArtigo.AutoSize = true;
            this.labelNomeArtigo.Location = new System.Drawing.Point(4, 22);
            this.labelNomeArtigo.Name = "labelNomeArtigo";
            this.labelNomeArtigo.Size = new System.Drawing.Size(82, 16);
            this.labelNomeArtigo.TabIndex = 0;
            this.labelNomeArtigo.Text = "Nome Aritgo";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(682, 419);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(108, 23);
            this.btnFechar.TabIndex = 17;
            this.btnFechar.Text = "Fechar Compra";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(537, 419);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(139, 23);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "Guardar Alterações";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 271);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(777, 142);
            this.dataGridView1.TabIndex = 19;
            // 
            // ModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressbar);
            this.Controls.Add(this.button3);
            this.Name = "ModoCompra";
            this.Text = "ModoCompra";
            this.Load += new System.EventHandler(this.ModoCompra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressbar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtOrcamentoData;
        private System.Windows.Forms.Label txtOrcamentoDinheiro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label txtTotalQuantidade;
        private System.Windows.Forms.Label txtTotalDinheiro;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label txtGasto;
        private System.Windows.Forms.Label txtGastoDinheiro;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label txtRestante;
        private System.Windows.Forms.Label txtRestanteDinheiro;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelNomeArtigo;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.TextBox txtNomeArtigo;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelQuantidade;
        private System.Windows.Forms.ComboBox cbTipoArtigo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}