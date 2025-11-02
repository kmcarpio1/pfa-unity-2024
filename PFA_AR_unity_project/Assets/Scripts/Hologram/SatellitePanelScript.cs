using HoloPanel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe <c>SatellitePanelScript</c> : Gère l'apparition de l'hologramme et du HoloPanel, rassemblés sous un même
/// GameObject
///
/// Le GameObject auquel il est attaché est celui instancié par l'origine RA et doit pouvoir stocker les prefabs de
/// l'hologramme et du HoloPanel
///
/// </summary>
///
public class SatellitePanelScript : MonoBehaviour
{
    private GameObject spawner;

    public GameObject hologramPrefab;

    [SerializeField]
    private GameObject panelPrefab;
    public GameObject PanelPrefab => panelPrefab;

    private Button animationButton;        // ADD
    private bool animationPlaying = false; // ADD

    private GameObject hologram;
    private GameObject panel;

    [SerializeField]
    private float panelSize;

    private const float panelSizeMultiplier = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("TouchHologramSpawner");
        spawner.GetComponent<TouchHologramSpawner>().HologramTouched += TogglePanel;
        spawner.GetComponent<TouchHologramSpawner>().NoTouch += UntogglePanel;
        hologram = Instantiate(hologramPrefab, gameObject.transform, false);
        panel = Instantiate(panelPrefab, gameObject.transform, false);
        panel.transform.localScale = Vector3.zero;

        // ADD
        if (animationButton != null)
        {
            animationButton.onClick.AddListener(OnAnimationButtonClick);
        }

        // Debug.LogWarning(panel.transform.localScale.y.ToString());
        // Debug.LogWarning(
        //    (Vector3.up * panel.GetComponent<PanelPhysics>().getHeight() / 2 * panel.transform.localScale.y)
        //       .y.ToString());
        // float yScaleRatio = hologram.transform.localScale.y / panel.transform.localScale.y;
        // float panelHeight = panel.GetComponent<PanelPhysics>().getHeight();
        // Vector3 hologramSizeVector = hologram.GetComponent<Renderer>().bounds.size;
        // float hologramHeight = Mathf.Max(hologramSizeVector.x, Mathf.Max(hologramSizeVector.y,
        // hologramSizeVector.z)); panel.transform.Translate(Vector3.up *
        //                              (panelHeight / 2 * transform.localScale.y / yScaleRatio + hologramHeight / 2),
        //                          hologram.transform);

        // panel.transform.position = Camera.main.transform.position * 10f;

        panel.SetActive(false);
        // Debug.LogWarning(panel.transform.position.y.ToString());
    }

    /// <summary>
    /// Method <c>TogglePanel</c> : Evénement appelé pour faire apparaître le panel avec une animation
    ///
    /// Le panel apparaît devant l'hologramme, proche de l'endroit où l'utilisateur l'a touché
    ///
    /// </summary>
    ///
    public void TogglePanel(Vector3 position)
    {

        Vector3 oneScale = panelSizeMultiplier * panelSize * Vector3.one;

        if (!(panel.activeSelf))
        {
            panel.SetActive(true);
            panel.GetComponent<PanelPhysics>().AdjustPosition(position);
            StartCoroutine(PanelAnimation(panel, panel.transform.localScale, oneScale, null));
        }
    }

    /// <summary>
    /// Method <c>UntogglePanel</c> : Evénement appelé pour faire disparaître le panel avec une animation
    ///
    /// Le panel disparaît si l'utilisateur a touché à n'importe quel autre endroit que sur l'hologramme
    ///
    /// </summary>
    ///
    public void UntogglePanel()
    {
        if (panel.activeSelf)
        {
            Vector3 zeroScale = Vector3.zero;
            Action deactivate = () => panel.SetActive(false);
            StartCoroutine(PanelAnimation(panel, panel.transform.localScale, zeroScale, deactivate));
        }
    }

    /// <summary>
    /// Coroutine <c>PanelAnimation</c> : Animation qui fait grandir/s'amenuiser le HoloPanel
    ///
    /// </summary>
    ///
    IEnumerator PanelAnimation(GameObject panel, Vector3 panelInitialScale, Vector3 panelTargetScale,
                               Action callback = null)
    {
        float speed = 8f;
        for (float progress = 0f; progress < 1; progress += speed * Time.deltaTime)
        {
            speed -= 0.4f * Time.deltaTime;
            panel.transform.localScale = Vector3.Lerp(panelInitialScale, panelTargetScale, progress);
            yield return null;
        }
        panel.transform.localScale = panelTargetScale;
        if (callback != null)
        {
            callback();
        }
    }

    void OnAnimationButtonClick()
    {
        if (animationPlaying)
        {
            StopCoroutine("PlayAnimation");
            animationPlaying = false;
        }
        else
        {
            StartCoroutine("PlayAnimation");
        }
    }

    IEnumerator PlayAnimation()
    {
        animationPlaying = true;
        while (animationPlaying)
        {
            // Clignotement de l'hologramme
            hologram.SetActive(!hologram.activeSelf);
            // Rotation rapide sur lui-même
            hologram.transform.Rotate(Vector3.up, 720 * Time.deltaTime);
            yield return null;
        }
        animationPlaying = false;
    }
}
