using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    private Manager manager;
    private Slider slider;
    private GameObject gamemanager;

    // Use this for initialization
    private void Start ()
    {
        gamemanager = GameObject.Find("GameManager");
        manager = gamemanager.GetComponent<Manager>();
        slider = gameObject.GetComponent<Slider>();
	}

    // Update is called once per frame
    private void Update ()
    {
        slider.value = manager.currHealth;
	}
}
