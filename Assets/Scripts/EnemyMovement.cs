using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float movSpeed = 3f;
    public float rotSpeed = 5.0f;
    public Quaternion targetRotation;
    public UnityEngine.AI.NavMeshAgent agent;

    // Use this for initialization
    private void Awake ()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

    // Update is called once per frame
    private void Update ()
    {
        //Quaternion targetRotation = Quaternion.LookRotation (target.position - transform.position);
        //transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        //transform.LookAt(target);
        agent.SetDestination(target.position);
	}
}
