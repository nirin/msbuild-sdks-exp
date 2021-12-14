using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSBuild.TestFramework;

namespace MSBuild.Project.Tasks.Tests;

[TestClass]
public class MainTaskTest : TaskTest
{
	[TestMethod]
	public void TestThis()
	{
		var actual = 1;
		var expected = 1;
		Assert.AreEqual(expected, actual);
	}
}