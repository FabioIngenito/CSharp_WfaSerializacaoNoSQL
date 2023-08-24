// Como serializar e desserializar (realizar marshaling e cancelar a realização de marshalling) JSON no .NET
// https://docs.microsoft.com/pt-br/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-6-0
//
// Create (criar), Read (ler), Update (atualizar) e Delete (excluir)

using System.Text.Json;
using ClsSerializacaoNoSQL.Model;
using ClsSerializacaoNoSQL.BLL;
using System;
using System.Data;
using MySqlX.XDevAPI.Relational;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using static System.Windows.Forms.Design.AxImporter;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace WfaSerializacaoNoSQL;

public partial class FrmSerializacaoNoSQL : Form
{
    char chBD = 'y';
    public string cpf = "";

    public FrmSerializacaoNoSQL()
    {
        InitializeComponent();
    }

    private void FrmSerializacaoNoSQL_Load(object sender, EventArgs e)
    {
        ClsSerializacaoNoSQLBLL obj = new();
        int intConta = obj.ContaRegistros(chBD);

        if (radMySQL.Checked) chBD = Convert.ToChar(radMySQL.Tag);
        else chBD = Convert.ToChar(radMongoDB.Tag);

        DtpNascimento.Text = DateTime.Now.ToShortDateString();
        DtpNascimentoDependente.Text = DateTime.Now.ToShortDateString();

        //Verificar se tem registros no banco de dados
        if (intConta == 0) AcertaBotoes(3);
        else AcertaBotoes(2);

        AtualizaGrid();

        if (DgvFuncionario.Rows.Count > 0) AtualizaTela();

        DgvFuncionario.Focus();
    }

    #region Funções Auxiliares

    /// <summary>
    /// Atualiza a grid.
    /// </summary>
    /// <param name="matricula">CPF do Funcionário</param>
    private void AtualizaGrid(string CPF = "")
    {
        //comunicação com a camada BLL
        ClsSerializacaoNoSQLBLL obj = new();

        //DgvFuncionario.DataSource = obj.Listagem(TxtFiltro.Text);
        DgvFuncionario.DataSource = obj.Listagem("", chBD);
        DgvFuncionario.Columns[0].Width = 80;
        DgvFuncionario.Columns[1].Width = 3000;
        DgvFuncionario.Refresh();

        if (!string.IsNullOrEmpty(CPF))
        {
            //Pesquisar dentro da grid onde está o "matricula"
            for (int i = 0; i < DgvFuncionario.Rows.Count; i++)
            {
                if (CPF == DgvFuncionario[0, i].Value.ToString())
                {
                    //faz a célula atual e seleciona a linha
                    DgvFuncionario.ClearSelection();
                    DgvFuncionario.CurrentCell = DgvFuncionario.Rows[i].Cells[0];
                    DgvFuncionario.Rows[i].Selected = true;
                    //Preenche os dados das textbox
                    DgvFuncionario_CellClick(null, null);
                    break;
                }
            }
        }

        if (DgvFuncionario.RowCount == 0) BtnLimparCampos_Click(null, null);
        if (DgvDependentes.RowCount == 0) ClsFormularioBLL.EmptyTextBoxes(PnlDependente, MskCPF);
    }

    /// <summary>
    /// Faz o gereneciamento do botões da tela.
    /// </summary>
    /// <param name="bytBotoes"></param>
    public void AcertaBotoes(byte bytBotoes)
    {
        ClsFormularioBLL.AjustaBotoes(this, bytBotoes);

        switch (bytBotoes)
        {
            //1 - Entrada de dados
            case 1:
                MskCPF.ReadOnly = false;
                TxtNome.ReadOnly = false;
                TxtEndereco.ReadOnly = false;
                CboDepartamento.Enabled = true;
                DtpNascimento.Enabled = true;
                GrbSexo.Enabled = true;
                TxtSalario.ReadOnly = false;
                MskTelefone.ReadOnly = false;
                MskCPFSupervisor.ReadOnly = false;
                DgvDependentes.ReadOnly = false;
                PnlDependente.Enabled = true;

                MskCPF.ForeColor = Color.Navy;
                TxtNome.ForeColor = Color.Navy;
                TxtEndereco.ForeColor = Color.Navy;
                DtpNascimento.ForeColor = Color.Navy;
                TxtSalario.ForeColor = Color.Navy;
                MskTelefone.ForeColor = Color.Navy;
                MskCPFSupervisor.ForeColor = Color.Navy;

                break;

            //2 - Existe algo cadastrado (o mesmo que o 3 neste caso)
            case 2:
            //3 - Não existe nada cadastrado
            case 3:
                MskCPF.ReadOnly = true;
                TxtNome.ReadOnly = true;
                TxtEndereco.ReadOnly = true;
                CboDepartamento.Enabled = false;
                DtpNascimento.Enabled = false;
                GrbSexo.Enabled = false;
                TxtSalario.ReadOnly = true;
                MskTelefone.ReadOnly = true;
                MskCPFSupervisor.ReadOnly = true;
                DgvDependentes.ReadOnly = true;
                PnlDependente.Enabled = false;
                break;
        }
    }

