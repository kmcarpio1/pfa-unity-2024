using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe exemple <c>SceneChanger</c> : Change de scène quand la touche "espace" est pressée
///
/// </summary>
public class SceneChanger : MonoBehaviour
{
    void Start()
    {
        // Debug.Log("valeur recup de la scen Main : "+connexionHolder.name);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            SceneManager.LoadScene(0);
    }
}