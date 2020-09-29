using Microsoft.DataTransfer.Basics;
using Microsoft.DataTransfer.Basics.Files.Sink;
using Microsoft.DataTransfer.CsvFile.Writer;
using Microsoft.DataTransfer.Extensibility;
using Microsoft.DataTransfer.Extensibility.Basics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.DataTransfer.CsvFile.Sink
{
    /// <summary>
    /// Provides data sink adapters capable of writing data to CSV file.
    /// </summary>
    public sealed class CsvFileSinkAdapterFactory : DataAdapterFactoryBase, IDataSinkAdapterFactory<ICsvFileSinkAdapterConfiguration>
    {
        /// <summary>
        /// Gets the description of the data adapter.
        /// </summary>
        public string Description
        {
            get { return Resources.SinkDescription; }
        }

        /// <summary>
        /// Creates a new instance of <see cref="IDataSinkAdapter" /> with the provided configuration.
        /// </summary>
        /// <param name="configuration">Data sink adapter configuration.</param>
        /// <param name="context">Data transfer operation context.</param>
        /// <param name="cancellation">Cancellation token.</param>
        /// <returns>Task that represents asynchronous create operation.</returns>
        public async Task<IDataSinkAdapter> CreateAsync(ICsvFileSinkAdapterConfiguration configuration, IDataTransferContext context, CancellationToken cancellation)
        {
            Guard.NotNull("configuration", configuration);

            return new CsvFileSinkAdapter(
                new StreamWriter(
                    await SinkStreamProvidersFactory.Create(configuration.File, false, configuration.Overwrite)
                        .CreateStream(cancellation)),
                CsvWriterFactory.Create(configuration.WriteHeader, configuration.Delimiter));
        }
    }
}
