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

    //Vector3[] puntos = new Vector3[4];

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

        //ObtenerPuntos();
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

    /*public void ObtenerPuntos()
    {
        puntos[0] = new Vector3(21.79f, -6f, -13.89f);
        puntos[1] = new Vector3(18f, -6f, -10f);
        puntos[2] = new Vector3(0, -6f, -10f);
        puntos[3] = new Vector3(21f, -6f, -7.5f);

    }*/
}
