using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetArgs
{
    /// <summary>
    /// A simple implementation of ArgumentParser that supports parsing of quoted strings
    /// </summary>
    public class DefaultParser : ArgumentParser
    {
        /// <summary>
        /// The character to use for recognizing quoted strings
        /// </summary>
        public char QuoteChar { get; set; }

        public DefaultParser()
        {
            QuoteChar = '"';
        }

        public override string[] Parse(string arguments)
        {
            List<string> args = new List<string>();
            int idxStart = 0, length = 0;
            bool inQuote = false;
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < arguments.Length; i++)
            {
                if (arguments[i] == QuoteChar)
                {
                    //Special handling of quotes: Terminate/begin quoted strings
                    if (inQuote)
                    {
                        //We just terminated a quoted string
                        args.Add(arguments.Substring(idxStart, length));
                        idxStart = i+1;
                        inQuote = false;
                        length = 0;
                    } else 
                    {
                        //A new quoted string begins, terminate any recognized string
                        if (length > 0)
                        {
                            args.Add(arguments.Substring(idxStart, length));
                            length = 0;
                        }
                        idxStart = i + 1;
                        inQuote = true;
                    }
                }
                else if (Char.IsWhiteSpace(arguments[i]))
                {
                    //Special handling of whitespaces: Terminate unquotes strings
                    if (!inQuote)
                    {
                        if (length > 0)
                            args.Add(arguments.Substring(idxStart, length));
                        idxStart = i + 1;
                        length = 0;
                    } else
                    {
                        length++;
                    }
                } else
                {
                    //Any other char is treated as part of an argument-string
                    length++;
                }
            }

            if (length > 0 && !inQuote)
                args.Add(arguments.Substring(idxStart, length));

            return args.ToArray();
        }
    }
}
