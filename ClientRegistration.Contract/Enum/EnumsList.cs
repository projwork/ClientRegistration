using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace ClientRegistration.Contract.Enum
{	
	[JsonConverter(typeof(StringEnumConverter))]
	public enum LoanType
	{
		[EnumMember(Value = "Fast loan")]
		FastLoan = 1,
		[EnumMember(Value = "Auto loan")]
		AutoLoan =2,
		[EnumMember(Value = "Instalment")]
		Instalment = 3
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum Status
	{
		[EnumMember(Value = "Sent")]
		Sent =4,
		[EnumMember(Value = "In progress")]
		InProgress =5,
		[EnumMember(Value = "Approved")]
		Approved =6,
		[EnumMember(Value = "Rejected")]
		Rejected =7
	}
}
