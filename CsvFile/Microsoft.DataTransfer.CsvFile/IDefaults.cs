namespace Microsoft.DataTransfer.CsvFile
{
    /// <summary>
    /// Contains default configuration for CSV data adapters.
    /// </summary>
    public interface IDefaults
    {
        /// <summary>
        /// Gets the default value determining whether the header will be written
        /// </summary>
        bool SinkWriteHeader { get; }

        /// <summary>
        /// Gets the default string delimiter
        /// </summary>
        string SinkDelimiter { get; }

    }
}
