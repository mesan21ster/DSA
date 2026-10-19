using System;
using System.Collections.Generic;
using System.Text;

namespace XmlParser
{
    public interface IXmlElement
    {
        string GetName();
        List<IXmlElement> GetChildren();
        IDictionary<string, string> GetAttributes();
    }
    public interface IXmlTreeParser
    {
        MyElementNode Parse(IXmlElement root);
    }
    public interface ISettingsExtractor
    {
        IDictionary<string, string> ExtractSettings(IXmlElement element);
    }
    public interface IPlaceholderResolver
    {
     IDictionary<string, string> Resolve(IDictionary<string, string> settings);
    }
    public interface ITokenRewriter
    {
        string Rewrite(string input, IDictionary<string, string> settings);
    }
}
