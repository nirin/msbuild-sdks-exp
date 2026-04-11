using System;
using MSBuild.TestFramework.Core;

namespace MSBuild.TestFramework;

public abstract class SdkTest : ISdkTest
{
	public SdkTest()
	{
	}

	public string SdkName { init; get; };

	public string SdkVersion { init; get; }
}