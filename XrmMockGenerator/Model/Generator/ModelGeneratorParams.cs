#region Imports

using System;
using System.Collections.Generic;

#endregion

namespace Yagasoft.XrmMockGenerator.Model.Generator
{
	public class ModelGeneratorParams
	{
		public string EntityName { get; set; }
		public Guid SelectedUserId { get; set; }
		public List<Guid> SelectedForms { get; set; }
	}
}
