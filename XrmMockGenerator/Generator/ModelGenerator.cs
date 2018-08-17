#region Imports

using System.Linq;
using Microsoft.Xrm.Sdk;
using Yagasoft.XrmMockGenerator.Model;
using Yagasoft.XrmMockGenerator.Model.Generator;

#endregion

namespace Yagasoft.XrmMockGenerator.Generator
{
	public class ModelGenerator
	{
		public XrmModel Generate(IOrganizationService service, ModelGeneratorParams parameters)
		{
			var form = new FormGenerator();

			return
				new XrmModel
				{
					EntityName = parameters.EntityName,
					Context = new ContextGenerator().Generate(service, parameters.SelectedUserId),
					CrmAttributes = new AttributeGenerator().Generate(service, parameters.EntityName).ToList(),
					Forms = parameters.SelectedForms.Select(f => form.Generate(service, f)).ToList()
				};
		}
	}
}
