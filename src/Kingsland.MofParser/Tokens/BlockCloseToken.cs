﻿using Kingsland.MofParser.Lexing;

namespace Kingsland.MofParser.Tokens
{

    public sealed class BlockCloseToken : Token
    {

        internal BlockCloseToken(SourceExtent extent)
            : base(extent)
        {
        }

    }

}
