using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Yagasoft.XrmMockGenerator.Generator.Abstract
{
    public interface IGeneratableFromXml<out TOutput>
    {
	    TOutput Generate(XmlNode controlXml, XmlDocument doc);
    }
}
