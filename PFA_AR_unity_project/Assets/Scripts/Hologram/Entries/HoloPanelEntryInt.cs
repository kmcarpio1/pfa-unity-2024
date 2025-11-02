using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloPanel
{

/// <summary>
/// Classe <c>HoloPanelEntryInt</c> : Entrée entière du panel
///
/// </summary>
///
class HoloPanelEntryInt : HoloPanelEntry
{
    [SerializeField]
    private TMP_Text entryNameText;
    [SerializeField]
    private TMP_Text entryValueText;

    /// <summary>
    /// Méthode <c>GetEntryType</c> : retourne le type de l'entrée
    /// </summary>
    ///
    /// <returns>int</returns>
    override protected Type GetEntryType()
    {
        return typeof(int);
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
            entryValueText.text = entry.Value.ToString();
        }
        else
        {
            Debug.LogError("Entry Value Text component is not assigned.");
        }
    }
}

}