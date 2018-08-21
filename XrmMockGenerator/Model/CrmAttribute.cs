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
		public int? InitialValue { get; set; }
		public bool? DefaultBoolValue { get; set; }
		public decimal? Min { get; set; }
		public decimal? Max { get; set; }
		public int? Precision { get; set; }
		public int? MaxLength { get; set; }
		public IDictionary<int, Dictionary<int, string>> Options { get; set; }
	}
}
