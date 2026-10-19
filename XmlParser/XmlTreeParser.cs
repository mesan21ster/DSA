using System;
using System.Collections.Generic;
using System.Text;

namespace XmlParser
{
    public sealed class XmlTreeParser : IXmlTreeParser
    {
        private readonly IPlaceholderResolver _placeholderResolver;
        private readonly ISettingsExtractor _settingsExtractor;
        public XmlTreeParser(IPlaceholderResolver placeholderResolver, ISettingsExtractor settingsExtractor)
        {
            _placeholderResolver = placeholderResolver;
            _settingsExtractor = settingsExtractor;
        }
        public MyElementNode Parse(IXmlElement root)
        {
            if (root is null) throw new ArgumentNullException(nameof(root));

            return ParseInternal(root);
        }

        private MyElementNode ParseInternal(IXmlElement element)
        {
            var rawChildren = element.GetChildren()?? new List<IXmlElement>();
            var parsedChildren = rawChildren.Select(ParseInternal).ToList();// Recursively parse children
            var settings = _settingsExtractor.ExtractSettings(element);
            foreach(var child in rawChildren)
            {
                if (string.Equals(child.GetName(), "Settings", StringComparison.OrdinalIgnoreCase))
                {
                    var childSettings = _settingsExtractor.ExtractSettings(child);
                    foreach (var kvp in childSettings)
                    {
                        settings[kvp.Key] = kvp.Value;// Override parent settings with child settings
                    }
                }
            }
            var resolvedSettings = _placeholderResolver.Resolve(settings);
            return new MyElementNode(element.GetName(), parsedChildren, new Dictionary<string, string>(resolvedSettings));// Create a new MyElementNode with the resolved settings
        }
    }
}
