using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Yagasoft.XrmMockGenerator.Model;

namespace Yagasoft.XrmMockGenerator.Generator
{
    public class ContextGenerator
    {
	    public Context Generate(IOrganizationService service, Guid selectedUserId)
	    {
		    var xrmContext = new XrmServiceContext(service);
		    var userRoles = xrmContext.SystemUserRolesSet
			    .Where(e => e.SystemUserId == selectedUserId).Select(e => e.RoleId.GetValueOrDefault()).ToList();
		    var userSettings = xrmContext.UserSettingsSet
			    .Where(e => e.SystemUserIdId == selectedUserId).Select(e => e).FirstOrDefault();
		    var user = xrmContext.UserSet.Where(e => e.UserId == selectedUserId).Select(e => e).FirstOrDefault();
		    var organisation = xrmContext.OrganizationSet.Select(e => e).FirstOrDefault();
		    var theme = xrmContext.ThemeSet.Where(e => e.DefaultTheme == true).Select(e => e).FirstOrDefault();
		    var versionRequest = new RetrieveVersionRequest();
		    var version = ((RetrieveVersionResponse)service.Execute(versionRequest)).Version;

		    return
			    new Context
				{
					UserId = user?.UserId ?? Guid.Empty,
					Username = user?.UserName,
					UserFullName = user?.FullName,
					IsGuidedHelpEnabled = userSettings?.EnableDefaultGuidedHelp ?? false,
					UserLanguageCode = userSettings?.UILanguageId ?? 1033,
					TimeZoneBias = userSettings?.TimeZoneBias ?? 0,
					UserRoles = userRoles,
					OrganisationUrl = organisation?.ExternalBaseURL,
					IsAutoSaveEnabled = organisation?.AutoSaveEnabled ?? false,
					OrgLanguageCode = organisation?.Language ?? 1033,
					OrganisationName = organisation?.OrganizationName,
					ThemeName = theme?.ThemeName,
					CrmVersion = version
				};
		}
	}
}
