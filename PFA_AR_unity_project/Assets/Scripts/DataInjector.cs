using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using HoloPanel;

/// <summary>
/// Classe <c>HoloPanelFormatManager</c> : Singleton qui injecte les données de l'application
/// RA dans les GameObjects responsables de la RA
///
/// Ces données à injecter comprennent :
/// - Le prefab de l'hologramme
/// - Le contenu du panel
///
/// Le GameObject auquel il est attaché n'est pas détruit au changement de scène, et la classe
/// détecte toute seule n'importe quel chargement de scène (changement de scène ou initialisation
/// de la scène actuelle)
///
/// </summary>
public class DataInjector : MonoBehaviour
{
    public bool dontDestroy;

    public GameObject hologram = null;

    public List<KeyValuePair<string, dynamic>> content = null;

    private static DataInjector instance;
    public static DataInjector Instance { get; private set; }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Destroying DataInjector");
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        SceneManager.sceneLoaded += OnSceneChange;
    }

    void Start()
    {
        if (dontDestroy)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnSceneChange(Scene scene, LoadSceneMode mode)
    {
        if (hologram != null)
        {
            GameObject.Find("AR Session Origin")
                .GetComponent<ARTrackedImageManager>()
                .trackedImagePrefab.GetComponent<SatellitePanelScript>()
                .hologramPrefab = hologram;
        } else {
            Debug.Log("[OnSceneChange] No hologram given to DataInjector, using default one.");
        }

        if (content != null)
        {
            GameObject.Find("AR Session Origin")
                .GetComponent<ARTrackedImageManager>()
                .trackedImagePrefab.GetComponent<SatellitePanelScript>()
                .PanelPrefab.GetComponent<HoloPanelContentManager>()
                .Hydrate(content);
        }  else {
            Debug.Log("[OnSceneChange] No content given to DataInjector.");
        }
    }
}
