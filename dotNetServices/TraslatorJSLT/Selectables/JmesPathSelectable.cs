using DevLab.JmesPath;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TraslatorJSLT.Selectables
{
    public class JmesPathSelectable : ISelectableToken
    {
        private readonly JmesPath _instance = new JmesPath();

        public string RootReference => string.Empty;
        public JToken Token { get; set; }

        [Obsolete]
        public JToken Select(string path)
        {
            return _instance.Transform(Token, path);
        }

        [Obsolete]
        public IEnumerable<JToken> SelectMultiple(string path)
        {
            return Select(path);
        }
    }
}
