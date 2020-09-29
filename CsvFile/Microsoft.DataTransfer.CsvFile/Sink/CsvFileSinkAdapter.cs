using Microsoft.DataTransfer.Basics;
using Microsoft.DataTransfer.Basics.Threading;
using Microsoft.DataTransfer.CsvFile.Writer;
using Microsoft.DataTransfer.Extensibility;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.DataTransfer.CsvFile.Sink
{
    sealed class CsvFileSinkAdapter : IDataSinkAdapter
    {
        private StreamWriter streamWriter;
        private CsvWriter csvWriter;

        public int MaxDegreeOfParallelism { get { return 1; } }

        public CsvFileSinkAdapter(StreamWriter streamWriter, CsvWriter csvWriter)
        {
            Guard.NotNull("streamWriter", streamWriter);
            Guard.NotNull("writer", csvWriter);

            this.streamWriter = streamWriter;
            this.csvWriter = csvWriter;
        }

        public Task WriteAsync(IDataItem dataItem, CancellationToken cancellation)
        {
            csvWriter.Write(streamWriter, dataItem);
            return Task.FromResult<object>(null);
        }

        public Task CompleteAsync(CancellationToken cancellation)
        {
            // Do not close an array here
            // This call just indicates that there will be no more items, but write tasks might not be completed yet
            return TaskHelper.NoOp;
        }

        public void Dispose()
        {
            /*
             * Don't do this in try-catch as we want to get a BlobAlreadyExists exception from
             * BLOB storage, that only happens on commit (dispose of the stream).
            */
            streamWriter.Dispose();
        }
    }
}
