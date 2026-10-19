using System;
using System.Collections.Generic;
using System.Text;

namespace XmlParser
{
    public sealed class SettingsExtractor: ISettingsExtractor
    {
        public IDictionary<string, string> ExtractSettings(IXmlElement element)
        {
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (string.Equals(element.GetName(), "Settings", StringComparison.OrdinalIgnoreCase))
                return dict;

            foreach (var child in element.GetChildren())
            {
                if(!string.Equals(child.GetName(),"Setting", StringComparison.OrdinalIgnoreCase))
                    continue;

                var attributes = child.GetAttributes() ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                if(!attributes.TryGetValue("Name", out var name) || string.IsNullOrWhiteSpace(name))
                    continue;

                attributes.TryGetValue("Value", out var value);
                dict[name.Trim()] = (value ?? string.Empty).Trim();
            }
            return dict;
        }
    }
}
