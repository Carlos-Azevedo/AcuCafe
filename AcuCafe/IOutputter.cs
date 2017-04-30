using System;

namespace AcuCafe
{
    /// <summary>
    /// Interface for writting to disk and console
    /// </summary>
    public interface IOutputter
    {
        /// <summary>
        /// Writes an error message to console and creates a log text file
        /// </summary>
        /// <param name="ex">
        /// Exception from which information is pulled
        /// </param>
        void LogError(Exception ex);

        /// <summary>
        /// Writes the <paramref name="desc"/> to console
        /// </summary>
        /// <param name="desc">
        /// String to be written to console
        /// </param>
        void WriteToConsole(string desc);
    }
}
