using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour {

    public GameObject[] patrolPoints;
    public Transform player;
    public GameObject weapon;
    public GameObject broken;
    public GameObject hat;
    public ParticleSystem fireBall;
    public CharacterController controller;
    public float patrolDistance = 200f;
    public float attackDistance = 75f;
    public float patrolSpeed = 5f;
    public float chaseSpeed = 10f;
    public float attackSpeed = 5f;
    public float delay = 2f;
    public float visibleAngle = 45f;
    public int maxHits = 3;
    public float characterSpeed;

    private float distanceToPlayer;
    private NavMeshAgent agent;
    //private Renderer render;
    private Renderer hatRenderer;
    [SerializeField] private int currIdx;
    //[SerializeField]private int prevIdx;
    private bool isPatrolling = false;
    private bool isFiring = false;
    private Vector3 heading;
    [SerializeField] private int currHits = 0;

    // Use this for initialization
    private void Awake()
    {
        //render = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = player.gameObject.GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
        patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
        weapon = GameObject.Find("Weapon");
        fireBall = weapon.GetComponentInChildren<ParticleSystem>();
        //hat = GameObject.Find("Hat");
        hatRenderer = hat.GetComponent<Renderer>();
        //prevIdx = patrolPoints.Length;
        agent.speed = patrolSpeed;
        agent.autoBraking = false;
        weapon.SetActive(false);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CheckDamage();
        characterSpeed = controller.velocity.magnitude;
        heading = player.position - transform.position;
        distanceToPlayer = heading.magnitude;
        var angle = Vector3.Angle(heading, transform.forward);

        Debug.DrawRay(transform.position, transform.forward * patrolDistance, Color.green);

        if (distanceToPlayer < attackDistance && angle < visibleAngle)
        {
            if (!CheckForObstacle())
            {
                Attack();
            }

            else 
            {
                Chase();
            }
        }

        else if (distanceToPlayer < attackDistance && angle > visibleAngle)
        {
            Chase();
        }
    
        else if (distanceToPlayer > attackDistance && distanceToPlayer < patrolDistance && angle < visibleAngle)
        
            if (!CheckForObstacle())
            {
                Chase();
            }      
            else if (characterSpeed > 0)
            {
                Chase();
            }
            else
            {
                Patrol();
            }

        else if (distanceToPlayer > attackDistance && distanceToPlayer < patrolDistance && angle > visibleAngle)

            if (!CheckForObstacle() && characterSpeed > 15f)
            {
                Chase();
            }
            else
            {
                Patrol();
            }
        else
        {
            Patrol();
        }          
    }

    private void Chase()
    {
        isPatrolling = false;
        hatRenderer.material.color = Color.yellow;
        //render.material.color = Color.yellow;
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
        weapon.SetActive(false);
    }

    private void Attack()
    {
        isPatrolling = false;
        hatRenderer.material.color = Color.red;
        //render.material.color = Color.red;
        agent.speed = attackSpeed;
        agent.SetDestination(player.position);
        weapon.SetActive(true);
        if (!isFiring)
        {
            StartCoroutine("EnemyFire");
        }
    }    
   
    private void FindNextPatrolPoint()
    {
        currIdx = Random.Range(0, patrolPoints.Length);
        agent.SetDestination(patrolPoints[currIdx].transform.position);

        /*if (currIdx == prevIdx)
        {
            FindNextPatrolPoint();           
        }*/
        //agent.SetDestination(patrolPoints[currIdx].transform.position);
        //prevIdx = currIdx;
        isPatrolling = true;
    }

    private void Patrol()
    {
        if (!isPatrolling)
        {
            FindNextPatrolPoint();
            //isPatrolling = true;
        }
        //agent.SetDestination(patrolPoints[currIdx].transform.position);
        hatRenderer.material.color = Color.green;
        //render.material.color = Color.green;
        weapon.SetActive(false);
        //var distance = Vector3.Distance(transform.position, patrolPoints[currIdx].transform.position);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            FindNextPatrolPoint();
        }
    }

     private IEnumerator EnemyFire()
    {
        isFiring = true;
        if (!fireBall.isPlaying)
        {
            fireBall.Play();
        }
        //rb = go.GetComponent<Rigidbody>();
        //rb.AddRelativeForce(Vector3.forward * 500, ForceMode.Force)
        //Destroy(go, 5f);
        yield return new WaitForSeconds(delay);
        isFiring = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gate")
        {
            Patrol();
        }
    }

    private bool CheckForObstacle()
   {
      NavMeshHit hit;

      if (!agent.Raycast(player.position, out hit))
      {
            Debug.DrawRay(transform.position, heading, Color.red);
            return false;
      }
      else
      {
            return true;
      }
    }
   /* {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, heading);

        if (Physics.Raycast(ray, out hit, patrolDistance))
        {
            Debug.DrawRay(transform.position, heading, Color.red);
           
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log(hit.collider.gameObject.name);
                return false;
            }
            else
            {
                Debug.Log(hit.collider.gameObject.name);
                return true;
            }
        }
        else
        {
            return false;
        }
    }*/
        public void ApplyDamage(int damage)
        {
            currHits += damage;
        }

        private void CheckDamage()
        {
            if (currHits >= maxHits)
            {
                var clone = Instantiate(broken, transform.position, transform.rotation);
                gameObject.SetActive(false);
                Destroy(clone, 20f);
                //Destroy(gameObject);
            }
        }
    }
