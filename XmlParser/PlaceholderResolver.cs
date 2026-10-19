using System;
using System.Collections.Generic;
using System.Text;

namespace XmlParser
{
    public sealed class PlaceholderResolver : IPlaceholderResolver
    {
        private readonly ITokenRewriter _tokenRewriter;
        public PlaceholderResolver(ITokenRewriter tokenRewriter)
        {
            _tokenRewriter = tokenRewriter ?? throw new ArgumentNullException(nameof(tokenRewriter));
        }
        public IDictionary<string, string> Resolve(IDictionary<string, string> settings)
        {
            var result = new Dictionary<string, string>(settings, StringComparer.OrdinalIgnoreCase);

            foreach (var kvp in settings.Keys.ToList())
            {
                var val = result[kvp] ?? string.Empty;
                result[kvp] = _tokenRewriter.Rewrite(val, settings);
            }
            return result;
        }
    }
}
