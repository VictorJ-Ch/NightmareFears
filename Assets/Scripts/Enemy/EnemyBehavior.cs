using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    //State
    public enum State { Follow, Patrol }
    public static State EnemyState;
    //patrol
    public Transform[] Points;
    public int current;
    public float _distance;

    //follow
    NavMeshAgent navMeshAgent;
    GameObject Player;

    void Awake()
    {
        EnemyManager.Follow += follow;
        EnemyManager.Patrol += patrol;
    }

    void Start()
    {
        EnemyState = State.Patrol;

        navMeshAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyState == State.Follow)
        {
            navMeshAgent.SetDestination(Player.transform.position);
        }

        if (EnemyState == State.Patrol)
        {
            //Normal Patrol
            /*if (Vector3.Distance(this.transform.position, Points[current].transform.position) < _distance)
            {
                current++;
            }

            if (current >= Points.Length)
            {
                current = 0;
            }

            Quaternion lookAtWP = Quaternion.LookRotation(Points[current].transform.position - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWP, Time.deltaTime * rotSpeed);
            this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);*/

            //Patrol NavMesh    
            navMeshAgent.SetDestination(Points[current].transform.position);

            if(Vector3.Distance(this.transform.position, Points[current].transform.position) < _distance)
            {
                current++;
            }

            if(current >= Points.Length)
            {
                current = 0;
            }
        }
    }

    public void follow()
    {
        EnemyState = State.Follow;
    }

    public void patrol()
    {
        EnemyState = State.Patrol;
    }
}
