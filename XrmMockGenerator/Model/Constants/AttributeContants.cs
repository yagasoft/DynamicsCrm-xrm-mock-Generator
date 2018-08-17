using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yagasoft.XrmMockGenerator.Model.Constants
{
    public class AttributeContants
    {
	    public static readonly IDictionary<string, string> AttributeTypeMap =
			new Dictionary<string, string>
			{
				{ "String", "string" },
				{ "Boolean", "boolean" },
				{ "DateTime", "datetime" },
				{ "Decimal", "decimal" },
				{ "Double", "double" },
				{ "Integer", "integer" },
				{ "Customer", "lookup" },
				{ "Lookup", "lookup" },
				{ "Owner", "lookup" },
				{ "Memo", "memo" },
				{ "Money", "money" },
				{ "Picklist", "optionset" },
				{ "State", "optionset" },
				{ "Status", "optionset" }
			};

	    public static readonly IDictionary<string, string> RequiredLevelMap =
		    new Dictionary<string, string>
			{
				{ "None", "none" },
				{ "Recommended", "recommended" },
				{ "SystemRequired", "required" },
				{ "ApplicationRequired", "required" }
			};

	}
}
