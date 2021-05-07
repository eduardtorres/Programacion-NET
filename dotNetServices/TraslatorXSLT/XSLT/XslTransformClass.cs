using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace TraslatorXSLT.XSLT
{    
    public class XslTransformClass
    {
        private const string filename = "XSLT/Productos.xml";
        private const string stylesheet = "XSLT/Productos.xslt";

        static void Main()
        {
            Transformar();
        }

        public static void Transformar()
        {
            XslTransform xslt = new XslTransform();
            xslt.Load(stylesheet);
            XPathDocument xpathdocument = new XPathDocument(filename);
            XmlTextWriter writer = new XmlTextWriter(Console.Out);
            writer.Formatting = Formatting.Indented;

            xslt.Transform(xpathdocument, null, writer, null);
        }
    }
}