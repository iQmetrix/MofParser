﻿using Kingsland.MofParser.Lexing;

namespace Kingsland.MofParser.Tokens
{

    public sealed class BlockOpenToken : Token
    {

        internal BlockOpenToken(SourceExtent extent)
            : base(extent)
        {
        }

    }

}
