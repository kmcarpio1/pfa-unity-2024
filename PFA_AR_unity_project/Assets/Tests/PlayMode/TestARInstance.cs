using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEditor;

[UnityPlatform(exclude = new[] { RuntimePlatform.OSXEditor, RuntimePlatform.OSXPlayer })]
public class TestARInstance
{

    [OneTimeSetUp]
    public void SetUp()
    {
        SceneManager.LoadScene(0);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestManagersExistence()
    {
        Debug.Log(EditorSettings.unityRemoteDevice);

        // Skips a frame
        yield return null;

        Assert.IsNotNull(GameObject.Find("DataInjector"));
        Assert.IsNotNull(GameObject.Find("AR Session"));
        Assert.IsNotNull(GameObject.Find("AR Session Origin"));
        Assert.IsNotNull(GameObject.Find("AR Session Origin")
                             .GetComponent<ARTrackedImageManager>()
                             .trackedImagePrefab.GetComponent<SatellitePanelScript>()
                             .PanelPrefab);
    }

    [UnityTest]
    public IEnumerator TestDataInjection()
    {

        GameObject dataInjector = GameObject.Find("DataInjector");

        // Skips a frame
        yield return null;

        Assert.AreEqual(GameObject.Find("AR Session Origin")
                            .GetComponent<ARTrackedImageManager>()
                            .trackedImagePrefab.GetComponent<SatellitePanelScript>()
                            .hologramPrefab,
                        dataInjector.GetComponent<DataInjector>().hologram);
    }
}
