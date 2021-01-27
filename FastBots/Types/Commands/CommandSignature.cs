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
            if (baseCommand?.Code == null && baseCommand?.Status == null)
            {
                throw new NullReferenceException("Signature is null");
            }
            if (this.Code == null && baseCommand.Code == null)  // It's input 
            {
                return ((int)this.Status).CompareTo((int)baseCommand.Status);
            }
            else if (this.Code != null && baseCommand.Code != null)    // It's command or callback
            {
                return this.Code.CompareTo(baseCommand.Code);
            }
            else
            {
                return -1;
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
