using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestExample
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestExampleSimplePasses()
    {
        Assert.Pass();
    }
}
