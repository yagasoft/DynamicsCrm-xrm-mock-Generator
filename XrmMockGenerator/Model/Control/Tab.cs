#region Imports

using System.Collections.Generic;

#endregion

namespace Yagasoft.XrmMockGenerator.Model.Control
{
	public class Tab
	{
		public string Id { get; set; }
		public IDictionary<int, string> Labels { get; set; }
		public bool IsVisible { get; set; }
		public List<Section> Sections { get; set; }
	}
}
