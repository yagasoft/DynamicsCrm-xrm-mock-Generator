using System.Collections.Generic;
using Yagasoft.XrmMockGenerator.Model;

namespace Yagasoft.XrmMockGenerator
{
    public partial class XrmMockGeneratorTemplate
    {
		private T4TemplateModel  templateModel;

	    public XrmMockGeneratorTemplate(T4TemplateModel templateModel)
	    {
		    this.templateModel = templateModel;
	    }
    }
}
