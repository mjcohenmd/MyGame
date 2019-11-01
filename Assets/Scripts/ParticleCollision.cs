using UnityEngine;
using System.Collections;

public class ParticleCollision : MonoBehaviour
{
    private GameObject gameManager;
    private Manager manager;

    // Use this for initialization
    private void Start ()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<Manager>();
    }

    // Update is called once per frame
    private void Update ()
    {
	    
	}

    private void OnParticleCollision(GameObject other)
    {
        if (!other)
            return;

        if (other.tag == "Player")
        {
            manager.currHealth--;
        }
    }
}
