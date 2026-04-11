using System;

namespace MSBuild.TestFramework.Core;

internal interface ITaskTest
{
	/// <summary>
	/// Gets the name of the task.
	/// </summary>
	string TaskName { get; }

	/// <summary>
	/// Gets the namespace containing the task.
	/// </summary>
	string TaskNamespace { get; }

	/// <summary>
	/// Gets the name of the assembly containing the task.
	/// </summary>
	string TaskAssemblyName { get; }
}