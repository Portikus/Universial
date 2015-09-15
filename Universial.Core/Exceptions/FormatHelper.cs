using System;
using Universial.Core.Utilities;

namespace Universial.Core.Exceptions
{
    /// <summary>
    /// Helper class for formated strings
    /// </summary>
    public static class FormatHelper
    {
        /// <summary>
        /// Formats an exception with a custom message.
        /// </summary>
        /// <param name="message">Additional message</param>
        /// <param name="exception">The occured exception</param>
        /// <returns>The foramted message containing custom message and exception details</returns>
        public static string FormatException(string message, Exception exception)
        {
            Guard.CheckIfNotNull(() => exception);
            return message + Environment.NewLine + "Exception details:" + Environment.NewLine + exception;
        }
    }
}
