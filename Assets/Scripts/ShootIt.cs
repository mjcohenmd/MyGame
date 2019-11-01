using UnityEngine;

public class ShootIt : MonoBehaviour
{
    public GameObject hole;
    //public GameObject bloodyhole;
    public GameObject fpsController;
    public ParticleSystem ps;
    public float fireRate = 0.2f;
    public float nextFire = 0;
    public bool autoFire = false;
    public EnemyAIScript enemyAI;
    public int damage = 1;
    public int maxAmmo = 50;

    [SerializeField]private int currAmmo;
    private AudioSource audioSource;
    private Camera fpcCam;

    // Use this for initialization
    private void Awake ()
    {
        fpsController = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        fpcCam = GetComponentInParent<Camera>();
        currAmmo = maxAmmo;
	}

    // Update is called once per frame 
    private void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
            if (currAmmo > 0)
            {
                
                Shoot();
                currAmmo--;
                Bolt.CustomEvent.Trigger(fpsController, "DivertToPlayer");
                
            }
            else
            {
                Debug.Log("Out of ammo!");
            }

        if (Input.GetButton("Fire1") && Time.time > nextFire && autoFire)
            if (currAmmo > 0)
            {
                
                nextFire = Time.time + fireRate;
                Shoot();
                currAmmo--;
                Bolt.CustomEvent.Trigger(fpsController, "DivertToPlayer");
                
            }
            else
            {
                Debug.Log("Out of ammo!");
            }
	}

    private void Shoot()
    {
        //var clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        audioSource.Play();
        if (!ps.isPlaying)
        {
            ps.Play();
        }

        RaycastHit hit;
        var origin = fpcCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(origin, fpcCam.transform.forward, out hit, 200))
        {
            var clone = Instantiate(hole, hit.point, Quaternion.FromToRotation(-Vector3.forward, hit.normal)) as GameObject;
            clone.transform.SetParent(hit.collider.transform);
            Destroy(clone, 20f);
            if (hit.collider.tag == "Enemy")
            {
                enemyAI = hit.collider.gameObject.GetComponent<EnemyAIScript>();
                enemyAI.ApplyDamage(damage);
            }
        }
    }

    public void Reload()
    {
        currAmmo = maxAmmo;
    }
    
}
