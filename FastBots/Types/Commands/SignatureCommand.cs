using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FastBots.Types.Commands
{
    public abstract class SignatureCommand : IComparable<SignatureCommand>, IComparable
    {
        public abstract string Code { get; set; }

        public abstract int Status { get; set; }

        public int CompareTo([AllowNull] SignatureCommand signature)
        {
            if (signature == null)
            {
                throw new NullReferenceException("Signature is null");
            }

            if (signature.Code == null || signature.Code.Equals(Code))
            {
                return Status.CompareTo(signature.Status);
            }
            else
            {
                return -1;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is SignatureCommand)
            {
                return CompareTo(obj as SignatureCommand);
            }
            else
            {
                throw new InvalidCastException("Unexpected compare");
            }
        }
    }
}
