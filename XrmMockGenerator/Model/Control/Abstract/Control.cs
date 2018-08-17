#region Imports

using System.Collections.Generic;

#endregion

namespace Yagasoft.XrmMockGenerator.Model.Control.Abstract
{
	public abstract class Control
	{
		public string Name { get; set; }
		public bool IsVisible { get; set; }
		public IDictionary<int, string> Labels { get; set; }
	}
}
