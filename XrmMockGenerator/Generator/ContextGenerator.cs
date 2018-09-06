#region Imports

using System;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Yagasoft.XrmMockGenerator.Model;

#endregion

namespace Yagasoft.XrmMockGenerator.Generator
{
	public class ContextGenerator
	{
		public Context Generate(IOrganizationService service, Guid selectedUserId)
		{
			var xrmContext = new XrmServiceContext(service);

			var userRoles = xrmContext.CreateQuery(SystemUserRoles.EntityLogicalName)
				.Where(e => e.GetAttributeValue<EntityReference>(SystemUserRoles.Fields.SystemUserId).Id == selectedUserId)
				.Select(e => e.GetAttributeValue<Guid?>(SystemUserRoles.Fields.RoleId).GetValueOrDefault()).ToList();
			var userSettings = xrmContext.CreateQuery(UserSettings.EntityLogicalName)
				.Where(e => e.GetAttributeValue<EntityReference>(UserSettings.Fields.SystemUserIdId).Id == selectedUserId)
				.Select(e => e).FirstOrDefault();
			var user = xrmContext.CreateQuery(User.EntityLogicalName)
				.Where(e => e.GetAttributeValue<Guid?>(SystemUserRoles.Fields.SystemUserId) == selectedUserId)
				.Select(e => e).FirstOrDefault();
			var organisation = xrmContext.CreateQuery(Organization.EntityLogicalName)
				.Select(e => e).FirstOrDefault();
			var theme = xrmContext.CreateQuery(Theme.EntityLogicalName)
				.Where(e => e.GetAttributeValue<bool?>(Theme.Fields.DefaultTheme) == true)
				.Select(e => e).FirstOrDefault();

			var versionRequest = new RetrieveVersionRequest();
			var version = ((RetrieveVersionResponse)service.Execute(versionRequest)).Version;

			return
				new Context
				{
					UserId = user?.GetAttributeValue<Guid?>(User.Fields.UserId) ?? Guid.Empty,
					Username = user?.GetAttributeValue<string>(User.Fields.UserName),
					UserFullName = user?.GetAttributeValue<string>(User.Fields.FullName),
					IsGuidedHelpEnabled = userSettings?
						.GetAttributeValue<bool?>(UserSettings.Fields.EnableDefaultGuidedHelp) ?? false,
					UserLanguageCode = userSettings?.GetAttributeValue<int?>(UserSettings.Fields.UILanguageId) ?? 1033,
					TimeZoneBias = userSettings?.GetAttributeValue<int?>(UserSettings.Fields.TimeZoneBias) ?? 0,
					UserRoles = userRoles,
					OrganisationUrl = organisation?.GetAttributeValue<string>(Organization.Fields.ExternalBaseURL),
					IsAutoSaveEnabled = organisation?.GetAttributeValue<bool?>(Organization.Fields.AutoSaveEnabled) ?? false,
					OrgLanguageCode = organisation?.GetAttributeValue<int?>(Organization.Fields.Language) ?? 1033,
					OrganisationName = organisation?.GetAttributeValue<string>(Organization.Fields.OrganizationName),
					ThemeName = theme?.GetAttributeValue<string>(Theme.Fields.ThemeName),
					CrmVersion = version
				};
		}
	}
}
