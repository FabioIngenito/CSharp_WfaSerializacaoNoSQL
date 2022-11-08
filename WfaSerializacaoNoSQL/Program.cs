// .NET - Sugestões e dicas para escrever um 'bom código'
// https://www.macoratti.net/13/09/net_pcod1.htm

namespace WfaSerializacaoNoSQL;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new FrmSerializacaoNoSQL());
    }
}