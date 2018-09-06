#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using Yagasoft.XrmMockGenerator.Model;
using Yagasoft.XrmMockGenerator.Model.Constants;
using Yagasoft.XrmMockGenerator.Model.ViewModel;

#endregion

namespace Yagasoft.XrmMockGenerator.Helpers
{
	public static class DataHelpers
	{
		public static IEnumerable<UserViewModel> RetrieveUsers(IOrganizationService service)
		{
			return
				from user in new XrmServiceContext(service).CreateQuery(User.EntityLogicalName)
				select
					new User
					{
						UserId = user.GetAttributeValue<Guid?>(User.Fields.UserId),
						FullName = user.GetAttributeValue<string>(User.Fields.FullName)
					}.ConvertTo<UserViewModel>();
		}

		public static IEnumerable<SystemFormViewModel> RetrieveForms(IOrganizationService service)
		{
			return
				from form in new XrmServiceContext(service).CreateQuery(SystemForm.EntityLogicalName)
				where form.GetAttributeValue<int>(SystemForm.Fields.FormType) == (int) SystemForm.FormTypeEnum.Main
				select
					new SystemForm
					{
						FormIdId = form.GetAttributeValue<Guid?>(SystemForm.Fields.FormIdId),
						Name = form.GetAttributeValue<string>(SystemForm.Fields.Name),
						ObjectTypeCode = form.GetAttributeValue<string>(SystemForm.Fields.ObjectTypeCode)
					}.ConvertTo<SystemFormViewModel>();
		}

		public static IEnumerable<EntityNameViewModel> RetrieveEntityNames(IOrganizationService service)
		{
			var entityProperties =
				new MetadataPropertiesExpression
				{
					AllProperties = false
				};
			entityProperties.PropertyNames.AddRange("LogicalName", "DisplayName");

			var entityQueryExpression =
				new EntityQueryExpression
				{
					Properties = entityProperties
				};

			var retrieveMetadataChangesRequest =
				new RetrieveMetadataChangesRequest
				{
					Query = entityQueryExpression,
					ClientVersionStamp = null
				};

			return ((RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest))
				.EntityMetadata.Select(e =>
					new EntityNameViewModel
					{
						LogicalName = e.LogicalName,
						DisplayName = e.DisplayName?.UserLocalizedLabel?.Label
					});
		}
	}
}
