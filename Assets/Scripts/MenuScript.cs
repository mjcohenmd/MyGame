using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour

{
    public bool isRunning = true;
    public Text text;                    //Text for PauseRun Button
    public ShootIt sp;           //ShootProjectile Script
    public GameObject bs;                //BulletSpawn instance
    public GameObject gunToggle;
    public Toggle toggle;

    private void Awake()
    {
        gunToggle = GameObject.Find("GunToggle");
        toggle = gunToggle.GetComponent<Toggle>();
        bs = GameObject.Find("BulletSpawn");
        sp = bs.GetComponent<ShootIt>();
    }
    public void RunPause()                 //Run and Pause button in UI
    {
        if (isRunning)
        {    
            Time.timeScale = 0;
            text.text = "Run";
            isRunning = false;
        }
        else
        {
            Time.timeScale = 1;
            text.text = "Pause";
            isRunning = true;
        }
    }

    public void ToggleFire()              //Turns automatic gun fire on and off in UI
    {
        if (toggle.isOn)
        {
            sp.autoFire = true;
        }
        else
        {
            sp.autoFire = false;
        }
    }
}
