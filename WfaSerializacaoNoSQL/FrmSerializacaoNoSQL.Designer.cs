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
            BtnSerializacaoJson = new Button();
            LblCPF = new Label();
            LblNomeDoFuncionario = new Label();
            TxtNome = new TextBox();
            LblEndereco = new Label();
            TxtEndereco = new TextBox();
            LblDepartamento = new Label();
            LblNascimento = new Label();
            CboDepartamento = new ComboBox();
            GrbSexo = new GroupBox();
            RdoFeminino = new RadioButton();
            RdoMasculino = new RadioButton();
            LblCPFSupervisor = new Label();
            LblSalario = new Label();
            TxtSalario = new TextBox();
            DgvDependentes = new DataGridView();
            ClmNome = new DataGridViewTextBoxColumn();
            ClmSexo = new DataGridViewTextBoxColumn();
            ClmNascimento = new DataGridViewTextBoxColumn();
            ClmParentesco = new DataGridViewTextBoxColumn();
            BtnIncluir = new Button();
            BtnAlterar = new Button();
            BtnLimparCampos = new Button();
            BtnExcluir = new Button();
            BtnPesquisar = new Button();
            grpBancoDeDados = new GroupBox();
            radMSSQL = new RadioButton();
            radMongoDB = new RadioButton();
            radMySQL = new RadioButton();
            DgvFuncionario = new DataGridView();
            DtpNascimento = new DateTimePicker();
            MskCPFSupervisor = new MaskedTextBox();
            MskCPF = new MaskedTextBox();
            MskTelefone = new MaskedTextBox();
            LblTelefone = new Label();
            PnlDependente = new Panel();
            BtnExcluirDependente = new Button();
            CboParentesco = new ComboBox();
            BtnIncluirDependente = new Button();
            LblParentesco = new Label();
            DtpNascimentoDependente = new DateTimePicker();
            LblNascimentoDependente = new Label();
            GrbSexoDependente = new GroupBox();
            RdoFemininoDependente = new RadioButton();
            RdoMasculinoDependente = new RadioButton();
            LblNomeDependente = new Label();
            TxtNomeDependente = new TextBox();
            txtPesquisar = new TextBox();
            LblPesquisar = new Label();
            BtnPesquisarBD = new Button();
            GrbSexo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDependentes).BeginInit();
            grpBancoDeDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvFuncionario).BeginInit();
            PnlDependente.SuspendLayout();
            GrbSexoDependente.SuspendLayout();
            SuspendLayout();
            // 
            // BtnSerializacaoJson
            // 
            BtnSerializacaoJson.Location = new Point(234, 661);
            BtnSerializacaoJson.Margin = new Padding(3, 4, 3, 4);
            BtnSerializacaoJson.Name = "BtnSerializacaoJson";
            BtnSerializacaoJson.Size = new Size(103, 61);
            BtnSerializacaoJson.TabIndex = 40;
            BtnSerializacaoJson.Text = "Serialização &JSON";
            BtnSerializacaoJson.UseVisualStyleBackColor = true;
            BtnSerializacaoJson.Click += BtnSerializacaoJson_Click;
            // 
            // LblCPF
            // 
            LblCPF.AutoSize = true;
            LblCPF.Location = new Point(14, 12);
            LblCPF.Name = "LblCPF";
            LblCPF.Size = new Size(33, 20);
            LblCPF.TabIndex = 2;
            LblCPF.Text = "CPF";
            // 
            // LblNomeDoFuncionario
            // 
            LblNomeDoFuncionario.AutoSize = true;
            LblNomeDoFuncionario.Location = new Point(135, 12);
            LblNomeDoFuncionario.Name = "LblNomeDoFuncionario";
            LblNomeDoFuncionario.Size = new Size(153, 20);
            LblNomeDoFuncionario.TabIndex = 4;
            LblNomeDoFuncionario.Text = "Nome do Funcionário";
            // 
            // TxtNome
            // 
            TxtNome.Location = new Point(135, 36);
            TxtNome.Margin = new Padding(3, 4, 3, 4);
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(390, 27);
            TxtNome.TabIndex = 5;
            // 
            // LblEndereco
            // 
            LblEndereco.AutoSize = true;
            LblEndereco.Location = new Point(14, 83);
            LblEndereco.Name = "LblEndereco";
            LblEndereco.Size = new Size(71, 20);
            LblEndereco.TabIndex = 6;
            LblEndereco.Text = "Endereço";
            // 
            // TxtEndereco
            // 
            TxtEndereco.Location = new Point(14, 107);
            TxtEndereco.Margin = new Padding(3, 4, 3, 4);
            TxtEndereco.Name = "TxtEndereco";
            TxtEndereco.Size = new Size(346, 27);
            TxtEndereco.TabIndex = 7;
            // 
            // LblDepartamento
            // 
            LblDepartamento.AutoSize = true;
            LblDepartamento.Location = new Point(367, 83);
            LblDepartamento.Name = "LblDepartamento";
            LblDepartamento.Size = new Size(106, 20);
            LblDepartamento.TabIndex = 8;
            LblDepartamento.Text = "Departamento";
            // 
            // LblNascimento
            // 
            LblNascimento.AutoSize = true;
            LblNascimento.Location = new Point(14, 164);
            LblNascimento.Name = "LblNascimento";
            LblNascimento.Size = new Size(145, 20);
            LblNascimento.TabIndex = 10;
            LblNascimento.Text = "Data de Nascimento";
            // 
            // CboDepartamento
            // 
            CboDepartamento.AutoCompleteCustomSource.AddRange(new string[] { "Administrativo", "Financeiro", "Recursos Humanos", "Comercial", "Marketing", "Juridico", "Operacional" });
            CboDepartamento.AutoCompleteMode = AutoCompleteMode.Append;
            CboDepartamento.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboDepartamento.FormattingEnabled = true;
            CboDepartamento.Items.AddRange(new object[] { "1 - Administrativo", "2 - Financeiro", "3 - Recursos Humanos", "4 - Comercial", "5 - Marketing", "6 - Juridico", "7 - Operacional" });
            CboDepartamento.Location = new Point(367, 107);
            CboDepartamento.Margin = new Padding(3, 4, 3, 4);
            CboDepartamento.Name = "CboDepartamento";
            CboDepartamento.Size = new Size(158, 28);
            CboDepartamento.TabIndex = 9;
            CboDepartamento.Text = "1 - Administrativo";
            // 
            // GrbSexo
            // 
            GrbSexo.Controls.Add(RdoFeminino);
            GrbSexo.Controls.Add(RdoMasculino);
            GrbSexo.Location = new Point(151, 164);
            GrbSexo.Margin = new Padding(3, 4, 3, 4);
            GrbSexo.Name = "GrbSexo";
            GrbSexo.Padding = new Padding(3, 4, 3, 4);
            GrbSexo.Size = new Size(209, 55);
            GrbSexo.TabIndex = 12;
            GrbSexo.TabStop = false;
            GrbSexo.Text = "Sexo";
            // 
            // RdoFeminino
            // 
            RdoFeminino.AutoSize = true;
            RdoFeminino.Location = new Point(118, 24);
            RdoFeminino.Margin = new Padding(3, 4, 3, 4);
            RdoFeminino.Name = "RdoFeminino";
            RdoFeminino.Size = new Size(91, 24);
            RdoFeminino.TabIndex = 14;
            RdoFeminino.Text = "Feminino";
            RdoFeminino.UseVisualStyleBackColor = true;
            // 
            // RdoMasculino
            // 
            RdoMasculino.AutoSize = true;
            RdoMasculino.Checked = true;
            RdoMasculino.Location = new Point(19, 24);
            RdoMasculino.Margin = new Padding(3, 4, 3, 4);
            RdoMasculino.Name = "RdoMasculino";
            RdoMasculino.Size = new Size(97, 24);
            RdoMasculino.TabIndex = 13;
            RdoMasculino.TabStop = true;
            RdoMasculino.Text = "Masculino";
            RdoMasculino.UseVisualStyleBackColor = true;
            // 
            // LblCPFSupervisor
            // 
            LblCPFSupervisor.AutoSize = true;
            LblCPFSupervisor.Location = new Point(14, 235);
            LblCPFSupervisor.Name = "LblCPFSupervisor";
            LblCPFSupervisor.Size = new Size(106, 20);
            LblCPFSupervisor.TabIndex = 17;
            LblCPFSupervisor.Text = "CPF Supervisor";
            // 
            // LblSalario
            // 
            LblSalario.AutoSize = true;
            LblSalario.Location = new Point(367, 164);
            LblSalario.Name = "LblSalario";
            LblSalario.Size = new Size(55, 20);
            LblSalario.TabIndex = 15;
            LblSalario.Text = "Salário";
            // 
            // TxtSalario
            // 
            TxtSalario.Location = new Point(367, 188);
            TxtSalario.Margin = new Padding(3, 4, 3, 4);
            TxtSalario.Name = "TxtSalario";
            TxtSalario.Size = new Size(158, 27);
            TxtSalario.TabIndex = 16;
            TxtSalario.KeyPress += TxtSalario_KeyPress;
            // 
            // DgvDependentes
            // 
            DgvDependentes.AllowUserToAddRows = false;
            DgvDependentes.AllowUserToDeleteRows = false;
            DgvDependentes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DgvDependentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDependentes.Columns.AddRange(new DataGridViewColumn[] { ClmNome, ClmSexo, ClmNascimento, ClmParentesco });
            DgvDependentes.Location = new Point(533, 597);
            DgvDependentes.Margin = new Padding(3, 4, 3, 4);
            DgvDependentes.MultiSelect = false;
            DgvDependentes.Name = "DgvDependentes";
            DgvDependentes.ReadOnly = true;
            DgvDependentes.RowHeadersWidth = 51;
            DgvDependentes.RowTemplate.Height = 25;
            DgvDependentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDependentes.Size = new Size(633, 200);
            DgvDependentes.TabIndex = 1;
            DgvDependentes.CellClick += DgvDependentes_CellClick;
            DgvDependentes.KeyDown += DgvDependentes_KeyDown;
            DgvDependentes.KeyUp += DgvDependentes_KeyUp;
            // 
            // ClmNome
            // 
            ClmNome.HeaderText = "Nome";
            ClmNome.MinimumWidth = 6;
            ClmNome.Name = "ClmNome";
            ClmNome.ReadOnly = true;
            ClmNome.Width = 250;
            // 
            // ClmSexo
            // 
            ClmSexo.HeaderText = "Sexo";
            ClmSexo.MinimumWidth = 6;
            ClmSexo.Name = "ClmSexo";
            ClmSexo.ReadOnly = true;
            ClmSexo.Resizable = DataGridViewTriState.True;
            ClmSexo.Width = 40;
            // 
            // ClmNascimento
            // 
            ClmNascimento.HeaderText = "Nascimento";
            ClmNascimento.MaxInputLength = 20;
            ClmNascimento.MinimumWidth = 10;
            ClmNascimento.Name = "ClmNascimento";
            ClmNascimento.ReadOnly = true;
            ClmNascimento.Width = 120;
            // 
            // ClmParentesco
            // 
            ClmParentesco.HeaderText = "Parentesco";
            ClmParentesco.MinimumWidth = 6;
            ClmParentesco.Name = "ClmParentesco";
            ClmParentesco.ReadOnly = true;
            ClmParentesco.Resizable = DataGridViewTriState.True;
            ClmParentesco.Width = 80;
            // 
            // BtnIncluir
            // 
            BtnIncluir.Image = (Image)resources.GetObject("BtnIncluir.Image");
            BtnIncluir.ImageAlign = ContentAlignment.BottomRight;
            BtnIncluir.Location = new Point(14, 592);
            BtnIncluir.Margin = new Padding(3, 4, 3, 4);
            BtnIncluir.Name = "BtnIncluir";
            BtnIncluir.Size = new Size(103, 61);
            BtnIncluir.TabIndex = 35;
            BtnIncluir.Text = "&Incluir";
            BtnIncluir.TextAlign = ContentAlignment.TopLeft;
            BtnIncluir.UseVisualStyleBackColor = true;
            BtnIncluir.Click += BtnIncluir_Click;
            // 
            // BtnAlterar
            // 
            BtnAlterar.Image = (Image)resources.GetObject("BtnAlterar.Image");
            BtnAlterar.ImageAlign = ContentAlignment.BottomRight;
            BtnAlterar.Location = new Point(123, 592);
            BtnAlterar.Margin = new Padding(3, 4, 3, 4);
            BtnAlterar.Name = "BtnAlterar";
            BtnAlterar.Size = new Size(103, 61);
            BtnAlterar.TabIndex = 36;
            BtnAlterar.Text = "&Alterar";
            BtnAlterar.TextAlign = ContentAlignment.TopLeft;
            BtnAlterar.UseVisualStyleBackColor = true;
            BtnAlterar.Click += BtnAlterar_Click;
            // 
            // BtnLimparCampos
            // 
            BtnLimparCampos.Image = (Image)resources.GetObject("BtnLimparCampos.Image");
            BtnLimparCampos.ImageAlign = ContentAlignment.BottomRight;
            BtnLimparCampos.Location = new Point(14, 661);
            BtnLimparCampos.Margin = new Padding(3, 4, 3, 4);
            BtnLimparCampos.Name = "BtnLimparCampos";
            BtnLimparCampos.Size = new Size(213, 61);
            BtnLimparCampos.TabIndex = 39;
            BtnLimparCampos.Text = "&Limpar Campos";
            BtnLimparCampos.TextAlign = ContentAlignment.TopLeft;
            BtnLimparCampos.UseVisualStyleBackColor = true;
            BtnLimparCampos.Click += BtnLimparCampos_Click;
            // 
            // BtnExcluir
            // 
            BtnExcluir.AccessibleRole = AccessibleRole.TitleBar;
            BtnExcluir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnExcluir.CausesValidation = false;
            BtnExcluir.Image = (Image)resources.GetObject("BtnExcluir.Image");
            BtnExcluir.ImageAlign = ContentAlignment.BottomRight;
            BtnExcluir.Location = new Point(423, 592);
            BtnExcluir.Margin = new Padding(3, 4, 3, 4);
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new Size(103, 61);
            BtnExcluir.TabIndex = 38;
            BtnExcluir.Text = "&Excluir";
            BtnExcluir.TextAlign = ContentAlignment.TopLeft;
            BtnExcluir.UseVisualStyleBackColor = true;
            BtnExcluir.Click += BtnExcluir_Click;
            // 
            // BtnPesquisar
            // 
            BtnPesquisar.AccessibleRole = AccessibleRole.TitleBar;
            BtnPesquisar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnPesquisar.CausesValidation = false;
            BtnPesquisar.Image = (Image)resources.GetObject("BtnPesquisar.Image");
            BtnPesquisar.ImageAlign = ContentAlignment.BottomRight;
            BtnPesquisar.Location = new Point(233, 592);
            BtnPesquisar.Margin = new Padding(3, 4, 3, 4);
            BtnPesquisar.Name = "BtnPesquisar";
            BtnPesquisar.Size = new Size(103, 61);
            BtnPesquisar.TabIndex = 37;
            BtnPesquisar.Tag = "CPF ou NOME";
            BtnPesquisar.Text = "&Pesquisar";
            BtnPesquisar.TextAlign = ContentAlignment.TopLeft;
            BtnPesquisar.UseVisualStyleBackColor = true;
            BtnPesquisar.Click += BtnPesquisar_Click;
            // 
            // grpBancoDeDados
            // 
            grpBancoDeDados.Controls.Add(radMSSQL);
            grpBancoDeDados.Controls.Add(radMongoDB);
            grpBancoDeDados.Controls.Add(radMySQL);
            grpBancoDeDados.Location = new Point(344, 668);
            grpBancoDeDados.Margin = new Padding(3, 4, 3, 4);
            grpBancoDeDados.Name = "grpBancoDeDados";
            grpBancoDeDados.Padding = new Padding(3, 4, 3, 4);
            grpBancoDeDados.Size = new Size(182, 124);
            grpBancoDeDados.TabIndex = 41;
            grpBancoDeDados.TabStop = false;
            grpBancoDeDados.Text = "Banco de Dados";
            // 
            // radMSSQL
            // 
            radMSSQL.AutoSize = true;
            radMSSQL.Checked = true;
            radMSSQL.Location = new Point(7, 53);
            radMSSQL.Margin = new Padding(3, 4, 3, 4);
            radMSSQL.Name = "radMSSQL";
            radMSSQL.Size = new Size(81, 24);
            radMSSQL.TabIndex = 44;
            radMSSQL.TabStop = true;
            radMSSQL.Tag = "m";
            radMSSQL.Text = "MS SQL";
            radMSSQL.UseVisualStyleBackColor = true;
            radMSSQL.CheckedChanged += RadMSSQL_CheckedChanged;
            // 
            // radMongoDB
            // 
            radMongoDB.AutoSize = true;
            radMongoDB.Location = new Point(86, 21);
            radMongoDB.Margin = new Padding(3, 4, 3, 4);
            radMongoDB.Name = "radMongoDB";
            radMongoDB.Size = new Size(98, 24);
            radMongoDB.TabIndex = 43;
            radMongoDB.Tag = "o";
            radMongoDB.Text = "MongoDB";
            radMongoDB.UseVisualStyleBackColor = true;
            radMongoDB.CheckedChanged += RadMongoDB_CheckedChanged;
            // 
            // radMySQL
            // 
            radMySQL.AutoSize = true;
            radMySQL.Location = new Point(7, 21);
            radMySQL.Margin = new Padding(3, 4, 3, 4);
            radMySQL.Name = "radMySQL";
            radMySQL.Size = new Size(76, 24);
            radMySQL.TabIndex = 42;
            radMySQL.Tag = "y";
            radMySQL.Text = "MySQL";
            radMySQL.UseVisualStyleBackColor = true;
            radMySQL.CheckedChanged += RadMySQL_CheckedChanged;
            // 
            // DgvFuncionario
            // 
            DgvFuncionario.AllowUserToAddRows = false;
            DgvFuncionario.AllowUserToDeleteRows = false;
            DgvFuncionario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DgvFuncionario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvFuncionario.Location = new Point(533, 12);
            DgvFuncionario.Margin = new Padding(3, 4, 3, 4);
            DgvFuncionario.MultiSelect = false;
            DgvFuncionario.Name = "DgvFuncionario";
            DgvFuncionario.ReadOnly = true;
            DgvFuncionario.RowHeadersWidth = 51;
            DgvFuncionario.RowTemplate.Height = 25;
            DgvFuncionario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvFuncionario.Size = new Size(633, 577);
            DgvFuncionario.TabIndex = 0;
            DgvFuncionario.CellClick += DgvFuncionario_CellClick;
            DgvFuncionario.KeyDown += DgvFuncionario_KeyDown;
            DgvFuncionario.KeyUp += DgvFuncionario_KeyUp;
            // 
            // DtpNascimento
            // 
            DtpNascimento.Format = DateTimePickerFormat.Short;
            DtpNascimento.Location = new Point(14, 188);
            DtpNascimento.Margin = new Padding(3, 4, 3, 4);
            DtpNascimento.Name = "DtpNascimento";
            DtpNascimento.Size = new Size(130, 27);
            DtpNascimento.TabIndex = 11;
            DtpNascimento.Value = new DateTime(2000, 1, 1, 12, 0, 0, 0);
            // 
            // MskCPFSupervisor
            // 
            MskCPFSupervisor.Location = new Point(14, 259);
            MskCPFSupervisor.Margin = new Padding(3, 4, 3, 4);
            MskCPFSupervisor.Mask = "000\\.000\\.000\\-00";
            MskCPFSupervisor.Name = "MskCPFSupervisor";
            MskCPFSupervisor.Size = new Size(115, 27);
            MskCPFSupervisor.TabIndex = 18;
            // 
            // MskCPF
            // 
            MskCPF.Location = new Point(14, 36);
            MskCPF.Margin = new Padding(3, 4, 3, 4);
            MskCPF.Mask = "000\\.000\\.000\\-00";
            MskCPF.Name = "MskCPF";
            MskCPF.Size = new Size(115, 27);
            MskCPF.TabIndex = 3;
            // 
            // MskTelefone
            // 
            MskTelefone.Location = new Point(135, 259);
            MskTelefone.Margin = new Padding(3, 4, 3, 4);
            MskTelefone.Mask = "(99) 0000-0000";
            MskTelefone.Name = "MskTelefone";
            MskTelefone.Size = new Size(111, 27);
            MskTelefone.TabIndex = 20;
            // 
            // LblTelefone
            // 
            LblTelefone.AutoSize = true;
            LblTelefone.Location = new Point(135, 235);
            LblTelefone.Name = "LblTelefone";
            LblTelefone.Size = new Size(66, 20);
            LblTelefone.TabIndex = 19;
            LblTelefone.Text = "Telefone";
            // 
            // PnlDependente
            // 
            PnlDependente.BorderStyle = BorderStyle.FixedSingle;
            PnlDependente.Controls.Add(BtnExcluirDependente);
            PnlDependente.Controls.Add(CboParentesco);
            PnlDependente.Controls.Add(BtnIncluirDependente);
            PnlDependente.Controls.Add(LblParentesco);
            PnlDependente.Controls.Add(DtpNascimentoDependente);
            PnlDependente.Controls.Add(LblNascimentoDependente);
            PnlDependente.Controls.Add(GrbSexoDependente);
            PnlDependente.Controls.Add(LblNomeDependente);
            PnlDependente.Controls.Add(TxtNomeDependente);
            PnlDependente.Location = new Point(14, 313);
            PnlDependente.Margin = new Padding(3, 4, 3, 4);
            PnlDependente.Name = "PnlDependente";
            PnlDependente.Size = new Size(512, 215);
            PnlDependente.TabIndex = 21;
            // 
            // BtnExcluirDependente
            // 
            BtnExcluirDependente.Location = new Point(363, 165);
            BtnExcluirDependente.Margin = new Padding(3, 4, 3, 4);
            BtnExcluirDependente.Name = "BtnExcluirDependente";
            BtnExcluirDependente.Size = new Size(142, 31);
            BtnExcluirDependente.TabIndex = 32;
            BtnExcluirDependente.Text = "Excluir Depende&nte";
            BtnExcluirDependente.UseVisualStyleBackColor = true;
            BtnExcluirDependente.Click += BtnExcluirDependente_Click;
            // 
            // CboParentesco
            // 
            CboParentesco.AutoCompleteCustomSource.AddRange(new string[] { "Administrativo", "Financeiro", "Recursos Humanos", "Comercial", "Marketing", "Juridico", "Operacional" });
            CboParentesco.AutoCompleteMode = AutoCompleteMode.Append;
            CboParentesco.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboParentesco.FormattingEnabled = true;
            CboParentesco.Items.AddRange(new object[] { "Esposo", "Esposa", "Filho", "Filha", "Pai", "Mãe" });
            CboParentesco.Location = new Point(409, 101);
            CboParentesco.Margin = new Padding(3, 4, 3, 4);
            CboParentesco.Name = "CboParentesco";
            CboParentesco.Size = new Size(95, 28);
            CboParentesco.TabIndex = 30;
            CboParentesco.Text = "Esposa";
            // 
            // BtnIncluirDependente
            // 
            BtnIncluirDependente.ForeColor = Color.Red;
            BtnIncluirDependente.Location = new Point(7, 165);
            BtnIncluirDependente.Margin = new Padding(3, 4, 3, 4);
            BtnIncluirDependente.Name = "BtnIncluirDependente";
            BtnIncluirDependente.Size = new Size(142, 31);
            BtnIncluirDependente.TabIndex = 31;
            BtnIncluirDependente.Text = "Incluir Dependen&te";
            BtnIncluirDependente.UseVisualStyleBackColor = true;
            BtnIncluirDependente.Click += BtnIncluirDependente_Click;
            // 
            // LblParentesco
            // 
            LblParentesco.AutoSize = true;
            LblParentesco.Location = new Point(409, 76);
            LblParentesco.Name = "LblParentesco";
            LblParentesco.Size = new Size(80, 20);
            LblParentesco.TabIndex = 29;
            LblParentesco.Text = "Parentesco";
            // 
            // DtpNascimentoDependente
            // 
            DtpNascimentoDependente.Format = DateTimePickerFormat.Short;
            DtpNascimentoDependente.Location = new Point(255, 101);
            DtpNascimentoDependente.Margin = new Padding(3, 4, 3, 4);
            DtpNascimentoDependente.Name = "DtpNascimentoDependente";
            DtpNascimentoDependente.Size = new Size(130, 27);
            DtpNascimentoDependente.TabIndex = 28;
            DtpNascimentoDependente.Value = new DateTime(2000, 1, 1, 12, 0, 0, 0);
            // 
            // LblNascimentoDependente
            // 
            LblNascimentoDependente.AutoSize = true;
            LblNascimentoDependente.Location = new Point(255, 77);
            LblNascimentoDependente.Name = "LblNascimentoDependente";
            LblNascimentoDependente.Size = new Size(145, 20);
            LblNascimentoDependente.TabIndex = 27;
            LblNascimentoDependente.Text = "Data de Nascimento";
            // 
            // GrbSexoDependente
            // 
            GrbSexoDependente.Controls.Add(RdoFemininoDependente);
            GrbSexoDependente.Controls.Add(RdoMasculinoDependente);
            GrbSexoDependente.Location = new Point(7, 83);
            GrbSexoDependente.Margin = new Padding(3, 4, 3, 4);
            GrbSexoDependente.Name = "GrbSexoDependente";
            GrbSexoDependente.Padding = new Padding(3, 4, 3, 4);
            GrbSexoDependente.Size = new Size(206, 55);
            GrbSexoDependente.TabIndex = 24;
            GrbSexoDependente.TabStop = false;
            GrbSexoDependente.Text = "Sexo";
            // 
            // RdoFemininoDependente
            // 
            RdoFemininoDependente.AutoSize = true;
            RdoFemininoDependente.Checked = true;
            RdoFemininoDependente.Location = new Point(113, 24);
            RdoFemininoDependente.Margin = new Padding(3, 4, 3, 4);
            RdoFemininoDependente.Name = "RdoFemininoDependente";
            RdoFemininoDependente.Size = new Size(91, 24);
            RdoFemininoDependente.TabIndex = 26;
            RdoFemininoDependente.TabStop = true;
            RdoFemininoDependente.Text = "Feminino";
            RdoFemininoDependente.UseVisualStyleBackColor = true;
            // 
            // RdoMasculinoDependente
            // 
            RdoMasculinoDependente.AutoSize = true;
            RdoMasculinoDependente.Location = new Point(19, 24);
            RdoMasculinoDependente.Margin = new Padding(3, 4, 3, 4);
            RdoMasculinoDependente.Name = "RdoMasculinoDependente";
            RdoMasculinoDependente.Size = new Size(97, 24);
            RdoMasculinoDependente.TabIndex = 25;
            RdoMasculinoDependente.Text = "Masculino";
            RdoMasculinoDependente.UseVisualStyleBackColor = true;
            // 
            // LblNomeDependente
            // 
            LblNomeDependente.AutoSize = true;
            LblNomeDependente.Location = new Point(7, 16);
            LblNomeDependente.Name = "LblNomeDependente";
            LblNomeDependente.Size = new Size(158, 20);
            LblNomeDependente.TabIndex = 22;
            LblNomeDependente.Text = "Nome do Dependente";
            // 
            // TxtNomeDependente
            // 
            TxtNomeDependente.Location = new Point(7, 40);
            TxtNomeDependente.Margin = new Padding(3, 4, 3, 4);
            TxtNomeDependente.Name = "TxtNomeDependente";
            TxtNomeDependente.Size = new Size(499, 27);
            TxtNomeDependente.TabIndex = 23;
            // 
            // txtPesquisar
            // 
            txtPesquisar.BorderStyle = BorderStyle.FixedSingle;
            txtPesquisar.Location = new Point(89, 553);
            txtPesquisar.Margin = new Padding(3, 4, 3, 4);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(436, 27);
            txtPesquisar.TabIndex = 34;
            txtPesquisar.Tag = "CPF ou Nome";
            txtPesquisar.Text = "22222222223";
            // 
            // LblPesquisar
            // 
            LblPesquisar.AutoSize = true;
            LblPesquisar.Location = new Point(14, 557);
            LblPesquisar.Name = "LblPesquisar";
            LblPesquisar.Size = new Size(73, 20);
            LblPesquisar.TabIndex = 33;
            LblPesquisar.Tag = "CPF ou Nome";
            LblPesquisar.Text = "Pesquisar:";
            // 
            // BtnPesquisarBD
            // 
            BtnPesquisarBD.AccessibleRole = AccessibleRole.TitleBar;
            BtnPesquisarBD.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnPesquisarBD.CausesValidation = false;
            BtnPesquisarBD.ImageAlign = ContentAlignment.BottomRight;
            BtnPesquisarBD.Location = new Point(14, 731);
            BtnPesquisarBD.Margin = new Padding(3, 4, 3, 4);
            BtnPesquisarBD.Name = "BtnPesquisarBD";
            BtnPesquisarBD.Size = new Size(214, 61);
            BtnPesquisarBD.TabIndex = 44;
            BtnPesquisarBD.Text = "Pesquisar &QTD Dependentes no Banco de Dados (NÃO GRID)";
            BtnPesquisarBD.TextAlign = ContentAlignment.TopLeft;
            BtnPesquisarBD.UseVisualStyleBackColor = true;
            BtnPesquisarBD.Click += BtnPesquisarBD_Click;
            // 
            // FrmSerializacaoNoSQL
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 812);
            Controls.Add(BtnPesquisarBD);
            Controls.Add(txtPesquisar);
            Controls.Add(LblPesquisar);
            Controls.Add(PnlDependente);
            Controls.Add(MskTelefone);
            Controls.Add(LblTelefone);
            Controls.Add(MskCPF);
            Controls.Add(MskCPFSupervisor);
            Controls.Add(DtpNascimento);
            Controls.Add(DgvFuncionario);
            Controls.Add(grpBancoDeDados);
            Controls.Add(BtnPesquisar);
            Controls.Add(BtnExcluir);
            Controls.Add(BtnLimparCampos);
            Controls.Add(BtnAlterar);
            Controls.Add(BtnIncluir);
            Controls.Add(DgvDependentes);
            Controls.Add(TxtSalario);
            Controls.Add(LblSalario);
            Controls.Add(LblCPFSupervisor);
            Controls.Add(GrbSexo);
            Controls.Add(CboDepartamento);
            Controls.Add(LblNascimento);
            Controls.Add(LblDepartamento);
            Controls.Add(TxtEndereco);
            Controls.Add(LblEndereco);
            Controls.Add(TxtNome);
            Controls.Add(LblNomeDoFuncionario);
            Controls.Add(LblCPF);
            Controls.Add(BtnSerializacaoJson);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSerializacaoNoSQL";
            ShowIcon = false;
            Tag = "";
            Text = "Serializacao NoSQL - No Only Structure Query Language";
            Load += FrmSerializacaoNoSQL_Load;
            GrbSexo.ResumeLayout(false);
            GrbSexo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDependentes).EndInit();
            grpBancoDeDados.ResumeLayout(false);
            grpBancoDeDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvFuncionario).EndInit();
            PnlDependente.ResumeLayout(false);
            PnlDependente.PerformLayout();
            GrbSexoDependente.ResumeLayout(false);
            GrbSexoDependente.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private RadioButton radMSSQL;
    }
}