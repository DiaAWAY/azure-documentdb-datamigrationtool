using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.DataTransfer.CsvFile.Writer
{
   static class CsvWriterFactory
    {
        public static CsvWriter Create(bool writeHeaders, string delimiter)
        {
            return new CsvWriter(writeHeaders, delimiter);
        }
    }
}
