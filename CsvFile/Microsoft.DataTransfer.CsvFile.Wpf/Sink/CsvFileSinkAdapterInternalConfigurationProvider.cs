using Microsoft.DataTransfer.Basics;
using Microsoft.DataTransfer.WpfHost.Extensibility.Basics;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Microsoft.DataTransfer.CsvFile.Wpf.Sink
{
    sealed class CsvFileSinkAdapterInternalConfigurationProvider : DataAdapterValidatableConfigurationProviderBase<CsvFileSinkAdapterConfiguration>
    {
        protected override UserControl CreatePresenter(CsvFileSinkAdapterConfiguration configuration)
        {
            return new CsvFileSinkAdapterConfigurationPage { DataContext = configuration };
        }

        protected override UserControl CreateSummaryPresenter(CsvFileSinkAdapterConfiguration configuration)
        {
            return new CsvFileSinkAdapterConfigurationSummaryPage { DataContext = configuration };
        }

        protected override CsvFileSinkAdapterConfiguration CreateValidatableConfiguration()
        {
            return new CsvFileSinkAdapterConfiguration();
        }

        protected override void PopulateCommandLineArguments(CsvFileSinkAdapterConfiguration configuration, IDictionary<string, string> arguments)
        {
            Guard.NotNull("configuration", configuration);
            Guard.NotNull("arguments", arguments);

            arguments.Add(CsvFileSinkAdapterConfiguration.FilePropertyName, configuration.File);

            if (configuration.Overwrite)
                arguments.Add(CsvFileSinkAdapterConfiguration.OverwritePropertyName, null);

            if (configuration.WriteHeader)
                arguments.Add(CsvFileSinkAdapterConfiguration.WriteHeaderPropertyName, null);

            arguments.Add(CsvFileSinkAdapterConfiguration.DelimiterPropertyName, null);
        }
    }
}
