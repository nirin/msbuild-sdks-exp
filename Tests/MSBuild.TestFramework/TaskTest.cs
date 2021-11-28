using System;
using MSBuild.TestFramework.Core;

namespace MSBuild.TestFramework;

public abstract class TaskTest : ITaskTest
{
	public TaskTest()
	{
	}

	public string TaskName { init; get; };

	public string TaskNamespace { init; get; }

	public string TaskAssemblyName { init; get; }

}