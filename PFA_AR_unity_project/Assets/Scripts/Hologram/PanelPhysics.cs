using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Classe <c>PanelPhysics</c> : Gère la physique de base du HoloPanel
/// Le panel regarde dans la direction de la caméra et se positionne juste en avant du satellite
///
/// </summary>
///
public class PanelPhysics : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    /// <summary>
    /// Oriente le panel pour qu'il fasse face à la caméra principale, de manière
    /// à montrer son contenu
    /// </summary>
    void LookAtCamera()
    {
        if (mainCamera != null)
        {
            // Since the transform.forward vector is not pointing in the right direction,
            // we perform a small calculation to orient it correctly towards the camera
            Vector3 mainCameraOppositeDirection = transform.position - mainCamera.transform.position;
            transform.LookAt(transform.position + mainCameraOppositeDirection, mainCamera.transform.up);
        }
        else
        {
            Debug.LogError("Main camera not found.");
        }
    }

    /**
     * Moves the given position towards the main camera in order to make it stick out from other elements
     */
    public void AdjustPosition(Vector3 basePosition)
    {
        Vector3 mainCamera = Camera.main.transform.position - transform.position;
        transform.position = basePosition + mainCamera.normalized * 0.5f;
    }

    private float lookAtCameraTimer = 0f;

    /**
     * This function could be used to call LookAtCamera() every given seconds, to use less resources.
     */
    void LookAtCameraEveryGivenSec(float sec)
    {
        lookAtCameraTimer += Time.deltaTime;

        if (lookAtCameraTimer >= sec)
        {
            LookAtCamera();
            lookAtCameraTimer = 0f;
        }
    }

    void LateUpdate()
    {
        LookAtCamera();
    }

    public int getHeight()
    {
        // to implement
        return 4;
    }
}
