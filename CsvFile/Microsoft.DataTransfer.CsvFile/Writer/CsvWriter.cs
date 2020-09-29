using Microsoft.DataTransfer.Basics;
using Microsoft.DataTransfer.Extensibility;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.DataTransfer.CsvFile.Writer
{
    sealed class CsvWriter
    {
        private bool writeHeader;
        private string delimiter;

        public CsvWriter(bool writeHeaders, string delimiter)
        {
            this.writeHeader = writeHeaders;
            this.delimiter = delimiter;
        }

        public void Write(TextWriter writer, IDataItem item)
        {
            var fieldNames = item.GetFieldNames();
            if (writeHeader)
            {
                writer.WriteLine(CreateRow(fieldNames));
                writeHeader = false;
            }

            writer.WriteLine(CreateRow(fieldNames.Select(x => item.GetValue(x))));
        }

        private string CreateRow(IEnumerable<object> values)
            => string.Join(delimiter, values);

    }
}
