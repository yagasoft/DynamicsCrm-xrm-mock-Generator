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
								e => e.Label?.LocalizedLabels?.ToDictionary(l => l.LanguageCode, l => l.Label)),
						InitialValue = (a as EnumAttributeMetadata)?.DefaultFormValue,
						DefaultBoolValue = (a as BooleanAttributeMetadata)?.DefaultValue,
						Min = (a is DecimalAttributeMetadata anD)
							? anD.MinValue
							: (a is IntegerAttributeMetadata anI)
								? anI.MinValue
								: (a is BigIntAttributeMetadata anB)
									? anB.MinValue
									: (a is DoubleAttributeMetadata andD)
										? (decimal?)andD.MinValue
										: (a is MoneyAttributeMetadata anM)
											? (decimal?)anM.MinValue
											: null,
						Max = (a is DecimalAttributeMetadata anD2)
							? anD2.MaxValue
							: (a is IntegerAttributeMetadata anI2)
								? anI2.MaxValue
								: (a is BigIntAttributeMetadata anB2)
									? anB2.MaxValue
									: (a is DoubleAttributeMetadata andD2)
										? (decimal?)andD2.MaxValue
										: (a is MoneyAttributeMetadata anM2)
											? (decimal?)anM2.MaxValue
											: null,
						Precision = (a is DecimalAttributeMetadata anD3)
							? anD3.Precision
							: (a is DoubleAttributeMetadata andD3)
								? andD3.Precision
								: (a is MoneyAttributeMetadata anM3)
									? anM3.Precision
									: null,
						MaxLength = (a as StringAttributeMetadata)?.MaxLength
					});

			return mappedAttributes;
		}
	}
}
