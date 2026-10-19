using System;
using System.Collections.Generic;
using System.Text;

namespace XmlParser
{
    public sealed class MyElementNode
    {
        public string Name { get; }
        public IReadOnlyList<MyElementNode> Children { get; }
        public IReadOnlyDictionary<string, string> Settings { get; }
        public MyElementNode(string name, List<MyElementNode> children, Dictionary<string, string> settings)
        {
            Name = name;
            Children = children.AsReadOnly();
            Settings = new Dictionary<string, string>(settings, StringComparer.OrdinalIgnoreCase);
        }
    }
}
