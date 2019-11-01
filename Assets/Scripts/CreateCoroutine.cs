using UnityEngine;
using System.Collections;

public class CreateCoroutine : MonoBehaviour
{
    public GameObject obj;
    public Transform spawnPoint;
    public bool isSpawning = false;

    // Use this for initialization
    private void Start()
    {
        //StartCoroutine("Spawner");
    }

    // Update is called once per frame
    private void Update()
    { 
       if (!isSpawning)
        {
            StartCoroutine("Spawner");
        }
    }

    private IEnumerator Spawner()
    {
        isSpawning = true;
        Instantiate (obj, spawnPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        isSpawning = false;
    }
}