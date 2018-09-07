#region Imports

using System.Collections.Generic;
using Yagasoft.XrmMockGenerator.Model.ViewModel;

#endregion

namespace Yagasoft.XrmMockGenerator.Control
{
	public static class ControlData
	{
		public static bool? IsGenerateOnlineCode { get; set; }
		public static List<EntityNameViewModel> EntityNames = new List<EntityNameViewModel>();
		public static List<SystemFormViewModel> Forms = new List<SystemFormViewModel>();
		public static List<SystemFormViewModel> SelectedForms = new List<SystemFormViewModel>();
	}

	internal class RetrieveResult
	{
		internal IEnumerable<UserViewModel> Users { get; set; }
		internal IEnumerable<SystemFormViewModel> Forms { get; set; }
		internal IEnumerable<EntityNameViewModel> EntityNames { get; set; }
	}
}
