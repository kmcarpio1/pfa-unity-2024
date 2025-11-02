using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloPanel
{

/// <summary>
/// Interface <c>HoloPanelEntry</c> : Entrée générique dans le panel de l'hologramme.
///
/// </summary>
///
abstract class HoloPanelEntry : MonoBehaviour
{
    /// <summary>
    /// Méthode <c>Hydrate</c> :
    /// - Afficher le nom de l'entrée dans son GameObject
    /// - Afficher le contenu de l'entrée dans son GameObject
    /// </summary>
    ///
    /// La classe utilise le patron de conception du "patron de méthode" : <c>Hydrate</c> appelle
    /// les "hooks" <c>GetEntryType</c> et <c>FillData</c> définies dans les classes enfants
    ///
    /// Le contenu étant du type "dynamic", la classe fait une vérification du type à l'exécution
    ///
    /// <param name="entry"> : Couple nom/contenu représentant l'entrée à afficher sur le panel</param>
    internal void Hydrate(KeyValuePair<string, dynamic> entry)
    {
        Type expectedType = GetEntryType();
        Type valueType = entry.Value.GetType();

        if (!(valueType == expectedType || valueType.IsSubclassOf(expectedType)))
        {
            throw new Exception($"Type mismatch: Expected {expectedType}, but got {valueType}.");
        }

            Debug.Log("hydrate entry : " + entry.Key);

        FillData(entry);
    }

    /// <summary>
    /// Méthode <c>GetEntryType</c> : retourne le type de l'entrée
    /// </summary>
    ///
    abstract protected Type GetEntryType();

    /// <summary>
    /// Méthode <c>FillData</c> : remplit le GameObject "Entry" avec le contenu de
    /// l'entrée passé en paramètre
    /// </summary>
    ///
    abstract protected void FillData(KeyValuePair<string, dynamic> entry);
    }
}