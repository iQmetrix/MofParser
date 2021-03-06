﻿using Kingsland.MofParser.Lexing;

namespace Kingsland.MofParser.Tokens
{

    public sealed class IntegerLiteralToken : NumericLiteralToken
    {

        internal IntegerLiteralToken(SourceExtent extent, long value)
            : base(extent)
        {
            this.Value = value;
        }

        public long Value
        {
            get;
            private set;
        }

    }

}
