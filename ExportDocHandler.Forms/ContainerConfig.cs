using Autofac;
using EDH.Library;

namespace ExportDocHandles
{
    public class ContainerConfig
    {
        /// <summary>
        /// Registers our dependencies
        /// </summary>
        /// <returns>An IContainer</returns>
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DocHandler>().As<IDocHandler>();
            builder.RegisterType<DocumentCreator>().As<IDocumentCreator>();
            builder.RegisterType<ExcelReader>().As<IExcelReader>();
            builder.RegisterType<FileHandler>().As<IFileHandler>();

            builder.RegisterType<ExportDocsHandlerForm>().AsSelf();

            return builder.Build();
        }
    }
}
