using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.DataTransfer.CsvFile
{
    /// <summary>
    /// Contains default configuration for CSV data adapters.
    /// </summary>
    public static class Defaults
    {
        private static object updateLock = new Object();
        private static IDefaults current;

        /// <summary>
        /// Gets current default configuration for CSV data adapters.
        /// </summary>
        public static IDefaults Current
        {
            get { return GetCurrent(); }
        }

        private static IDefaults GetCurrent()
        {
            if (current == null) lock (updateLock) if (current == null)
                        current = new LibraryDefaults();

            return current;
        }

        private sealed class LibraryDefaults : IDefaults
        {
            public string SinkDelimiter { get { return ","; } }

            public bool SinkWriteHeader { get { return true; } }
        }
    }
}
