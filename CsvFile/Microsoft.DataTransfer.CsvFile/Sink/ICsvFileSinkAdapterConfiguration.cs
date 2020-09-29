using System.ComponentModel.DataAnnotations;

namespace Microsoft.DataTransfer.CsvFile.Sink
{
    /// <summary>
    /// Contains configuration for CSV files data sink adapter. 
    /// </summary>
    public interface ICsvFileSinkAdapterConfiguration
    {
        /// <summary>
        /// Gets the path to the file to store CSV data to.
        /// </summary>
        [Display(ResourceType = typeof(ConfigurationResources), Description = "Sink_File")]
        string File { get; }

        /// <summary>
        /// Gets the value that indicates whether target file can be overwritten.
        /// </summary>
        [Display(ResourceType = typeof(ConfigurationResources), Description = "Sink_Overwrite")]
        bool Overwrite { get; }

        /// <summary>
        /// Gets the value that indicates whether target file should contain headers in first row
        /// </summary>
        [Display(ResourceType = typeof(ConfigurationResources), Description = "Sink_WriteHeader")]
        bool WriteHeader { get; }

        /// <summary>
        /// Gets the value that indicates the string that should delimit values
        /// </summary>
        [Display(ResourceType = typeof(ConfigurationResources), Description = "Sink_Delimiter")]
        string Delimiter { get; }

    }
}
