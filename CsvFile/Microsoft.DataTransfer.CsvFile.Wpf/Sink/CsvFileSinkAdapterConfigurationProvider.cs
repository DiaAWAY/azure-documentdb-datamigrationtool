using Microsoft.DataTransfer.WpfHost.Extensibility.Basics;

namespace Microsoft.DataTransfer.CsvFile.Wpf.Sink
{
    /// <summary>
    /// Provides configuration for Csv file data sink.
    /// </summary>
    public sealed class CsvFileSinkAdapterConfigurationProvider : DataAdapterConfigurationProviderWrapper
    {
        /// <summary>
        /// Creates a new instance of <see cref="CsvFileSinkAdapterConfigurationProvider" />.
        /// </summary>
        public CsvFileSinkAdapterConfigurationProvider()
            : base(new CsvFileSinkAdapterInternalConfigurationProvider()) { }
    }
}
