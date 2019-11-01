using UnityEngine;
using System.Collections;

public class MouseRotation : MonoBehaviour {

    public float lookSensitivity = 5f;
    public float yRotation;
    public float xRotation;
    public float currentYRotation;
    public float currentXRotation;
    public float yRotationV;
    public float xRotationV;
    public float lookSmoothDamp = 0.1f;

    // Use this for initialization
    private void Start () {
	
	}

    // Update is called once per frame
    private void Update ()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation += Input.GetAxis("Mouse Y") * lookSensitivity;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

        transform.rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);
    }
}
