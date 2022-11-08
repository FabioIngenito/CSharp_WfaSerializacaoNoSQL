namespace WfaSerializacaoNoSQL
{
    partial class FrmSerializacaoNoSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSerializacaoNoSQL));
            this.BtnSerializacaoJson = new System.Windows.Forms.Button();
            this.LblCPF = new System.Windows.Forms.Label();
            this.LblNomeDoFuncionario = new System.Windows.Forms.Label();
            this.TxtNome = new System.Windows.Forms.TextBox();
            this.LblEndereco = new System.Windows.Forms.Label();
            this.TxtEndereco = new System.Windows.Forms.TextBox();
            this.LblDepartamento = new System.Windows.Forms.Label();
            this.LblNascimento = new System.Windows.Forms.Label();
            this.CboDepartamento = new System.Windows.Forms.ComboBox();
            this.GrbSexo = new System.Windows.Forms.GroupBox();
            this.RdoFeminino = new System.Windows.Forms.RadioButton();
            this.RdoMasculino = new System.Windows.Forms.RadioButton();
            this.LblCPFSupervisor = new System.Windows.Forms.Label();
            this.LblSalario = new System.Windows.Forms.Label();
            this.TxtSalario = new System.Windows.Forms.TextBox();
            this.DgvDependentes = new System.Windows.Forms.DataGridView();
            this.ClmNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNascimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmParentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnIncluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnLimparCampos = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.grpBancoDeDados = new System.Windows.Forms.GroupBox();
            this.radMongoDB = new System.Windows.Forms.RadioButton();
            this.radMySQL = new System.Windows.Forms.RadioButton();
            this.DgvFuncionario = new System.Windows.Forms.DataGridView();
            this.DtpNascimento = new System.Windows.Forms.DateTimePicker();
            this.MskCPFSupervisor = new System.Windows.Forms.MaskedTextBox();
            this.MskCPF = new System.Windows.Forms.MaskedTextBox();
            this.MskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.LblTelefone = new System.Windows.Forms.Label();
            this.PnlDependente = new System.Windows.Forms.Panel();
            this.BtnExcluirDependente = new System.Windows.Forms.Button();
            this.CboParentesco = new System.Windows.Forms.ComboBox();
            this.BtnIncluirDependente = new System.Windows.Forms.Button();
            this.LblParentesco = new System.Windows.Forms.Label();
            this.DtpNascimentoDependente = new System.Windows.Forms.DateTimePicker();
            this.LblNascimentoDependente = new System.Windows.Forms.Label();
            this.GrbSexoDependente = new System.Windows.Forms.GroupBox();
            this.RdoFemininoDependente = new System.Windows.Forms.RadioButton();
            this.RdoMasculinoDependente = new System.Windows.Forms.RadioButton();
            this.LblNomeDependente = new System.Windows.Forms.Label();
            this.TxtNomeDependente = new System.Windows.Forms.TextBox();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.LblPesquisar = new System.Windows.Forms.Label();
            this.BtnPesquisarBD = new System.Windows.Forms.Button();
            this.GrbSexo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDependentes)).BeginInit();
            this.grpBancoDeDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFuncionario)).BeginInit();
            this.PnlDependente.SuspendLayout();
            this.GrbSexoDependente.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSerializacaoJson
            // 
            this.BtnSerializacaoJson.Location = new System.Drawing.Point(205, 496);
            this.BtnSerializacaoJson.Name = "BtnSerializacaoJson";
            this.BtnSerializacaoJson.Size = new System.Drawing.Size(90, 46);
            this.BtnSerializacaoJson.TabIndex = 40;
            this.BtnSerializacaoJson.Text = "Serialização &JSON";
            this.BtnSerializacaoJson.UseVisualStyleBackColor = true;
            this.BtnSerializacaoJson.Click += new System.EventHandler(this.BtnSerializacaoJson_Click);
            // 
            // LblCPF
            // 
            this.LblCPF.AutoSize = true;
            this.LblCPF.Location = new System.Drawing.Point(12, 9);
            this.LblCPF.Name = "LblCPF";
            this.LblCPF.Size = new System.Drawing.Size(28, 15);
            this.LblCPF.TabIndex = 2;
            this.LblCPF.Text = "CPF";
            // 
            // LblNomeDoFuncionario
            // 
            this.LblNomeDoFuncionario.AutoSize = true;
            this.LblNomeDoFuncionario.Location = new System.Drawing.Point(108, 9);
            this.LblNomeDoFuncionario.Name = "LblNomeDoFuncionario";
            this.LblNomeDoFuncionario.Size = new System.Drawing.Size(123, 15);
            this.LblNomeDoFuncionario.TabIndex = 4;
            this.LblNomeDoFuncionario.Text = "Nome do Funcionário";
            // 
            // TxtNome
            // 
            this.TxtNome.Location = new System.Drawing.Point(108, 27);
            this.TxtNome.Name = "TxtNome";
            this.TxtNome.Size = new System.Drawing.Size(352, 23);
            this.TxtNome.TabIndex = 5;
            // 
            // LblEndereco
            // 
            this.LblEndereco.AutoSize = true;
            this.LblEndereco.Location = new System.Drawing.Point(12, 62);
            this.LblEndereco.Name = "LblEndereco";
            this.LblEndereco.Size = new System.Drawing.Size(56, 15);
            this.LblEndereco.TabIndex = 6;
            this.LblEndereco.Text = "Endereço";
            // 
            // TxtEndereco
            // 
            this.TxtEndereco.Location = new System.Drawing.Point(12, 80);
            this.TxtEndereco.Name = "TxtEndereco";
            this.TxtEndereco.Size = new System.Drawing.Size(303, 23);
            this.TxtEndereco.TabIndex = 7;
            // 
            // LblDepartamento
            // 
            this.LblDepartamento.AutoSize = true;
            this.LblDepartamento.Location = new System.Drawing.Point(321, 62);
            this.LblDepartamento.Name = "LblDepartamento";
            this.LblDepartamento.Size = new System.Drawing.Size(83, 15);
            this.LblDepartamento.TabIndex = 8;
            this.LblDepartamento.Text = "Departamento";
            // 
            // LblNascimento
            // 
            this.LblNascimento.AutoSize = true;
            this.LblNascimento.Location = new System.Drawing.Point(12, 123);
            this.LblNascimento.Name = "LblNascimento";
            this.LblNascimento.Size = new System.Drawing.Size(114, 15);
            this.LblNascimento.TabIndex = 10;
            this.LblNascimento.Text = "Data de Nascimento";
            // 
            // CboDepartamento
            // 
            this.CboDepartamento.AutoCompleteCustomSource.AddRange(new string[] {
            "Administrativo",
            "Financeiro",
            "Recursos Humanos",
            "Comercial",
            "Marketing",
            "Juridico",
            "Operacional"});
            this.CboDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CboDepartamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CboDepartamento.FormattingEnabled = true;
            this.CboDepartamento.Items.AddRange(new object[] {
            "1 - Administrativo",
            "2 - Financeiro",
            "3 - Recursos Humanos",
            "4 - Comercial",
            "5 - Marketing",
            "6 - Juridico",
            "7 - Operacional"});
            this.CboDepartamento.Location = new System.Drawing.Point(321, 80);
            this.CboDepartamento.Name = "CboDepartamento";
            this.CboDepartamento.Size = new System.Drawing.Size(139, 23);
            this.CboDepartamento.TabIndex = 9;
            this.CboDepartamento.Text = "1 - Administrativo";
            // 
            // GrbSexo
            // 
            this.GrbSexo.Controls.Add(this.RdoFeminino);
            this.GrbSexo.Controls.Add(this.RdoMasculino);
            this.GrbSexo.Location = new System.Drawing.Point(132, 123);
            this.GrbSexo.Name = "GrbSexo";
            this.GrbSexo.Size = new System.Drawing.Size(183, 41);
            this.GrbSexo.TabIndex = 12;
            this.GrbSexo.TabStop = false;
            this.GrbSexo.Text = "Sexo";
            // 
            // RdoFeminino
            // 
            this.RdoFeminino.AutoSize = true;
            this.RdoFeminino.Location = new System.Drawing.Point(103, 18);
            this.RdoFeminino.Name = "RdoFeminino";
            this.RdoFeminino.Size = new System.Drawing.Size(75, 19);
            this.RdoFeminino.TabIndex = 14;
            this.RdoFeminino.Text = "Feminino";
            this.RdoFeminino.UseVisualStyleBackColor = true;
            // 
            // RdoMasculino
            // 
            this.RdoMasculino.AutoSize = true;
            this.RdoMasculino.Checked = true;
            this.RdoMasculino.Location = new System.Drawing.Point(17, 18);
            this.RdoMasculino.Name = "RdoMasculino";
            this.RdoMasculino.Size = new System.Drawing.Size(80, 19);
            this.RdoMasculino.TabIndex = 13;
            this.RdoMasculino.TabStop = true;
            this.RdoMasculino.Text = "Masculino";
            this.RdoMasculino.UseVisualStyleBackColor = true;
            // 
            // LblCPFSupervisor
            // 
            this.LblCPFSupervisor.AutoSize = true;
            this.LblCPFSupervisor.Location = new System.Drawing.Point(12, 176);
            this.LblCPFSupervisor.Name = "LblCPFSupervisor";
            this.LblCPFSupervisor.Size = new System.Drawing.Size(86, 15);
            this.LblCPFSupervisor.TabIndex = 17;
            this.LblCPFSupervisor.Text = "CPF Supervisor";
            // 
            // LblSalario
            // 
            this.LblSalario.AutoSize = true;
            this.LblSalario.Location = new System.Drawing.Point(321, 123);
            this.LblSalario.Name = "LblSalario";
            this.LblSalario.Size = new System.Drawing.Size(42, 15);
            this.LblSalario.TabIndex = 15;
            this.LblSalario.Text = "Salário";
            // 
            // TxtSalario
            // 
            this.TxtSalario.Location = new System.Drawing.Point(321, 141);
            this.TxtSalario.Name = "TxtSalario";
            this.TxtSalario.Size = new System.Drawing.Size(139, 23);
            this.TxtSalario.TabIndex = 16;
            this.TxtSalario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSalario_KeyPress);
            // 
            // DgvDependentes
            // 
            this.DgvDependentes.AllowUserToAddRows = false;
            this.DgvDependentes.AllowUserToDeleteRows = false;
            this.DgvDependentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvDependentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDependentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmNome,
            this.ClmSexo,
            this.ClmNascimento,
            this.ClmParentesco});
            this.DgvDependentes.Location = new System.Drawing.Point(466, 448);
            this.DgvDependentes.MultiSelect = false;
            this.DgvDependentes.Name = "DgvDependentes";
            this.DgvDependentes.ReadOnly = true;
            this.DgvDependentes.RowTemplate.Height = 25;
            this.DgvDependentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDependentes.Size = new System.Drawing.Size(554, 150);
            this.DgvDependentes.TabIndex = 1;
            this.DgvDependentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDependentes_CellClick);
            this.DgvDependentes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDependentes_KeyDown);
            this.DgvDependentes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DgvDependentes_KeyUp);
            // 
            // ClmNome
            // 
            this.ClmNome.HeaderText = "Nome";
            this.ClmNome.Name = "ClmNome";
            this.ClmNome.ReadOnly = true;
            this.ClmNome.Width = 250;
            // 
            // ClmSexo
            // 
            this.ClmSexo.HeaderText = "Sexo";
            this.ClmSexo.Name = "ClmSexo";
            this.ClmSexo.ReadOnly = true;
            this.ClmSexo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmSexo.Width = 40;
            // 
            // ClmNascimento
            // 
            this.ClmNascimento.HeaderText = "Nascimento";
            this.ClmNascimento.MaxInputLength = 20;
            this.ClmNascimento.MinimumWidth = 10;
            this.ClmNascimento.Name = "ClmNascimento";
            this.ClmNascimento.ReadOnly = true;
            this.ClmNascimento.Width = 120;
            // 
            // ClmParentesco
            // 
            this.ClmParentesco.HeaderText = "Parentesco";
            this.ClmParentesco.Name = "ClmParentesco";
            this.ClmParentesco.ReadOnly = true;
            this.ClmParentesco.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmParentesco.Width = 80;
            // 
            // BtnIncluir
            // 
            this.BtnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("BtnIncluir.Image")));
            this.BtnIncluir.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BtnIncluir.Location = new System.Drawing.Point(12, 444);
            this.BtnIncluir.Name = "BtnIncluir";
            this.BtnIncluir.Size = new System.Drawing.Size(90, 46);
            this.BtnIncluir.TabIndex = 35;
            this.BtnIncluir.Text = "&Incluir";
            this.BtnIncluir.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnIncluir.UseVisualStyleBackColor = true;
            this.BtnIncluir.Click += new System.EventHandler(this.BtnIncluir_Click);
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAlterar.Image")));
            this.BtnAlterar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BtnAlterar.Location = new System.Drawing.Point(108, 444);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(90, 46);
            this.BtnAlterar.TabIndex = 36;
            this.BtnAlterar.Text = "&Alterar";
            this.BtnAlterar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnAlterar.UseVisualStyleBackColor = true;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // BtnLimparCampos
            // 
            this.BtnLimparCampos.Image = ((System.Drawing.Image)(resources.GetObject("BtnLimparCampos.Image")));
            this.BtnLimparCampos.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BtnLimparCampos.Location = new System.Drawing.Point(12, 496);
            this.BtnLimparCampos.Name = "BtnLimparCampos";
            this.BtnLimparCampos.Size = new System.Drawing.Size(186, 46);
            this.BtnLimparCampos.TabIndex = 39;
            this.BtnLimparCampos.Text = "&Limpar Campos";
            this.BtnLimparCampos.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnLimparCampos.UseVisualStyleBackColor = true;
            this.BtnLimparCampos.Click += new System.EventHandler(this.BtnLimparCampos_Click);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.BtnExcluir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnExcluir.CausesValidation = false;
            this.BtnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("BtnExcluir.Image")));
            this.BtnExcluir.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BtnExcluir.Location = new System.Drawing.Point(370, 444);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(90, 46);
            this.BtnExcluir.TabIndex = 38;
            this.BtnExcluir.Text = "&Excluir";
            this.BtnExcluir.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.BtnPesquisar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnPesquisar.CausesValidation = false;
            this.BtnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("BtnPesquisar.Image")));
            this.BtnPesquisar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BtnPesquisar.Location = new System.Drawing.Point(204, 444);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(90, 46);
            this.BtnPesquisar.TabIndex = 37;
            this.BtnPesquisar.Tag = "CPF ou NOME";
            this.BtnPesquisar.Text = "&Pesquisar";
            this.BtnPesquisar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnPesquisar.UseVisualStyleBackColor = true;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // grpBancoDeDados
            // 
            this.grpBancoDeDados.Controls.Add(this.radMongoDB);
            this.grpBancoDeDados.Controls.Add(this.radMySQL);
            this.grpBancoDeDados.Location = new System.Drawing.Point(301, 501);
            this.grpBancoDeDados.Name = "grpBancoDeDados";
            this.grpBancoDeDados.Size = new System.Drawing.Size(159, 41);
            this.grpBancoDeDados.TabIndex = 41;
            this.grpBancoDeDados.TabStop = false;
            this.grpBancoDeDados.Text = "Banco de Dados";
            // 
            // radMongoDB
            // 
            this.radMongoDB.AutoSize = true;
            this.radMongoDB.Location = new System.Drawing.Point(75, 16);
            this.radMongoDB.Name = "radMongoDB";
            this.radMongoDB.Size = new System.Drawing.Size(79, 19);
            this.radMongoDB.TabIndex = 43;
            this.radMongoDB.Tag = "o";
            this.radMongoDB.Text = "MongoDB";
            this.radMongoDB.UseVisualStyleBackColor = true;
            this.radMongoDB.CheckedChanged += new System.EventHandler(this.RadMongoDB_CheckedChanged);
            // 
            // radMySQL
            // 
            this.radMySQL.AutoSize = true;
            this.radMySQL.Checked = true;
            this.radMySQL.Location = new System.Drawing.Point(6, 16);
            this.radMySQL.Name = "radMySQL";
            this.radMySQL.Size = new System.Drawing.Size(63, 19);
            this.radMySQL.TabIndex = 42;
            this.radMySQL.TabStop = true;
            this.radMySQL.Tag = "y";
            this.radMySQL.Text = "MySQL";
            this.radMySQL.UseVisualStyleBackColor = true;
            this.radMySQL.CheckedChanged += new System.EventHandler(this.RadMySQL_CheckedChanged);
            // 
            // DgvFuncionario
            // 
            this.DgvFuncionario.AllowUserToAddRows = false;
            this.DgvFuncionario.AllowUserToDeleteRows = false;
            this.DgvFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvFuncionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFuncionario.Location = new System.Drawing.Point(466, 9);
            this.DgvFuncionario.MultiSelect = false;
            this.DgvFuncionario.Name = "DgvFuncionario";
            this.DgvFuncionario.ReadOnly = true;
            this.DgvFuncionario.RowTemplate.Height = 25;
            this.DgvFuncionario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFuncionario.Size = new System.Drawing.Size(554, 433);
            this.DgvFuncionario.TabIndex = 0;
            this.DgvFuncionario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFuncionario_CellClick);
            this.DgvFuncionario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvFuncionario_KeyDown);
            this.DgvFuncionario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DgvFuncionario_KeyUp);
            // 
            // DtpNascimento
            // 
            this.DtpNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpNascimento.Location = new System.Drawing.Point(12, 141);
            this.DtpNascimento.Name = "DtpNascimento";
            this.DtpNascimento.Size = new System.Drawing.Size(114, 23);
            this.DtpNascimento.TabIndex = 11;
            this.DtpNascimento.Value = new System.DateTime(2000, 1, 1, 12, 0, 0, 0);
            // 
            // MskCPFSupervisor
            // 
            this.MskCPFSupervisor.Location = new System.Drawing.Point(12, 194);
            this.MskCPFSupervisor.Mask = "000\\.000\\.000\\-00";
            this.MskCPFSupervisor.Name = "MskCPFSupervisor";
            this.MskCPFSupervisor.Size = new System.Drawing.Size(90, 23);
            this.MskCPFSupervisor.TabIndex = 18;
            // 
            // MskCPF
            // 
            this.MskCPF.Location = new System.Drawing.Point(12, 27);
            this.MskCPF.Mask = "000\\.000\\.000\\-00";
            this.MskCPF.Name = "MskCPF";
            this.MskCPF.Size = new System.Drawing.Size(90, 23);
            this.MskCPF.TabIndex = 3;
            // 
            // MskTelefone
            // 
            this.MskTelefone.Location = new System.Drawing.Point(108, 194);
            this.MskTelefone.Mask = "(99) 0000-0000";
            this.MskTelefone.Name = "MskTelefone";
            this.MskTelefone.Size = new System.Drawing.Size(90, 23);
            this.MskTelefone.TabIndex = 20;
            // 
            // LblTelefone
            // 
            this.LblTelefone.AutoSize = true;
            this.LblTelefone.Location = new System.Drawing.Point(108, 176);
            this.LblTelefone.Name = "LblTelefone";
            this.LblTelefone.Size = new System.Drawing.Size(51, 15);
            this.LblTelefone.TabIndex = 19;
            this.LblTelefone.Text = "Telefone";
            // 
            // PnlDependente
            // 
            this.PnlDependente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlDependente.Controls.Add(this.BtnExcluirDependente);
            this.PnlDependente.Controls.Add(this.CboParentesco);
            this.PnlDependente.Controls.Add(this.BtnIncluirDependente);
            this.PnlDependente.Controls.Add(this.LblParentesco);
            this.PnlDependente.Controls.Add(this.DtpNascimentoDependente);
            this.PnlDependente.Controls.Add(this.LblNascimentoDependente);
            this.PnlDependente.Controls.Add(this.GrbSexoDependente);
            this.PnlDependente.Controls.Add(this.LblNomeDependente);
            this.PnlDependente.Controls.Add(this.TxtNomeDependente);
            this.PnlDependente.Location = new System.Drawing.Point(12, 235);
            this.PnlDependente.Name = "PnlDependente";
            this.PnlDependente.Size = new System.Drawing.Size(448, 162);
            this.PnlDependente.TabIndex = 21;
            // 
            // BtnExcluirDependente
            // 
            this.BtnExcluirDependente.Location = new System.Drawing.Point(318, 124);
            this.BtnExcluirDependente.Name = "BtnExcluirDependente";
            this.BtnExcluirDependente.Size = new System.Drawing.Size(124, 23);
            this.BtnExcluirDependente.TabIndex = 32;
            this.BtnExcluirDependente.Text = "Excluir Depende&nte";
            this.BtnExcluirDependente.UseVisualStyleBackColor = true;
            this.BtnExcluirDependente.Click += new System.EventHandler(this.BtnExcluirDependente_Click);
            // 
            // CboParentesco
            // 
            this.CboParentesco.AutoCompleteCustomSource.AddRange(new string[] {
            "Administrativo",
            "Financeiro",
            "Recursos Humanos",
            "Comercial",
            "Marketing",
            "Juridico",
            "Operacional"});
            this.CboParentesco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CboParentesco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CboParentesco.FormattingEnabled = true;
            this.CboParentesco.Items.AddRange(new object[] {
            "Esposo",
            "Esposa",
            "Filho",
            "Filha",
            "Pai",
            "Mãe"});
            this.CboParentesco.Location = new System.Drawing.Point(358, 76);
            this.CboParentesco.Name = "CboParentesco";
            this.CboParentesco.Size = new System.Drawing.Size(84, 23);
            this.CboParentesco.TabIndex = 30;
            this.CboParentesco.Text = "Esposa";
            // 
            // BtnIncluirDependente
            // 
            this.BtnIncluirDependente.ForeColor = System.Drawing.Color.Red;
            this.BtnIncluirDependente.Location = new System.Drawing.Point(6, 124);
            this.BtnIncluirDependente.Name = "BtnIncluirDependente";
            this.BtnIncluirDependente.Size = new System.Drawing.Size(124, 23);
            this.BtnIncluirDependente.TabIndex = 31;
            this.BtnIncluirDependente.Text = "Incluir Dependen&te";
            this.BtnIncluirDependente.UseVisualStyleBackColor = true;
            this.BtnIncluirDependente.Click += new System.EventHandler(this.BtnIncluirDependente_Click);
            // 
            // LblParentesco
            // 
            this.LblParentesco.AutoSize = true;
            this.LblParentesco.Location = new System.Drawing.Point(358, 57);
            this.LblParentesco.Name = "LblParentesco";
            this.LblParentesco.Size = new System.Drawing.Size(65, 15);
            this.LblParentesco.TabIndex = 29;
            this.LblParentesco.Text = "Parentesco";
            // 
            // DtpNascimentoDependente
            // 
            this.DtpNascimentoDependente.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpNascimentoDependente.Location = new System.Drawing.Point(223, 76);
            this.DtpNascimentoDependente.Name = "DtpNascimentoDependente";
            this.DtpNascimentoDependente.Size = new System.Drawing.Size(114, 23);
            this.DtpNascimentoDependente.TabIndex = 28;
            this.DtpNascimentoDependente.Value = new System.DateTime(2000, 1, 1, 12, 0, 0, 0);
            // 
            // LblNascimentoDependente
            // 
            this.LblNascimentoDependente.AutoSize = true;
            this.LblNascimentoDependente.Location = new System.Drawing.Point(223, 58);
            this.LblNascimentoDependente.Name = "LblNascimentoDependente";
            this.LblNascimentoDependente.Size = new System.Drawing.Size(114, 15);
            this.LblNascimentoDependente.TabIndex = 27;
            this.LblNascimentoDependente.Text = "Data de Nascimento";
            // 
            // GrbSexoDependente
            // 
            this.GrbSexoDependente.Controls.Add(this.RdoFemininoDependente);
            this.GrbSexoDependente.Controls.Add(this.RdoMasculinoDependente);
            this.GrbSexoDependente.Location = new System.Drawing.Point(6, 62);
            this.GrbSexoDependente.Name = "GrbSexoDependente";
            this.GrbSexoDependente.Size = new System.Drawing.Size(180, 41);
            this.GrbSexoDependente.TabIndex = 24;
            this.GrbSexoDependente.TabStop = false;
            this.GrbSexoDependente.Text = "Sexo";
            // 
            // RdoFemininoDependente
            // 
            this.RdoFemininoDependente.AutoSize = true;
            this.RdoFemininoDependente.Checked = true;
            this.RdoFemininoDependente.Location = new System.Drawing.Point(99, 18);
            this.RdoFemininoDependente.Name = "RdoFemininoDependente";
            this.RdoFemininoDependente.Size = new System.Drawing.Size(75, 19);
            this.RdoFemininoDependente.TabIndex = 26;
            this.RdoFemininoDependente.TabStop = true;
            this.RdoFemininoDependente.Text = "Feminino";
            this.RdoFemininoDependente.UseVisualStyleBackColor = true;
            // 
            // RdoMasculinoDependente
            // 
            this.RdoMasculinoDependente.AutoSize = true;
            this.RdoMasculinoDependente.Location = new System.Drawing.Point(17, 18);
            this.RdoMasculinoDependente.Name = "RdoMasculinoDependente";
            this.RdoMasculinoDependente.Size = new System.Drawing.Size(80, 19);
            this.RdoMasculinoDependente.TabIndex = 25;
            this.RdoMasculinoDependente.Text = "Masculino";
            this.RdoMasculinoDependente.UseVisualStyleBackColor = true;
            // 
            // LblNomeDependente
            // 
            this.LblNomeDependente.AutoSize = true;
            this.LblNomeDependente.Location = new System.Drawing.Point(6, 12);
            this.LblNomeDependente.Name = "LblNomeDependente";
            this.LblNomeDependente.Size = new System.Drawing.Size(124, 15);
            this.LblNomeDependente.TabIndex = 22;
            this.LblNomeDependente.Text = "Nome do Dependente";
            // 
            // TxtNomeDependente
            // 
            this.TxtNomeDependente.Location = new System.Drawing.Point(6, 30);
            this.TxtNomeDependente.Name = "TxtNomeDependente";
            this.TxtNomeDependente.Size = new System.Drawing.Size(437, 23);
            this.TxtNomeDependente.TabIndex = 23;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisar.Location = new System.Drawing.Point(78, 415);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(382, 23);
            this.txtPesquisar.TabIndex = 34;
            this.txtPesquisar.Tag = "CPF ou Nome";
            this.txtPesquisar.Text = "22222222223";
            // 
            // LblPesquisar
            // 
            this.LblPesquisar.AutoSize = true;
            this.LblPesquisar.Location = new System.Drawing.Point(12, 418);
            this.LblPesquisar.Name = "LblPesquisar";
            this.LblPesquisar.Size = new System.Drawing.Size(60, 15);
            this.LblPesquisar.TabIndex = 33;
            this.LblPesquisar.Tag = "CPF ou Nome";
            this.LblPesquisar.Text = "Pesquisar:";
            // 
            // BtnPesquisarBD
            // 
            this.BtnPesquisarBD.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.BtnPesquisarBD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnPesquisarBD.CausesValidation = false;
            this.BtnPesquisarBD.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BtnPesquisarBD.Location = new System.Drawing.Point(12, 548);
            this.BtnPesquisarBD.Name = "BtnPesquisarBD";
            this.BtnPesquisarBD.Size = new System.Drawing.Size(187, 46);
            this.BtnPesquisarBD.TabIndex = 44;
            this.BtnPesquisarBD.Text = "Pesquisar &QTD Dependentes no Banco de Dados (NÃO GRID)";
            this.BtnPesquisarBD.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnPesquisarBD.UseVisualStyleBackColor = true;
            this.BtnPesquisarBD.Click += new System.EventHandler(this.BtnPesquisarBD_Click);
            // 
            // FrmSerializacaoNoSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 609);
            this.Controls.Add(this.BtnPesquisarBD);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.LblPesquisar);
            this.Controls.Add(this.PnlDependente);
            this.Controls.Add(this.MskTelefone);
            this.Controls.Add(this.LblTelefone);
            this.Controls.Add(this.MskCPF);
            this.Controls.Add(this.MskCPFSupervisor);
            this.Controls.Add(this.DtpNascimento);
            this.Controls.Add(this.DgvFuncionario);
            this.Controls.Add(this.grpBancoDeDados);
            this.Controls.Add(this.BtnPesquisar);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.BtnLimparCampos);
            this.Controls.Add(this.BtnAlterar);
            this.Controls.Add(this.BtnIncluir);
            this.Controls.Add(this.DgvDependentes);
            this.Controls.Add(this.TxtSalario);
            this.Controls.Add(this.LblSalario);
            this.Controls.Add(this.LblCPFSupervisor);
            this.Controls.Add(this.GrbSexo);
            this.Controls.Add(this.CboDepartamento);
            this.Controls.Add(this.LblNascimento);
            this.Controls.Add(this.LblDepartamento);
            this.Controls.Add(this.TxtEndereco);
            this.Controls.Add(this.LblEndereco);
            this.Controls.Add(this.TxtNome);
            this.Controls.Add(this.LblNomeDoFuncionario);
            this.Controls.Add(this.LblCPF);
            this.Controls.Add(this.BtnSerializacaoJson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSerializacaoNoSQL";
            this.ShowIcon = false;
            this.Tag = "";
            this.Text = "Serializacao NoSQL - No Only Structure Query Language";
            this.Load += new System.EventHandler(this.FrmSerializacaoNoSQL_Load);
            this.GrbSexo.ResumeLayout(false);
            this.GrbSexo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDependentes)).EndInit();
            this.grpBancoDeDados.ResumeLayout(false);
            this.grpBancoDeDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFuncionario)).EndInit();
            this.PnlDependente.ResumeLayout(false);
            this.PnlDependente.PerformLayout();
            this.GrbSexoDependente.ResumeLayout(false);
            this.GrbSexoDependente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnSerializacaoJson;
        private Label LblCPF;
        private Label LblNomeDoFuncionario;
        private TextBox TxtNome;
        private Label LblEndereco;
        private TextBox TxtEndereco;
        private Label LblDepartamento;
        private Label LblNascimento;
        private ComboBox CboDepartamento;
        private GroupBox GrbSexo;
        private RadioButton RdoFeminino;
        private RadioButton RdoMasculino;
        private Label LblCPFSupervisor;
        private Label LblSalario;
        private TextBox TxtSalario;
        private DataGridView DgvDependentes;
        private Button BtnIncluir;
        private Button BtnAlterar;
        private Button BtnLimparCampos;
        private Button BtnExcluir;
        private Button BtnPesquisar;
        private GroupBox grpBancoDeDados;
        private RadioButton radMongoDB;
        private RadioButton radMySQL;
        private DataGridView DgvFuncionario;
        private DateTimePicker DtpNascimento;
        private MaskedTextBox MskCPFSupervisor;
        private MaskedTextBox MskCPF;
        private MaskedTextBox MskTelefone;
        private Label LblTelefone;
        private Panel PnlDependente;
        private Button BtnIncluirDependente;
        private Label LblParentesco;
        private DateTimePicker DtpNascimentoDependente;
        private Label LblNascimentoDependente;
        private GroupBox GrbSexoDependente;
        private RadioButton RdoFemininoDependente;
        private RadioButton RdoMasculinoDependente;
        private Label LblNomeDependente;
        private TextBox TxtNomeDependente;
        private TextBox txtPesquisar;
        private Label LblPesquisar;
        private Button BtnExcluirDependente;
        private ComboBox CboParentesco;
        private DataGridViewTextBoxColumn ClmNome;
        private DataGridViewTextBoxColumn ClmSexo;
        private DataGridViewTextBoxColumn ClmNascimento;
        private DataGridViewTextBoxColumn ClmParentesco;
        private Button BtnPesquisarBD;
    }
}