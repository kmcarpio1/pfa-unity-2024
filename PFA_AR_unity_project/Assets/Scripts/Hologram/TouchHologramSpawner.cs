using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Classe <c>TouchHologramSpawner</c> : Gère la détection du touché et appelle les événements associés
///
/// </summary>
///
public class TouchHologramSpawner : MonoBehaviour
{
    public delegate void Touch3(Vector3 pos);
    public delegate void NoTouch0();
    public event Touch3 HologramTouched;
    public event NoTouch0 NoTouch;

    // Update is called once per frame
    void Update()
    {

        // Debug.DrawLine(Vector3.zero, new Vector3(0, 5, 0), new Color(255, 0, 0));
        // Vérifier si l'utilisateur touche l'écran
        if (Input.touchCount > 0)
        {
            // Obtenir le premier toucher
            Touch touch = Input.GetTouch(0);

            // Traiter le toucher selon son état
            switch (touch.phase)
            {
            case TouchPhase.Began:
                // Code à exécuter au début du toucher
                HandleTouchBegin(touch.position);
                break;
            case TouchPhase.Moved:
                // Code à exécuter lorsque le doigt se déplace sur l'écran
                HandleTouchMove(touch.position);
                break;
            case TouchPhase.Ended:
                // Code à exécuter lorsque le doigt est retiré de l'écran
                HandleTouchEnd(touch.position);
                break;
            }
        }
    }

    /// <summary>
    /// Hook <c>HandleTouchBegin</c> : Evénement appelé lorsqu'un touché commence
    ///
    /// Si le touché est fait sur un hologramme, appelle l'événement d'apparition du panel
    /// Sinon appelle l'événement de disparition du panel
    ///
    /// </summary>
    ///
    void HandleTouchBegin(Vector2 position)
    {
        // Traiter le début du toucher, par exemple, vérifier si le toucher est sur un objet spécifique
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 2f);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Hologram"))
            {
                // L'utilisateur a touché l'objet souhaité
                Debug.DrawLine(ray.origin, hit.point, Color.green, 2, false);
                Vector3 hitPosition = hit.collider.gameObject.transform.position;
                HologramTouched.Invoke(hitPosition);
            }
        }
        else
        {
            NoTouch.Invoke();
        }
    }

    /// <summary>
    /// Hook <c>HandleTouchMove</c> : Evénement appelé lorsqu'un touché est effectif et se déplace
    ///
    /// </summary>
    ///
    void HandleTouchMove(Vector2 position)
    {
        // Convertir la position du toucher en un rayon partant de la caméra
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        // Effectuer un raycast pour déterminer ce que le rayon touche
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
            }
        }
    }

    /// <summary>
    /// Hook <c>HandleTouchEnd</c> : Evénement appelé lorsqu'un touché termine
    ///
    /// </summary>
    ///
    void HandleTouchEnd(Vector2 position)
    {
        // Convertir la position du toucher en un rayon partant de la caméra
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
            }
        }
    }
}
