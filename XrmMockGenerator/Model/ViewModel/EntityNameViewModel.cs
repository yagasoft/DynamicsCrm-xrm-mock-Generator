using System;

namespace Yagasoft.XrmMockGenerator.Model.ViewModel
{
	public class EntityNameViewModel : IComparable<EntityNameViewModel>
	{
		internal string LogicalName { get; set; }
		internal string DisplayName { get; set; }

		public override string ToString()
		{
			return DisplayName;
		}

		public int CompareTo(EntityNameViewModel obj)
		{
			return string.Compare(DisplayName, obj.DisplayName, StringComparison.Ordinal);
		}
	}
}
