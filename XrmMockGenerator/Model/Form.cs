#region Imports

using System.Collections.Generic;
using Yagasoft.XrmMockGenerator.Model.Control;

#endregion

namespace Yagasoft.XrmMockGenerator.Model
{
	public class Form
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public List<Tab> Tabs { get; set; }
	}
}
