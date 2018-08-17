#region Imports

using System;
using System.Collections.Generic;

#endregion

namespace Yagasoft.XrmMockGenerator.Model
{
	public class Context
	{
		public Guid UserId { get; set; }
		public string Username { get; set; }
		public string UserFullName { get; set; }
		public bool IsGuidedHelpEnabled { get; set; }
		public int UserLanguageCode { get; set; }
		public int TimeZoneBias { get; set; }
		public List<Guid> UserRoles { get; set; }
		public string OrganisationUrl { get; set; }
		public bool IsAutoSaveEnabled { get; set; }
		public int OrgLanguageCode { get; set; }
		public string OrganisationName { get; set; }
		public string ThemeName { get; set; }
		public string CrmVersion { get; set; }
	}
}
