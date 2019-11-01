using UnityEngine;
using System.Collections;

public class AmmoReload : MonoBehaviour {

    public GameObject fpc;
    public ShootIt shootit;

    // Use this for initialization
    private void Start ()
    {
        fpc = GameObject.FindGameObjectWithTag("Player");
        shootit = fpc.GetComponentInChildren<ShootIt>();
	}

    // Update is called once per frame
    private void Update ()
    {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            shootit.Reload();
        }
        
    }
}
