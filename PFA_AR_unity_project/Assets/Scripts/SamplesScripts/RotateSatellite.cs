using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe exemple <c>RotateSatellite</c> : S'attache à un hologramme pour lui
/// donner une rotation passive
///
/// </summary>
public class RotateSatellite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    [Tooltip("Changes the rotation speed of the cube")]
    public float rotateSpeed = 1f;

    [Tooltip("Changes orientation of the cube")]
    public Vector3 objectRotation = new Vector3(2, 1, 1);

    void Update()
    {
        transform.Rotate(objectRotation * Time.deltaTime * rotateSpeed);
    }
}
