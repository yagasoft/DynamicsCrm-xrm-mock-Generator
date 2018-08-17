using System.Collections.Generic;
using Yagasoft.XrmMockGenerator.Model;

namespace Yagasoft.XrmMockGenerator
{
    public partial class XrmMockGeneratorTemplate
    {
		private List<XrmModel>  models;

	    public XrmMockGeneratorTemplate(List<XrmModel> models)
	    {
		    this.models = models;
	    }
    }
}
