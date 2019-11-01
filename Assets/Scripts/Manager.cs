using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public float gameTime = 900f;
    public int maxHealth = 10;
    public GameObject fpc;
    public Text textLeft;
    public int currHealth;

    private float endTime;
    private float timeLeft;

    // Use this for initialization
    private void Start ()
    {
        currHealth = maxHealth;
        endTime = Time.time + gameTime;
	}

    // Update is called once per frame
    private void Update ()
    {
	    if (currHealth <= 0)
        {
            Die();
        }
        DisplayTime();
	}

    private void Die()
    {
        Debug.Log("Game Over. Player Dead!");
        //fpc.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DisplayTime()
    {
        int min;
        int sec;
        string timeString;
           
        timeLeft = endTime - Time.time;
        min = (int)timeLeft / 60;
        sec = (int)timeLeft % 60;
        timeString = string.Format("{0} mins {1} secs", min, sec);
        textLeft.text = timeString;
    }
}
