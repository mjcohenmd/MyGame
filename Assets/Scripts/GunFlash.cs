using UnityEngine;
using System.Collections;

public class GunFlash : MonoBehaviour
{
    public ParticleSystem ps;

    // Use this for initialization
    private void Start ()
    {
        ps.Stop();
	}

    // Update is called once per frame
    private void Update ()
    {
        
	}

    private void OnMouseDown()
    {
        ps.Play();
    }
}
