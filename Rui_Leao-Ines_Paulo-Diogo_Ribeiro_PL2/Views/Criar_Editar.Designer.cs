namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Views
{
    partial class Criar_Editar
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
            this.btnGuardarRascunho = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnApagarSelecionado = new System.Windows.Forms.Button();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.cmbArtigo = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMesAssociado = new System.Windows.Forms.Label();
            this.txtCriadaPor = new System.Windows.Forms.Label();
            this.txtDataCriacao = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeCompra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardarRascunho
            // 
            this.btnGuardarRascunho.Location = new System.Drawing.Point(872, 509);
            this.btnGuardarRascunho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarRascunho.Name = "btnGuardarRascunho";
            this.btnGuardarRascunho.Size = new System.Drawing.Size(180, 32);
            this.btnGuardarRascunho.TabIndex = 24;
            this.btnGuardarRascunho.Text = "Guardar como rascunho";
            this.btnGuardarRascunho.UseVisualStyleBackColor = true;
            this.btnGuardarRascunho.Click += new System.EventHandler(this.btnGuardarRascunho_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(775, 509);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 32);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnApagarSelecionado);
            this.groupBox3.Controls.Add(this.dgvItens);
            this.groupBox3.Location = new System.Drawing.Point(15, 230);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(1037, 273);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Itens da Compra";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnApagarSelecionado
            // 
            this.btnApagarSelecionado.Location = new System.Drawing.Point(913, 245);
            this.btnApagarSelecionado.Margin = new System.Windows.Forms.Padding(4);
            this.btnApagarSelecionado.Name = "btnApagarSelecionado";
            this.btnApagarSelecionado.Size = new System.Drawing.Size(100, 28);
            this.btnApagarSelecionado.TabIndex = 1;
            this.btnApagarSelecionado.Text = "Excluir";
            this.btnApagarSelecionado.UseVisualStyleBackColor = true;
            this.btnApagarSelecionado.Visible = false;
            this.btnApagarSelecionado.Click += new System.EventHandler(this.btnApagarSelecionado_Click);
            // 
            // dgvItens
            // 
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Location = new System.Drawing.Point(21, 39);
            this.dgvItens.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.RowHeadersWidth = 51;
            this.dgvItens.RowTemplate.Height = 24;
            this.dgvItens.Size = new System.Drawing.Size(992, 203);
            this.dgvItens.TabIndex = 0;
            this.dgvItens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItens_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdicionarItem);
            this.groupBox2.Controls.Add(this.cmbArtigo);
            this.groupBox2.Controls.Add(this.cmbTipo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtQuantidade);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(15, 135);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1037, 90);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adicionar Item Previsto";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.Location = new System.Drawing.Point(549, 50);
            this.btnAdicionarItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(143, 23);
            this.btnAdicionarItem.TabIndex = 9;
            this.btnAdicionarItem.Text = "+ Adicionar à lista";
            this.btnAdicionarItem.UseVisualStyleBackColor = true;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            // 
            // cmbArtigo
            // 
            this.cmbArtigo.FormattingEnabled = true;
            this.cmbArtigo.Location = new System.Drawing.Point(205, 50);
            this.cmbArtigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbArtigo.Name = "cmbArtigo";
            this.cmbArtigo.Size = new System.Drawing.Size(129, 24);
            this.cmbArtigo.TabIndex = 8;
            this.cmbArtigo.SelectedIndexChanged += new System.EventHandler(this.cmbArtigo_SelectedIndexChanged);
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(21, 50);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(161, 24);
            this.cmbTipo.TabIndex = 7;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Quantidade prevista";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(367, 50);
            this.txtQuantidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(131, 22);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.TextChanged += new System.EventHandler(this.txtQuantidade_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Artigo";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Tipo";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMesAssociado);
            this.groupBox1.Controls.Add(this.txtCriadaPor);
            this.groupBox1.Controls.Add(this.txtDataCriacao);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNomeCompra);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1037, 90);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da compra";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtMesAssociado
            // 
            this.txtMesAssociado.AutoSize = true;
            this.txtMesAssociado.Location = new System.Drawing.Point(671, 59);
            this.txtMesAssociado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtMesAssociado.Name = "txtMesAssociado";
            this.txtMesAssociado.Size = new System.Drawing.Size(16, 16);
            this.txtMesAssociado.TabIndex = 10;
            this.txtMesAssociado.Text = "...";
            this.txtMesAssociado.Click += new System.EventHandler(this.txtMesAssociado_Click);
            // 
            // txtCriadaPor
            // 
            this.txtCriadaPor.AutoSize = true;
            this.txtCriadaPor.Location = new System.Drawing.Point(451, 58);
            this.txtCriadaPor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtCriadaPor.Name = "txtCriadaPor";
            this.txtCriadaPor.Size = new System.Drawing.Size(16, 16);
            this.txtCriadaPor.TabIndex = 9;
            this.txtCriadaPor.Text = "...";
            this.txtCriadaPor.Click += new System.EventHandler(this.txtCriadaPor_Click);
            // 
            // txtDataCriacao
            // 
            this.txtDataCriacao.AutoSize = true;
            this.txtDataCriacao.Location = new System.Drawing.Point(261, 58);
            this.txtDataCriacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtDataCriacao.Name = "txtDataCriacao";
            this.txtDataCriacao.Size = new System.Drawing.Size(16, 16);
            this.txtDataCriacao.TabIndex = 8;
            this.txtDataCriacao.Text = "...";
            this.txtDataCriacao.Click += new System.EventHandler(this.txtDataCriacao_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(632, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mês associado";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtNomeCompra
            // 
            this.txtNomeCompra.Location = new System.Drawing.Point(23, 50);
            this.txtNomeCompra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNomeCompra.Name = "txtNomeCompra";
            this.txtNomeCompra.Size = new System.Drawing.Size(160, 22);
            this.txtNomeCompra.TabIndex = 0;
            this.txtNomeCompra.TextChanged += new System.EventHandler(this.txtNomeCompra_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Criada por";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data de criação";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome da compra *";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Criar_Editar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnGuardarRascunho);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Criar_Editar";
            this.Text = "Criar_Editar";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGuardarRascunho;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.ComboBox cmbArtigo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtMesAssociado;
        private System.Windows.Forms.Label txtCriadaPor;
        private System.Windows.Forms.Label txtDataCriacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomeCompra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApagarSelecionado;
    }
}