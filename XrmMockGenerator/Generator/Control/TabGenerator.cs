#region Imports

using System.Linq;
using System.Xml;
using Yagasoft.XrmMockGenerator.Generator.Abstract;
using Yagasoft.XrmMockGenerator.Model.Constants;
using Yagasoft.XrmMockGenerator.Model.Control;

#endregion

namespace Yagasoft.XrmMockGenerator.Generator.Control
{
	public class TabGenerator : IGeneratableFromXml<Tab>
	{
		public Tab Generate(XmlNode tabXml, XmlDocument doc)
		{
			return
				new Tab
				{
					Id = tabXml.SelectSingleNode("@name")?.Value,
					Labels = tabXml.SelectNodes(FormXmlContants.LabelPath)?.Cast<XmlNode>()
						.ToDictionary(
							e => int.Parse(e.SelectSingleNode("@languagecode")?.Value ?? "1033"),
							e => e.SelectSingleNode("@description")?.Value),
					IsVisible = tabXml.SelectSingleNode("@visible")?.Value != "false",
					Sections = tabXml.SelectNodes(FormXmlContants.SectionPath)?.Cast<XmlNode>()
						.Select(xmlNode => new SectionGenerator().Generate(xmlNode, doc)).ToList()
				};
		}
	}
}
