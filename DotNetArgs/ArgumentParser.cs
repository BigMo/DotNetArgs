using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetArgs
{
    /// <summary>
    /// An abstract class that defines methods for parsing arguments
    /// </summary>
    public abstract class ArgumentParser
    {
        /// <summary>
        /// Processes the given argument-string and returns the arguments parsed.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public abstract string[] Parse(string arguments);
    }
}
