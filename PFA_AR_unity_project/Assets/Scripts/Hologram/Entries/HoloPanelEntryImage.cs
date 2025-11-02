using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloPanel
{

/// <summary>
/// Classe <c>HoloPanelEntryImage</c> : Entrée image du panel
///
/// </summary>
///
class HoloPanelEntryImage : HoloPanelEntry
{
    [SerializeField]
    private TMP_Text entryNameText;
    [SerializeField]
    private MeshRenderer entryValueTexture;

    /// <summary>
    /// Méthode <c>GetEntryType</c> : retourne le type de l'entrée
    /// </summary>
    ///
    /// <returns>Texture</returns>
    override protected Type GetEntryType()
    {
        return typeof(Texture);
    }

    /// <summary>
    /// Méthode <c>FillData</c> : remplit le GameObject "Entry" avec le contenu de
    /// l'entrée passé en paramètre
    /// </summary>
    ///
    override protected void FillData(KeyValuePair<string, dynamic> entry)
    {

        // Set entry name text
        if (entryNameText != null)
        {
            entryNameText.text = entry.Key;
        }
        else
        {
            Debug.LogError("Entry Name Text component is not assigned.");
        }

        // Set entry value text
        if (entryValueTexture != null)
        {
            Material spriteMaterial = new Material(Shader.Find("Standard"));
            spriteMaterial.mainTexture = entry.Value;

            // Assign the material to the mesh renderer
            entryValueTexture.material = spriteMaterial;
        }
        else
        {
            Debug.LogError("Entry Value Text component is not assigned.");
        }
    }
}

}