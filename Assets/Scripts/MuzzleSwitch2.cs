using UnityEngine;
using System.Collections;

public class MuzzleSwitch2 : MonoBehaviour
{
    public Light myLight;
    public bool wait = false;

    // Use this for initialization
    private void Start ()
    {
        
	}

    // Update is called once per frame
    private void Update ()
    {
	     if (!wait)
        {
            StartCoroutine("MuzzleSwitch");          
        }
	}

    private IEnumerator MuzzleSwitch ()
    {
        wait = true;
        myLight.enabled = !myLight.enabled;
        yield return new WaitForSeconds(1);
        wait = false;
    }
}
