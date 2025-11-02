using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloPanel
{

/// <summary>
/// Classe <c>HoloPanelEntryString</c> : Entrée textuelle du panel
///
/// </summary>
///
class HoloPanelEntryString : HoloPanelEntry
{
    [SerializeField]
    private TMP_Text entryNameText;
    [SerializeField]
    private TMP_Text entryValueText;

    /// <summary>
    /// Méthode <c>GetEntryType</c> : retourne le type de l'entrée
    /// </summary>
    ///
    /// <returns>string</returns>
    override protected Type GetEntryType()
    {
        return typeof(string);
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
            entryValueText.text = entry.Value;
        }
        else
        {
            Debug.LogError("Entry Value Text component is not assigned.");
        }
    }
}

}