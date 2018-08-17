#region Imports

using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;

#endregion

namespace Yagasoft.XrmMockGenerator.Helpers
{
	public static class DataHelpers
	{
		public static IEnumerable<UserViewModel> RetrieveUsers(IOrganizationService service)
		{
			return
				from user in new XrmServiceContext(service).UserSet
				select
					new User
					{
						UserId = user.UserId,
						FullName = user.FullName
					}.ConvertTo<UserViewModel>();
		}

		public static IEnumerable<SystemFormViewModel> RetrieveForms(IOrganizationService service)
		{
			return
				from form in new XrmServiceContext(service).SystemFormSet
				where form.FormType == SystemForm.FormTypeEnum.Main
				select
					new SystemForm
					{
						FormIdId = form.FormIdId,
						Name = form.Name,
						ObjectTypeCode = form.ObjectTypeCode
					}.ConvertTo<SystemFormViewModel>();
		}
	}
}
