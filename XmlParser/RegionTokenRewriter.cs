using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XmlParser
{
    public sealed class RegionTokenRewriter : ITokenRewriter
    {
        private static readonly Regex RegionRegex = new Regex(@"%\s*Region\s*:\s*(?<key>[^%]+?)\s*%", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public string Rewrite(string input, IDictionary<string, string> settings)
        {
            if (string.IsNullOrEmpty(input) || settings is null || settings.Count == 0)
            {
                return string.Empty;
            }
            return RegionRegex.Replace(input, m =>
            {
                var rawKey = m.Groups["key"].Value?.Trim();
                if (string.IsNullOrEmpty(rawKey))
                    return m.Value;

                //exact match
                if (settings.TryGetValue(rawKey, out var exact))
                    return $"%Region:{exact}%";

                //no match

                return m.Value;
            });
        }
    }
}
