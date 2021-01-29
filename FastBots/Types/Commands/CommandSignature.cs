using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FastBots.Types.Commands
{
    /// <summary>
    /// If Code is null then it's input<br/>
    /// If Status is null then it's command<br/>
    /// If Code and Status aren't null then it's callback
    /// </summary>
    public class CommandSignature : IComparable<CommandSignature>, IComparable
    {
        public string Code { get; set; }

        public int? Status { get; set; }

        public int CompareTo([AllowNull] CommandSignature baseCommand)
        {
            if (baseCommand.Code != null && Code != null)
            {
                if(baseCommand.Code.StartsWith('/') && Code.StartsWith('/'))    // Command command
                {
                    return this.Code.CompareTo(baseCommand.Code);
                }
                else if (baseCommand.Code.StartsWith('/'))  // Command callback
                {
                    return -1;
                }
                else if (Code.StartsWith('/'))  // Callback command
                {
                    return 1;
                }
                else // Callback callback
                {
                    return this.Code.CompareTo(baseCommand.Code);
                }
            }
            else if (baseCommand.Code != null)
            {
                return -1;
            }
            else if (this.Code != null)
            {
                return 1;
            }
            else // Input
            {
                return this.Status.Value.CompareTo(baseCommand.Status.Value);
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is CommandSignature)
            {
                return CompareTo(obj as CommandSignature);
            }
            else
            {
                throw new InvalidCastException("Unexpected compare");
            }
        }
    }
}
