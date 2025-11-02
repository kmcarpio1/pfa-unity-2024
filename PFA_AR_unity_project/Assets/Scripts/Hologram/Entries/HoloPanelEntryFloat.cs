using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloPanel
{

/// <summary>
/// Classe <c>HoloPanelEntryDouble</c> : Entrée flottante du panel
///
/// </summary>
///
class HoloPanelEntryDouble : HoloPanelEntry
{
    [SerializeField]
    private TMP_Text entryNameText;
    [SerializeField]
    private TMP_Text entryValueText;

    /// <summary>
    /// Méthode <c>GetEntryType</c> : retourne le type de l'entrée
    /// </summary>
    ///
    /// <returns>double</returns>
    override protected Type GetEntryType()
    {
        return typeof(double);
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
        if (entryValueText != null)
        {
            Debug.Log("Panel filled with the float entry : " + entry.Value.ToString());
            entryValueText.text = entry.Value.ToString();
        }
        else
        {
            Debug.LogError("Entry Value Text component is not assigned.");
        }
    }
}

}