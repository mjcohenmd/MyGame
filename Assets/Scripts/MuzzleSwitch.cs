using UnityEngine;
using System.Collections;

public class MuzzleSwitch : MonoBehaviour
{
    public Light myLight;

    private void Awake ()
    {
        
    }

    // Use this for initialization
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update ()
    {
        if (myLight.enabled == true)
            {
            StartCoroutine("LightOff");
            }
        else
        {
            StartCoroutine("LightOn");
        }

	}

    private IEnumerator LightOn()
    {
        yield return new WaitForSeconds(1);
        myLight.enabled = true;
    }

    private IEnumerator LightOff()
    {
        yield return new WaitForSeconds(1);
        myLight.enabled = false;
    }
}
