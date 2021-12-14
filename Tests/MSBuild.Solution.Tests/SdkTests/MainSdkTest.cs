using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSBuild.TestFramework;

namespace MSBuild.Solution.Sdk.Tests;

[TestClass]
public class MainSdkTest : SdkTest
{
	[TestMethod]
	public void TestThis()
	{
		var actual = 1;
		var expected = 1;
		Assert.AreEqual(expected, actual);
	}
}