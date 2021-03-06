﻿using Kingsland.MofParser.Parsing;
using Kingsland.MofParser.Tokens;

namespace Kingsland.MofParser.Ast
{

    public abstract class LiteralValueAst : PrimitiveTypeValueAst
    {

        #region Constructors

        internal LiteralValueAst()
        {
        }

        #endregion

        #region Parsing Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        /// <remarks>
        ///
        /// See http://www.dmtf.org/sites/default/files/standards/documents/DSP0221_3.0.0a.pdf
        /// A.1 Value definitions
        ///
        ///     literalValue       = integerValue / realValue /
        ///                          stringValue / octetStringValue
        ///                          booleanValue /
        ///                          nullValue /
        ///                          dateTimeValue
        ///
        /// </remarks>
        internal new static LiteralValueAst Parse(ParserStream stream)
        {
            //Note: This is a good candidate for the strategy pattern
            var peek = stream.Peek();
			if (peek is IntegerLiteralToken)
            {
                // integerValue
                return IntegerValueAst.Parse(stream);
            }
            else if (peek is RealLiteralToken)
            {
                // doubleValue
                return RealValueAst.Parse(stream);
            }
            else if (peek is StringLiteralToken)
			{
                // stringValue
                return StringValueAst.Parse(stream);
			}
			else if (peek is BooleanLiteralToken)
			{
                // booleanValue
                return BooleanValueAst.Parse(stream);
			}
			else if (peek is NullLiteralToken)
			{
                // nullValue
                return NullValueAst.Parse(stream);
			}
            else
            {
				throw new UnexpectedTokenException(peek);
			}
        }

        internal static bool IsLiteralValueToken(Token token)
        {
            //Note: This is an excellent candidate for the strategy pattern
            return (token is NumericLiteralToken) ||
                   //(token is RealLiteralToken) ||
                   //(token is DateTimeLiteralToken) ||
                   (token is StringLiteralToken) ||
                   (token is BooleanLiteralToken) ||
                   //(token is OctetStringLiteralToken) ||
                   (token is NullLiteralToken);
        }

        #endregion

    }

}
