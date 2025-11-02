using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace HoloPanel
{

/// <summary>
/// Classe <c>HoloPanelContentManager</c> : Gère l'insertion du contenu d'un HoloPanel
///
/// Fonctionne en synergie avec un <see cref="HoloPanelFormatManager"/>.
///
/// </summary>
///
public class HoloPanelContentManager : MonoBehaviour
{
    [SerializeField]
    private GameObject body;

    /// <summary>
    /// Method <c>Hydrate</c> : Insère le contenu passé en paramètre dans chaque entrée du HoloPanel
    ///
    /// S'attache au HoloPanel
    ///
    /// </summary>
    ///
    /// <param name="content"> : Contenu sous forme d'une liste de couple clé/valeur (valeur de type dynamique)
    ///
    public void Hydrate(List<KeyValuePair<string, dynamic>> content)
    {
        Debug.Log("Hydrating panel.");
            
        for (int i = 0; i < body.transform.childCount; i++)
        {
            body.transform.GetChild(i).GetComponent<HoloPanelEntry>().Hydrate(content[i]);
        }
    }
}

}
