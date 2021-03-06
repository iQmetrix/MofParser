﻿using Kingsland.MofParser.Parsing;
using Kingsland.MofParser.Tokens;

namespace Kingsland.MofParser.Ast
{

    public abstract class ComplexTypeValueAst : MofProductionAst
    {

        #region Constructors

        internal ComplexTypeValueAst()
        {
        }

        #endregion

        #region Properties

        public QualifierListAst Qualifiers
        {
            get;
            private set;
        }

        #endregion

        #region Parsing Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///
        /// See http://www.dmtf.org/sites/default/files/standards/documents/DSP0221_3.0.0a.pdf
        /// A.14 Complex type value
        ///
        ///     complexTypeValue  = complexValue / complexValueArray
        ///
        /// </remarks>
        internal static ComplexTypeValueAst Parse(ParserStream stream, QualifierListAst qualifiers)
        {

            var node = default(ComplexTypeValueAst);

            var peek = stream.Peek();
            if (peek is BlockOpenToken)
            {
                // complexValueArray
                node = ComplexValueArrayAst.Parse(stream);
            }
            else if (peek is IdentifierToken)
            {
                // complexValue
                node = ComplexValueAst.Parse(stream);
            }
            else
            {
                throw new UnexpectedTokenException(peek);
            }

            node.Qualifiers = qualifiers;

            return node;

        }

        #endregion

    }

}
