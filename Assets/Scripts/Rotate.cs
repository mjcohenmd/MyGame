using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    // Use this for initialization
    private void Start () {
	
	}

    // Update is called once per frame
    private void Update ()
    {
        transform.Rotate(Vector3.up * 50  *Time.deltaTime, Space.World);
	}
}