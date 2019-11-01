using UnityEngine;
using System.Collections;

public class ParticleFlash : MonoBehaviour {

    public ParticleSystem ps;

    // Use this for initialization
    private void Awake ()
    {
        ps = GetComponent<ParticleSystem>();
	}

    // Update is called once per frame
    private void Update ()
    {
	
	}
}