    /// <summary>
    /// Atualiza dados da tela.
    /// </summary>
    private void AtualizaTela()
    {
        try
        {
            if (DgvFuncionario.Rows.Count > 0)
            {
                string strColuna = DgvFuncionario[1, DgvFuncionario.CurrentRow.Index].Value.ToString() + String.Empty;

                ClsFuncionarioModel? func = JsonSerializer.Deserialize<ClsFuncionarioModel>(strColuna);

                MskCPF.Text = DgvFuncionario[0, DgvFuncionario.CurrentRow.Index].Value.ToString();

                TxtNome.Text = func!.Nome;
                TxtEndereco.Text = func.Endereco;

                CboDepartamento.Text = func.Id_Departamento + " - " + func.Nome_Departamento;

                DtpNascimento.Text = func.Nascimento.ToString();

                RdoMasculino.Checked = func.Sexo == 'M';
                RdoFeminino.Checked = !RdoMasculino.Checked;

                TxtSalario.Text = func.Salario.ToString("C");
                MskTelefone.Text = func.Telefone;
                MskCPFSupervisor.Text = func.CPF_Supervisor;

                DgvDependentes.Rows.Clear();

                if (func.Dependentes?.Count > 0)
                {
                    foreach (var item in func.Dependentes!)
                    {
                        DgvDependentes.Rows.Insert(DgvDependentes.Rows.Count, item.Nome, item.Sexo, item.Nascimento, item.Parentesco);
                    }
                }

                AtualizaGridDependente();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }

    private void AtualizaGridDependente()
    {
        if (DgvDependentes.Rows.Count > 0)
        {
            TxtNomeDependente.Text = DgvDependentes[0, DgvDependentes.CurrentRow.Index].Value.ToString();

            RdoMasculinoDependente.Checked = (char)DgvDependentes[1, DgvDependentes.CurrentRow.Index].Value == 'M';
            RdoFemininoDependente.Checked = !RdoMasculinoDependente.Checked;

            DtpNascimentoDependente.Text = DgvDependentes[2, DgvDependentes.CurrentRow.Index].Value.ToString();
            CboParentesco.Text = DgvDependentes[3, DgvDependentes.CurrentRow.Index].Value.ToString();
        }
        else
        {
            TxtNomeDependente.Text = "";
            RdoFemininoDependente.Checked = true;
            DtpNascimentoDependente.Text = DateTime.Now.ToShortDateString();
            CboParentesco.Text = "Esposa";
        }
    }

    private void ConfiguraBD(char chBD)
    {
        ClsSerializacaoNoSQLBLL obj = new();

        DgvDependentes.Rows.Clear();

        //Verificar se tem registros no banco de dados
        int intConta = obj.ContaRegistros(chBD);

        AtualizaGrid();
        AtualizaTela();

        if (intConta == 0) AcertaBotoes(3);
        else
        {
            AcertaBotoes(2);
        }

        DgvFuncionario.Focus();
    }

    #endregion

    #region Eventos
    private void RadMSSQL_CheckedChanged(object sender, EventArgs e)
    {
        if (radMSSQL.Checked)
        {
            chBD = Convert.ToChar(radMSSQL.Tag);
            ConfiguraBD(chBD);
        }
    }

    private void RadMySQL_CheckedChanged(object sender, EventArgs e)
    {
        if (radMySQL.Checked)
        {
            chBD = Convert.ToChar(radMySQL.Tag);
            ConfiguraBD(chBD);
        }
    }

    private void RadMongoDB_CheckedChanged(object sender, EventArgs e)
    {
        if (radMongoDB.Checked)
        {
            chBD = Convert.ToChar(radMongoDB.Tag);
            ConfiguraBD(chBD);
        }
    }

    private void TxtSalario_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 44)) e.Handled = true;
    }

    private void DgvFuncionario_KeyUp(object sender, KeyEventArgs e)
    {
        if (DgvFuncionario.Rows.Count > 0) AtualizaTela();
    }

    private void DgvFuncionario_KeyDown(object sender, KeyEventArgs e)
    {
        if (DgvFuncionario.Rows.Count > 0) AtualizaTela();
    }

    private void DgvFuncionario_CellClick(object? sender, DataGridViewCellEventArgs? e)
    {
        if (DgvFuncionario.Rows.Count > 0) AtualizaTela();
    }

    private void DgvDependentes_KeyUp(object sender, KeyEventArgs e)
    {
        DgvDependentes.Refresh();

        if (DgvDependentes.Rows.Count > 0) AtualizaGridDependente();
    }

    private void DgvDependentes_KeyDown(object sender, KeyEventArgs e)
    {
        DgvDependentes.Refresh();

        if (DgvDependentes.Rows.Count > 0) AtualizaGridDependente();
    }

    private void DgvDependentes_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DgvDependentes.Refresh();

        if (DgvDependentes.Rows.Count > 0) AtualizaGridDependente();
    }

    #endregion

    #region Botões

    /// <summary>
    /// Inclui um novo registro.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnIncluir_Click(object sender, EventArgs e)
    {
        //Aqui verifico qual é o nome do botão.
        //Se for "&Incluir", formato o formulário para permitir a inclusão de um novo registro;
        //Se for "&Salvar", disparo uma rotina para salvar a informação no Banco de Dados;
        if (BtnIncluir.Text == "&Incluir")
        {
            cpf = ClsFormularioBLL.LimpaMascaraCPF(MskCPF.Text);
            MskCPF.Text = "";
            BtnIncluir.Tag = "I";
            BtnLimparCampos_Click(sender, e);
            AcertaBotoes(1);
            DgvDependentes.Rows.Clear();
            MskCPF.Focus();

            //APAGAR... SOMENTE PARA TESTAR OS CAMPOS -INICIO:
            //MskCPF.Text = "22222222222";
            //TxtNome.Text = "Teste teste";
            //TxtEndereco.Text = "Rua São Fábio, 111";
            //TxtSalario.Text = "5000";
            //MskCPFSupervisor.Text = "111111111111";
            //MskTelefone.Text = "3333333333";
            //CboDepartamento.Text = "1 - Administrativo";
            //TxtNomeDependente.Text = "TESTE 1";
            //CboParentesco.Text = "Esposa";
            //APAGAR... SOMENTE PARA TESTAR OS CAMPOS - FIM
        }
        else
        {
            try
            {
                //Monta uma "estrutura" de Funcionarios para passar para classe BLL
                ClsFuncionarioModel Funcionario = new();

                if (ClsFormularioBLL.LimpaMascaraCPF(MskCPF.Text).Length > 0)
                    Funcionario.CPF = ClsFormularioBLL.LimpaMascaraCPF(MskCPF.Text);
                else
                    return;

                Funcionario.Nome = ClsFormularioBLL.LimpaAspa(TxtNome.Text);
                Funcionario.Endereco = ClsFormularioBLL.LimpaAspa(TxtEndereco.Text);

                if (CboDepartamento.Text != "")
                {
                    Funcionario.Id_Departamento = Convert.ToByte(CboDepartamento.Text[..1]);
                    Funcionario.Nome_Departamento = CboDepartamento.Text[4..];
                }

                Funcionario.Nascimento = DtpNascimento.Value;

                if (RdoMasculino.Checked) Funcionario.Sexo = 'M';
                else Funcionario.Sexo = 'F';

                if (TxtSalario.Text != "")
                    Funcionario.Salario = Convert.ToDouble(ClsFormularioBLL.LimpaMascaraValorMonetario(TxtSalario.Text));


                Funcionario.Telefone = ClsFormularioBLL.LimpaMascaraTelefone(MskTelefone.Text);
                Funcionario.CPF_Supervisor = ClsFormularioBLL.LimpaMascaraCPF(MskCPFSupervisor.Text);

                if (DgvDependentes.Rows.Count > 0)
                {
                    //Monta uma "estrutura" de Dependentes para passar adicionar em Funcionários.
                    List<ClsDependenteModel>? Dependentes = new();
                    ClsDependenteModel? Dependente = new();

                    for (int dep = 0; dep < DgvDependentes.Rows.Count; dep++)
                    {
                        Dependente.Nome = DgvDependentes.Rows[dep].Cells[0].Value.ToString();
                        Dependente.Sexo = (char)DgvDependentes.Rows[dep].Cells[1].Value;
                        Dependente.Nascimento = Convert.ToDateTime(DgvDependentes.Rows[dep].Cells[2].Value);
                        Dependente.Parentesco = DgvDependentes.Rows[dep].Cells[3].Value.ToString();

                        Dependentes.Add(Dependente);
                        Dependente = new();
                    }

                    Funcionario.Dependentes = Dependentes;
                }

                ClsSerializacaoNoSQLBLL obj = new();

                //De acordo com o que o usuário clicou ("I"ncluir ou "A"lterar) dentro da TAG do botão ...
                //... se tivesse que digitar a chave, ficaria mais legal, pois basta verificar se a chave existe ou não no 
                ///banco de dados: Se NÃO existe é "Incluir", se existe é "Alterar".
                if (BtnIncluir.Tag.ToString() == "I")
                {
                    try
                    {
                        cpf = obj.Incluir(Funcionario, chBD);

                        if (!string.IsNullOrEmpty(cpf))
                            MessageBox.Show("O Funcionário foi incluído com sucesso!", "OKAY!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        else
                            MessageBox.Show("O Funcionário já existe e NÃO foi incluído.", "OKAY", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                        MskCPF.Text = cpf;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    }
                }
                else
                {
                    try
                    {
                        if (ClsFormularioBLL.LimpaMascaraCPF(MskCPF.Text).Length == 0)
                            MessageBox.Show("Um Funcionário deve ser selecionado para alteração.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        else
                            obj.Alterar(Funcionario, chBD);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                AtualizaGrid(cpf);
                AcertaBotoes(2);

                BtnIncluir.Tag = "";
            }
        }
    }

    /// <summary>
    /// Altera um registro.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnAlterar_Click(object sender, EventArgs e)
    {
        //Aqui verifico qual é o nome do botão.
        //Se for "&Alterar", formato o formulário para permitir a inclusão de um novo registro;
        //Se for "&Cancelar", disparo uma rotina para salvar a informação no Banco de Dados;
        if (BtnAlterar.Text == "&Alterar")
        {
            BtnIncluir.Tag = "A";
            cpf = ClsFormularioBLL.LimpaMascaraCPF(MskCPF.Text);
            AcertaBotoes(1);
            //NÃO pode alterar o CPF, caso queira, é preciso apagar o registro e inseri-lo novamente.
            MskCPF.Enabled = false;
            TxtNome.Focus();
        }
        else
        {
            BtnIncluir.Tag = "";
            cpf = ClsFormularioBLL.LimpaMascaraCPF(MskCPF.Text);

            ClsSerializacaoNoSQLBLL obj = new();
            int intConta = obj.ContaRegistros(chBD);

            BtnLimparCampos_Click(sender, e);

            DtpNascimento.Text = DateTime.Now.ToShortDateString();
            DtpNascimentoDependente.Text = DateTime.Now.ToShortDateString();

            //Verificar se tem registros no banco de dados
            if (intConta == 0)
            {
                AtualizaGrid();
                DgvFuncionario.Focus();
                DgvDependentes.Rows.Clear();
                AcertaBotoes(3);
            }
            else
            {
                AtualizaGrid(cpf);
                AtualizaTela();
                AcertaBotoes(2);
            }
        }
    }

    private void BtnLimparCampos_Click(object? sender, EventArgs? e)
    {
        DtpNascimento.Text = DateTime.Now.ToShortDateString();
        DtpNascimentoDependente.Text = DateTime.Now.ToShortDateString();

        ClsFormularioBLL.EmptyTextBoxes(this, MskCPF);
        ClsFormularioBLL.EmptyTextBoxes(PnlDependente, MskCPF);
    }

    /// <summary>
    /// Pesquisa um registro específico.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnPesquisar_Click(object sender, EventArgs e)
    {
        string resposta = txtPesquisar.Text;

        // InputBox DESCONTINUADO e substituído por "txtPesquisar.Text":
        //resposta = ClsFormularioBLL.InputBox("Digite um CPF ou um NOME, \n se for número pesquisará por Código, \n se for nome, pesquisará por parte do Cliente ", "Pesquisar Cliente", "TESTE");

        if (string.IsNullOrEmpty(resposta.Trim())) return;

        if (ClsFormularioBLL.IsNumeric(resposta))
        {
            for (int i = 0; i < DgvFuncionario.Rows.Count; i++)
            {
                if (resposta == DgvFuncionario[0, i].Value.ToString())
                {
                    //faz a célula atual e seleciona a linha
                    DgvFuncionario.ClearSelection();
                    DgvFuncionario.CurrentCell = DgvFuncionario.Rows[i].Cells[0];
                    DgvFuncionario.Rows[i].Selected = true;
                    //Preenche os dados das textbox
                    DgvFuncionario_CellClick(null, null);

                    break;
                }
            }
        }
        else
        {
            //Procurar dentro da string JSON o NOME
            for (int i = 0; i < DgvFuncionario.Rows.Count; i++)
            {
                ClsFuncionarioModel? func = JsonSerializer.Deserialize<ClsFuncionarioModel>(DgvFuncionario[1, i].Value.ToString() + String.Empty);

                string conteudo = (Convert.ToString(func!.Nome) + string.Empty).ToUpper();

                if (conteudo.IndexOf(resposta.ToUpper()) > -1)
                {
                    //faz a célula atual e seleciona a linha
                    DgvFuncionario.ClearSelection();
                    DgvFuncionario.CurrentCell = DgvFuncionario.Rows[i].Cells[0];
                    DgvFuncionario.Rows[i].Selected = true;
                    //Preenche os dados das textbox
                    DgvFuncionario_CellClick(null, null);

                    break;
                }
            }
        }
    }

    /// <summary>
    /// Exclui um campo na tela e dispara exclusão no banco de dados.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnExcluir_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Tem certeza que deseja excluir? ", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
        {
            cpf = ClsFormularioBLL.LimpaMascaraCPF(MskCPF.Text);
            DgvDependentes.Rows.Clear();

            if (String.IsNullOrEmpty(cpf))
            {
                MessageBox.Show("Um fornecedor deve ser selecionado antes da exclusão.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else

                try
                {
                    ClsSerializacaoNoSQLBLL obj = new();

                    //Em qual banco de dados devo guardar? Aqui mostra:
                    //Bom ... eu gostaria que esta variável fosse tipo "global", mas como fazer isto com várias camadas (projetos)?
                    //Quem souber pode me falar... burlei um pouco as regras?
                    obj.Excluir(cpf, chBD);

                    MessageBox.Show("O funcionario foi excluido com sucesso!", "OKAY!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    int intConta = obj.ContaRegistros(chBD);

                    AtualizaGrid();

                    if (intConta == 0)
                    {
                        BtnLimparCampos_Click(sender, e);
                        AcertaBotoes(3);
                    }
                    else
                    {
                        AtualizaTela();
                        AcertaBotoes(2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
        }
    }

    /// <summary>
    /// Inclui o dependente na grade. Se o dependente NÃO estiver na grade,
    /// NÂO será salvo no Banco de Dados.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnIncluirDependente_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TxtNomeDependente.Text))
        {
            MessageBox.Show("Preencher o nome do dependente.", "OKAY!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            return;
        }

        //Verificar se o nome do dependente já existe na grade.
        for (int i = 0; i < DgvDependentes.Rows.Count; i++)
        {
            if (DgvDependentes.Rows[i].Cells[0].Value.ToString() == TxtNomeDependente.Text)
            {
                MessageBox.Show("Este dependente já existe na grade.", "OKAY!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        DgvDependentes.Rows.Add("");

        DgvDependentes.Rows[^1].Cells[0].Value = TxtNomeDependente.Text;

        if (RdoMasculinoDependente.Checked)
            DgvDependentes.Rows[^1].Cells[1].Value = 'M';
        else
            DgvDependentes.Rows[^1].Cells[1].Value = 'F';

        //2022-12-31T00:00:00
        DgvDependentes.Rows[^1].Cells[2].Value = DtpNascimentoDependente.Value.Year.ToString() + '-' +
                                                                            DtpNascimentoDependente.Value.Month.ToString("00") + '-' +
                                                                            DtpNascimentoDependente.Value.Day.ToString("00") + "T00:00:00";
        DgvDependentes.Rows[^1].Cells[3].Value = CboParentesco.Text;

        DgvDependentes.Rows[^1].Selected = true;
    }

    /// <summary>
    /// Exclui o dependente da grade, quando for salvar o aquivo o dependente
    /// NÃO será salvo.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnExcluirDependente_Click(object sender, EventArgs e)
    {
        if (DgvDependentes.Rows.Count > 0)
            DgvDependentes.Rows.RemoveAt(DgvDependentes.SelectedRows[0].Index);
    }

    /// <summary>
    /// Esta pesquisa é feita dentro do Banco de Dados e NÃO na DataGridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnPesquisarBD_Click(object sender, EventArgs e)
    {
        string resposta = txtPesquisar.Text;

        if (string.IsNullOrEmpty(resposta.Trim())) return;

        if (!ClsFormularioBLL.IsNumeric(resposta))
        {
            MessageBox.Show("Pesquisa somente por CPF.");
            txtPesquisar.Clear();
            return;
        }

        ClsSerializacaoNoSQLBLL obj = new();

        ClsFuncionarioModel? func = obj.SelecionarPorChave(resposta, chBD);

        // NOTA: Esta lógica de "IF's" abaixo serve para atender o MySQL e o MongoDB que
        // respondem um pouco diferente. Precisa atender 3 casos a saber: O CPF...
        // - Tem dependentes;
        // - NÃO tem dependentes;
        // - NÃO tem o PRÓPRIO CPF;

        if (func == null)
            MessageBox.Show($"NÃO Encontrado DEPENDENTES. CPF: {txtPesquisar.Text}.");
        else
        {
            if (!(func.CPF == null))
            {
                if (!(func.Dependentes == null))
                    MessageBox.Show($"Encontrado: CPF: {func.CPF} - Nome: {func.Nome} - Dependentes: {func.Dependentes!.Count}.");
                else
                    MessageBox.Show($"NÃO Encontrado DEPENDENTES. CPF: {txtPesquisar.Text}.");
            }
            else
                MessageBox.Show($"NÃO Encontrado DEPENDENTES. CPF: {txtPesquisar.Text}.");
        }
    }

    /// <summary>
    /// JSON - JavaScript Object Notation
    /// 
    /// Gera o arquivo de Serialização e 
    /// copia para a área de transferência "Ctrl+C"
    /// depois cole neste site:https://jsoneditoronline.org/
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnSerializacaoJson_Click(object sender, EventArgs e)
    {
        if (ClsFormularioBLL.LimpaMascaraCPF(MskCPF.Text) == "") return;

        JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        List<ClsDependenteModel> LstDependente = new();

        ClsFuncionarioModel ClsFuncionario = new()
        {
            CPF = ClsFormularioBLL.LimpaMascaraCPF(MskCPF.Text),
            Nome = TxtNome.Text,
            Endereco = TxtEndereco.Text
        };

        if (!(string.IsNullOrEmpty(CboDepartamento.Text)))
        {
            ClsFuncionario.Id_Departamento = Convert.ToByte(CboDepartamento.Text[..1]);
            ClsFuncionario.Nome_Departamento = CboDepartamento.Text[4..];
        }

        ClsFuncionario.Nascimento = DtpNascimento.Value;

        if (RdoMasculino.Checked)
            ClsFuncionario.Sexo = 'M';
        else
            ClsFuncionario.Sexo = 'F';

        if (!(string.IsNullOrEmpty(TxtSalario.Text)))
            ClsFuncionario.Salario = Convert.ToDouble(ClsFormularioBLL.LimpaMascaraValorMonetario(TxtSalario.Text));

        ClsFuncionario.CPF_Supervisor = ClsFormularioBLL.LimpaMascaraCPF(MskCPFSupervisor.Text);
        ClsFuncionario.Telefone = ClsFormularioBLL.LimpaMascaraTelefone(MskTelefone.Text);

        for (int dep = 0; dep < DgvDependentes.Rows.Count; dep++)
        {
            try
            {
                ClsDependenteModel ClsDependente = new()
                {
                    Nome = DgvDependentes.Rows[dep].Cells[0].Value.ToString(),
                    Sexo = (char)DgvDependentes.Rows[dep].Cells[1].Value,
                    Nascimento = Convert.ToDateTime(DgvDependentes.Rows[dep].Cells[2].Value.ToString()),
                    Parentesco = DgvDependentes.Rows[dep].Cells[3].Value.ToString()
                };

                LstDependente.Add(ClsDependente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no dependente: " + ex.Message);
            }
        }

        ClsFuncionario.Dependentes = LstDependente;

        string StrJson = JsonSerializer.Serialize(ClsFuncionario, options);

        Clipboard.SetText(StrJson);

        // Cole aqui: https://jsoneditoronline.org/
        MessageBox.Show(StrJson, "* Copiado p/ Área de Transferência, cole em: 'jsoneditoronline.org' ", MessageBoxButtons.OK);
    }

    #endregion

}
