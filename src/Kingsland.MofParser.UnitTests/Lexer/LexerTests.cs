﻿using Kingsland.MofParser.Lexing;
using Kingsland.MofParser.UnitTests.Helpers;
using NUnit.Framework;
using System.Collections;
using System.IO;

namespace Kingsland.MofParser.UnitTests.Lexer
{

    public static class LexerTests
    {

        [TestFixture]
        public static class LexMethodTokenTests
        {

            [Test, TestCaseSource(typeof(LexMethodTestCases), "TestCases")]
            public static void LexMethodTestsFromDisk(string mofFilename)
            {
                var mofText = File.ReadAllText(mofFilename);
                var tokens = Lexing.Lexer.Lex(new StringLexerStream(mofText));
                var actualText = TestUtils.ConvertToJson(tokens);
                var expectedFilename = Path.Combine(Path.GetDirectoryName(mofFilename),
                                                    Path.GetFileNameWithoutExtension(mofFilename) + ".json");
                if (!File.Exists(expectedFilename))
                {
                    File.WriteAllText(expectedFilename, actualText);
                }
                var expectedText = File.ReadAllText(expectedFilename);
                Assert.AreEqual(expectedText, actualText);
            }

            private static class LexMethodTestCases
            {
                public static IEnumerable TestCases
                {
                    get
                    {
                        return TestUtils.GetMofTestCase("..\\..\\Lexer\\TestCases");
                    }
                }
            }

        }

    }

}
