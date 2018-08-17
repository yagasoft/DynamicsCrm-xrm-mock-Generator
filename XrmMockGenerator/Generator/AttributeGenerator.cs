#region Imports

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

#endregion

namespace Yagasoft.XrmMockGenerator.Generator
{
	public class AttributeGenerator
	{
		public IEnumerable<CrmAttribute> Generate(IOrganizationService service, string entityName)
		{
			var entityProperties =
				new MetadataPropertiesExpression
				{
					AllProperties = false
				};
			entityProperties.PropertyNames.AddRange("Attributes");

			var entityFilter = new MetadataFilterExpression(LogicalOperator.And);
			entityFilter.Conditions.Add(
				new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, entityName));

			var attributeProperties =
				new MetadataPropertiesExpression
				{
					AllProperties = true
				};
			//attributeProperties.PropertyNames.AddRange(attribute.ToString());

			var attributeFilter = new MetadataFilterExpression(LogicalOperator.And);
			attributeFilter.Conditions.Add(
				new MetadataConditionExpression("AttributeOf", MetadataConditionOperator.Equals, null));

			var entityQueryExpression =
				new EntityQueryExpression
				{
					Criteria = entityFilter,
					Properties = entityProperties,
					AttributeQuery =
						new AttributeQueryExpression
						{
							Properties = attributeProperties,
							Criteria = attributeFilter
						}
				};

			var retrieveMetadataChangesRequest =
				new RetrieveMetadataChangesRequest
				{
					Query = entityQueryExpression,
					ClientVersionStamp = null
				};

			var attributes = ((RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest))
				.EntityMetadata?.FirstOrDefault()?.Attributes;
			var mappedAttributes = attributes?
				.Select(a =>
					new CrmAttribute
					{
						Name = a.LogicalName,
						//Labels = a.DisplayName?.LocalizedLabels?.ToDictionary(e => e.LanguageCode, e => e.Label),
						AttributeType = AttributeContants.AttributeTypeMap.FirstNotNullOrEmpty(a.AttributeType?.ToString()),
						RequiredLevel = AttributeContants.RequiredLevelMap.FirstNotNullOrEmpty(a.RequiredLevel?.Value.ToString()),
						Format = (a is StringAttributeMetadata aS)
							? aS.Format.ToString()
							: (a is DateTimeAttributeMetadata aD)
								? aD.Format.ToString()
								: (a is IntegerAttributeMetadata aI) ? aI.Format.ToString() : null,
						Options = (a as EnumAttributeMetadata)?.OptionSet?.Options
							.ToDictionary(e => e.Value ?? 0,
								e => e.Label?.LocalizedLabels?.ToDictionary(l => l.LanguageCode, l => l.Label))
					});

			return mappedAttributes;
		}
	}
}
