﻿using Kingsland.MofParser.Lexing;

namespace Kingsland.MofParser.Tokens
{

    public sealed class PragmaToken : Token
    {

        internal PragmaToken(SourceExtent extent)
            : base(extent)
        {
        }

    }

}
