using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Layout3D;

namespace HoloPanel
{

/// <summary>
/// Classe <c>HoloPanelFormatManager</c> : Gère le formattage (le nombre d'entrées et leur type) d'un HoloPanel
/// S'exécute à editor-time grâce à un hook
///
/// S'attache au body du HoloPanel
///
/// Fonctionne en synergie avec un <see cref="HoloPanelContentManager"/>.
///
/// </summary>
[ExecuteInEditMode]
public class HoloPanelFormatManager : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField]
    LayoutGroup3D layoutGroup;
    [SerializeField]
    LayoutElement3D layoutElement;

    [SerializeField]
    LayoutGroup3D holoGroup;

    /// <summary>
    /// Hook <c>OnTransformChildrenChanged</c> : Surcharge d'une méthode editor-time de MonoBehavior
    /// Appelée quand un changement est détecté dans la hiérarchie du GameObject auquel le script est attaché
    /// Modifie et adapte la disposition des entrées quand appelée
    ///
    /// </summary>
    ///
    void OnTransformChildrenChanged()
    {
        Vector3 newSize = layoutElement.GetDimensions();
        newSize.y = 0;
        foreach (Transform child in transform)
        {
            newSize.y += child.gameObject.GetComponent<LayoutElement3D>().GetDimensions().y;
        }
        Debug.Log("EditMode : new HoloPanel body should have dimensions " + newSize);
        layoutElement.SetDimensions(newSize);
        holoGroup.RebuildLayout();
    }
#endif
}
}
