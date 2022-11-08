using MongoDB.Bson;
using static System.Windows.Forms.Design.AxImporter;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using InputBox;
using static System.Net.WebRequestMethods;

namespace ClsSerializacaoNoSQL.BLL;

public class ClsFormularioBLL
{
    /// <summary>
    /// Ajustar os estados dos botões de acordo com o evento disparado.
    /// </summary>
    /// <param name="parent">Formulário chamado.</param>
    /// <param name="bytBotoes">Código do tipo de ação.</param>
    public static void AjustaBotoes(Control parent, byte bytBotoes)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(Button))
            {
                switch (bytBotoes)
                {
                    //1 - Entrada de dados
                    case 1:
                        if (c.Name == "BtnIncluir") { c.Text = "&Salvar"; }

                        if (c.Name == "BtnAlterar")
                        {
                            c.Text = "&Cancelar";
                            c.Enabled = true;
                        }

                        if (c.Name == "BtnLimpar") { c.Enabled = true; }
                        if (c.Name == "BtnPesquisar") { c.Enabled = false; }
                        if (c.Name == "BtnExcluir") { c.Enabled = false; }
                        if (c.Name == "BtnFiltrar") { c.Enabled = false; }

                        break;

                    //2 - Existe algo cadastrado
                    case 2:
                        if (c.Name == "BtnIncluir") { c.Text = "&Incluir"; }

                        if (c.Name == "BtnAlterar")
                        {
                            c.Text = "&Alterar";
                            c.Enabled = true;
                        }

                        if (c.Name == "BtnLimpar") { c.Enabled = false; }
                        if (c.Name == "BtnPesquisar") { c.Enabled = true; }
                        if (c.Name == "BtnExcluir") { c.Enabled = true; }
                        if (c.Name == "BtnFiltrar") { c.Enabled = true; }

                        break;

                    //3 - Não existe nada cadastrado
                    case 3:
                        if (c.Name == "BtnIncluir") { c.Text = "&Incluir"; }

                        if (c.Name == "BtnAlterar")
                        {
                            c.Text = "&Alterar";
                            c.Enabled = false;
                        }

                        if (c.Name == "BtnLimpar") { c.Enabled = false; }
                        if (c.Name == "BtnPesquisar") { c.Enabled = false; }
                        if (c.Name == "BtnExcluir") { c.Enabled = false; }
                        if (c.Name == "BtnFiltrar") { c.Enabled = false; }

                        break;

                    //4 - Não existe nada cadastrado na Tabela Pai 
                    //  -> Obrigatório preenchimento da Chave Estrangeira, não deixa trabalhar no formulário.
                    case 4:
                        if (c.Name == "BtnIncluir") { c.Enabled = false; }
                        if (c.Name == "BtnAlterar") { c.Enabled = false; }
                        if (c.Name == "BtnLimpar") { c.Enabled = false; }
                        if (c.Name == "BtnPesquisar") { c.Enabled = false; }
                        if (c.Name == "BtnExcluir") { c.Enabled = false; }
                        if (c.Name == "BtnFiltrar") { c.Enabled = false; }

                        break;
                }
            }
        }
    }

    /// <summary>
    /// Limpar a caixas de texto.
    /// </summary>
    /// <param name="parent">TextBox</param>
    /// <param name="tb">Control</param>
    public static void EmptyTextBoxes(Control parent, TextBox tb)
    {
        foreach (Control c in parent.Controls)
        {
            if (c is TextBox)
            {
                if (c.Name != tb.Name) c.Text = "";
                else tb.Focus();
            }

            if (c is MaskedTextBox) c.Text = "";

            if (c is ComboBox) c.Text = "";
        }
    }

    /// <summary>
    /// Limpar a caixas de texto.
    /// </summary>
    /// <param name="parent">MaskedTextBox</param>
    /// <param name="tb">Control</param>
    public static void EmptyTextBoxes(Control parent, MaskedTextBox tb)
    {
        foreach (Control c in parent.Controls)
        {
            if (c is TextBox)
            {
                if (c.Name != tb.Name) c.Text = "";
                else tb.Focus();
            }

            if (c is MaskedTextBox) c.Text = "";

            if (c is ComboBox) c.Text = "";
        }
    }

    /// <summary>
    /// Não existe "inputbox" no C#!!!
    /// Então fui perguntar para o Macoratti...
    /// Site:
    /// http://www.macoratti.net/10/10/c_inbox.htm
    /// 
    /// Mas... começou a apresentar erro por obsolência, então descontinuei... 
    /// 
    /// How to fix error Could not load file or assembly
    /// 10 de dez.de 2012
    /// Vis Dotnet
    /// https://youtu.be/cVFryoIsu2c
    /// </summary>
    /// <param name="prompt">Texto que aparece para o usuário.</param>
    /// <param name="title">Título de formulário</param>
    /// <param name="defaultValue">Valor Padrão da caixa de texto - opcional</param>
    /// <returns>Retorna o valor digitado na caixa de texto.</returns>
    public static string InputBox(string prompt, string title, string defaultValue)
    {
        using InputBoxDialog ib = new();

        ib.FormPrompt = prompt;
        ib.FormCaption = title;
        ib.DefaultValue = defaultValue;
        ib.ShowDialog();

        string? s = ib.InputResponse;

        ib.Close();

        if (s == string.Empty)
            return "";
        else
            return s;
    }

    /// <summary>
    /// Do site:
    /// http://support.microsoft.com/kb/329488
    /// </summary>
    /// <param name="Expression">Número ou nome</param>
    /// <returns>True = É Número or False = NÃO é Número</returns>
    public static bool IsNumeric(object Expression)
    {
        return Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out _); ;
    }

    /// <summary>
    /// Limpar a máscara do CPF para gravá-lo.
    /// </summary>
    /// <param name="CPF">Número do CPF.</param>
    /// <returns>Número do CPF sem máscara.</returns>
    public static string LimpaMascaraCPF(string CPF)
    {
        CPF = CPF.Replace(".", "").Replace("-", "").Replace(" ", "");
        return CPF;
    }

    /// <summary>
    /// Limpar a máscara do Valor Monetário para gravá-lo.
    /// </summary>
    /// <param name="ValorMonetario">Número do Valor Monetário.</param>
    /// <returns>Número do Valor Monetário sem máscara.</returns>
    public static string LimpaMascaraValorMonetario(string ValorMonetario)
    {
        ValorMonetario = ValorMonetario.Replace("R$", "").Replace(".", "").Replace(" ", "");
        return ValorMonetario;
    }

    /// <summary>
    /// Limpar a máscara do Telefone para gravá-lo.
    /// </summary>
    /// <param name="Telefone">Número do Telefone.</param>
    /// <returns>Número do Telefone sem máscara.</returns>
    public static string LimpaMascaraTelefone(string Telefone)
    {
        Telefone = Telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
        return Telefone;
    }

    /// <summary>
    /// Trata a aspas simples em todos os campos exto para gravá-lo.
    /// </summary>
    /// <param name="Telefone">Campo.</param>
    /// <returns>Campo com aspa sim ples tratada.</returns>
    public static string TrataAspa(string Campo)
    {
        Campo = Campo.Replace("'", "''");
        return Campo;
    }

    /// <summary>
    /// Trata a aspas simples em todos os campos exto para gravá-lo.
    /// </summary>
    /// <param name="Telefone">Campo.</param>
    /// <returns>Campo com aspa sim ples tratada.</returns>
    public static string LimpaAspa(string Campo)
    {
        Campo = Campo.Replace("'", "");
        return Campo;
    }

    /// <summary>
    /// Verifica se é numérico
    /// </summary>
    /// <param name="text">Uma string</param>
    /// <returns>True or False</returns>
    public static bool IsNumeric(string text)
    {
        return double.TryParse(text, out _);
    }

    /// <summary>
    /// É preciso configurar o JsonSerializer para aceitar ACENTUAÇÃO.
    /// Existem várias configurações e personalizações de acordo com a necessidade.
    /// </summary>
    /// <returns>Retorna opções de configuração do JsonSerializer.</returns>
    public static JsonSerializerOptions ConfiguraJson()
    {
        JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            //Encoder = JavaScriptEncoder.Create(encoderSettings),
            //WriteIndented = true
        };

        return options;
    }
}
