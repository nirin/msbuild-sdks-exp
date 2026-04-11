using System;

namespace MSBuild.TestFramework.Core;

internal interface ISdkTest
{
	/// <summary>
	/// Gets the name of the SDK.
	/// </summary>
	string SdkName { get; }

	/// <summary>
	/// Gets the version of the SDK.
	/// </summary>
	string SdkVersion { get; }
}