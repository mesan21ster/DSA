using System;
using System.Collections.Generic;
using System.Text;

namespace XmlParser
{
    public static class MyElementNodeFactory
    {
        public static MyElementNode ParseMe(IXmlElement rootNode, IXmlTreeParser parser) => parser.Parse(rootNode);// This method is a simple wrapper around the parser's Parse method. It takes an IXmlElement and an IXmlTreeParser, and returns a MyElementNode by calling the parser's Parse method with the given rootNode.
    }
}
