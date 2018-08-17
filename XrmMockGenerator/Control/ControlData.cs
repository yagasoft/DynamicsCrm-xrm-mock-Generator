#region Imports

using System.Collections.Generic;

#endregion

namespace Yagasoft.XrmMockGenerator.Control
{
	public static class ControlData
	{
		public static IEnumerable<SystemFormViewModel> Forms = new List<SystemFormViewModel>();
		public static List<SystemFormViewModel> SelectedForms = new List<SystemFormViewModel>();
	}

	internal class RetrieveResult
	{
		internal IEnumerable<UserViewModel> Users { get; set; }
		internal IEnumerable<SystemFormViewModel> Forms { get; set; }
	}
}
