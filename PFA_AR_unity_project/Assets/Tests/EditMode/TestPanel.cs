using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Reflection;
using HoloPanel;
using Layout3D;

public class TestPanel
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestPanelFormat()
    {
        var emptyObject = new GameObject("Dummy");
        var panelFormat = emptyObject.AddComponent<HoloPanelFormatManager>();

        System.Type type = typeof(HoloPanelFormatManager);

        // Set initial values
        var layoutGroup = emptyObject.AddComponent<LayoutGroup3D>();
        System.Reflection.FieldInfo layoutGroupField = type.GetField(
            "layoutGroup", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        layoutGroupField.SetValue(panelFormat, layoutGroup);

        var layoutElement = emptyObject.AddComponent<LayoutElement3D>();
        System.Reflection.FieldInfo layoutElementField = type.GetField(
            "layoutElement", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        layoutElementField.SetValue(panelFormat, layoutElement);

        var holoGroup = emptyObject.AddComponent<LayoutGroup3D>();
        System.Reflection.FieldInfo holoGroupField = type.GetField(
            "holoGroup", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        holoGroupField.SetValue(panelFormat, holoGroup);

        // Get initial size
        var startSize = layoutElement.GetDimensions();
        Debug.Log(startSize);

        // Add children to object
        GameObject childObj = new GameObject("Child");
        var childLayElement = childObj.AddComponent<LayoutElement3D>();
        childLayElement.SetDimensions(new Vector3(1, 1, 1));
        childObj.transform.parent = emptyObject.transform;

        // Call reformat using reflection
        System.Reflection.MethodInfo methodInfo =
            type.GetMethod("OnTransformChildrenChanged",
                           System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        methodInfo.Invoke(panelFormat, null);

        // Test size is bigger
        var finalSize = layoutElement.GetDimensions();
        Assert.IsTrue(startSize.y < finalSize.y);
    }

    [Test]
    public void TestPanelContent()
    {
        var emptyObject = new GameObject("Dummy");
        var panelContent = emptyObject.AddComponent<HoloPanelContentManager>();
        Assert.IsNotNull(panelContent);
    }
}
