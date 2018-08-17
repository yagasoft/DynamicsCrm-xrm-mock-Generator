#region Imports

using System.Collections.Generic;

#endregion

namespace Yagasoft.XrmMockGenerator.Model
{
	public class CrmAttribute
	{
		public string AttributeType { get; set; }
		public string Name { get; set; }
		public string RequiredLevel { get; set; }
		public string Format { get; set; }
		public IDictionary<int, Dictionary<int, string>> Options { get; set; }
	}
}
