using Autofac;
using System;
using System.Windows.Forms;

namespace ExportDocHandles
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ExportDocsHandlerForm exportDocsHandler = ContainerConfig.Configure().Resolve<ExportDocsHandlerForm>();
            Application.Run(exportDocsHandler);
        }
    }
}
