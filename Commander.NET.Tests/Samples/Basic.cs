﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Commander.NET;
using Commander.NET.Attributes;

namespace Commander.NET.Tests
{
	public class Basic
	{
		[Parameter("r", "row")]
		public int Row;

		[Parameter("n", "name", Required = Required.No)]
		public string Name;
		
		[Parameter("extra-args")]
		public string ExtraArg = "default";

		[Parameter("f", "for-sure")]
		public bool Flag;

		[PositionalParameter(0, "positional")]
		public double Positional;
	}
}
