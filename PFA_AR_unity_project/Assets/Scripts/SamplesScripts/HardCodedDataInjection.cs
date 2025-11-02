using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe exemple <c>HardCodedDataInjection</c> : Utilise le DataInjector pour y
/// insérer des données d'exemple
///
/// </summary>
public class HardCodedDataInjection : MonoBehaviour
{

    [SerializeField]
    private DataInjector dataInjector;

    [SerializeField]
    private GameObject hologram;

    [SerializeField]
    private Texture sampleSprite;

    private List<KeyValuePair<string, dynamic>> content;

    // Start is called before the first frame update
    void Awake()
    {
        dataInjector.hologram = hologram;

        content = new List<KeyValuePair<string, dynamic>>();
        content.Add(new KeyValuePair<string, dynamic>("Vitesse", 75.14));
        content.Add(new KeyValuePair<string, dynamic>("Valeur", 6));
        content.Add(new KeyValuePair<string, dynamic>("Description", "Reste d'une fusée"));
        content.Add(new KeyValuePair<string, dynamic>("Photo", sampleSprite));
        content.Add(new KeyValuePair<string, dynamic>("Nom", "John"));

        dataInjector.content = content;
    }
}
