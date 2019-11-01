using UnityEngine;
using System.Collections;

public class BridgeGateScript : MonoBehaviour {

    public Collider gate;

    // Use this for initialization
    private void Awake ()
    {
       
    }

    // Update is called once per frame
    private void Update ()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gate.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gate.enabled = true;
        }
    }
}
