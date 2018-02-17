﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

using Commander.NET;
using Commander.NET.Attributes;
using Commander.NET.Exceptions;
using Commander.NET.Interfaces;

namespace Tests
{
	public class Program
	{
		public static InteractivePrompt Prompt;

		static void Main(string[] argc)
		{
			string[] args = { "push", "origin", "master" };

			Prompt = InteractivePrompt.GetPrompt();
			Prompt.WriteLine(Prompt.GetType());

			StringBuilder longMsg = new StringBuilder();
			for (int i = 0; i < 100; i++)
			{
				longMsg.AppendLine("line" + i);
			}

			Task.Run(() =>
			{
				int i = 0;
				while (true)
				{
					try
					{
						Prompt.WriteLine(longMsg.ToString());
						break;
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex);
						break;
					}


					Thread.Sleep(500);
				}
			});

			while (true)
			{
				Git cmd = Prompt.ReadCommand<Git>();
			}
		}
	}

	class Commit : ICommand
	{
		[Parameter("-m")]
		string Message;

		void ICommand.Execute(object parent)
		{
			Program.Prompt.WriteLine("Committing: " + Message);
		}
	}

	class Push
	{
		[PositionalParameter(0, "remote")]
		public string Remote;

		[PositionalParameter(1, "branch")]
		public string Branch;
	}

	class Git
	{
		[Command("commit")]
		public Commit Commit;

		[Command("push")]
		public Push Push;

		[CommandHandler]
		public void PushCommand(Push push)
		{
			Program.Prompt.WriteLine("Pusinng to " + push.Remote + " " + push.Branch);
		}
	}
}
