using UnityEngine;

public class AimScript : MonoBehaviour
{
    public Vector3 restPosition;
    public Vector3 aimPosition;

    // Use this for initialization
    private void Start()
    {
        aimPosition = new Vector3(-0.08f, -0.43f, 0.5f);
        restPosition = new Vector3(0.6f, -0.3f, 0.5f);
    }

    // Update is called once per frame
    private void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.localPosition = aimPosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            transform.localPosition = restPosition;
        }
	}
}
