using Microsoft.DataTransfer.Basics.Extensions;
using Microsoft.DataTransfer.CsvFile.Sink;
using Microsoft.DataTransfer.WpfHost.Basics;

namespace Microsoft.DataTransfer.CsvFile.Wpf.Sink
{
    sealed class CsvFileSinkAdapterConfiguration : ValidatableBindableBase, ICsvFileSinkAdapterConfiguration
    {
        public static readonly string FilePropertyName = 
            ObjectExtensions.MemberName<ICsvFileSinkAdapterConfiguration>(c => c.File);

        public static readonly string OverwritePropertyName = 
            ObjectExtensions.MemberName<ICsvFileSinkAdapterConfiguration>(c => c.Overwrite);

        public static readonly string WriteHeaderPropertyName =
            ObjectExtensions.MemberName<ICsvFileSinkAdapterConfiguration>(c => c.WriteHeader);

        public static readonly string DelimiterPropertyName =
            ObjectExtensions.MemberName<ICsvFileSinkAdapterConfiguration>(c => c.Delimiter);

        private string file;
        private bool overwrite;
        private bool header;
        private string delimiter;

        public string File
        {
            get { return file; }
            set { SetProperty(ref file, value, ValidateNonEmptyString); }
        }

        public bool Overwrite
        {
            get { return overwrite; }
            set { SetProperty(ref overwrite, value); }
        }

        public bool WriteHeader
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }

        public string Delimiter
        {
            get { return delimiter; }
            set { SetProperty(ref delimiter, value); }
        }

        public CsvFileSinkAdapterConfiguration()
        {
            WriteHeader = Defaults.Current.SinkWriteHeader;
            Delimiter = Defaults.Current.SinkDelimiter;
        }
    }
}
