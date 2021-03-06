﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using Commander.NET;

namespace Commander.NET.Attributes
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class ParameterAttribute : CommanderAttribute 
	{
		/// <summary>
		/// The names of this parameter.
		/// </summary>
		public string[] Names { get; private set; }

		internal IEnumerable<string> Keys
		{
			get { return Names.Select(name => name.TrimStart('-')); }
		}

		/// <summary>
		/// The names of this parameter, in any UNIX-like syntax:
		/// -e, e, --example, example
		/// </summary>
		/// <param name="names"></param>
		public ParameterAttribute(params string[] names)
		{
			Names = names.NormalizeParameterNames();
		}
	}
}
