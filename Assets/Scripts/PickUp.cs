using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour
{
    public Transform target;

    // Use this for initialization
    private void Awake ()
    {
             
	}

    // Update is called once per frame
    private void Update ()
    {
        
	}

    private void OnMouseDown()
            {
               transform.position = target.position;
               transform.parent = GameObject.Find("MyGameFPSController").transform;
    }

    private void OnMouseUp()
            {
               transform.parent = GameObject.Find("MyGameFPSController").transform;
               transform.parent = null;  
            }
}
