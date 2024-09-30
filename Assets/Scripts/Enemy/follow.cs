using UnityEngine;

public class follow : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform Enemy, Player;
    public bool followPlayer;

    public GameObject PL;
    string PlayerTag = "Player";

    private void Start()
    {
        PL = GameObject.FindGameObjectWithTag(PlayerTag);

        Player = PL.GetComponent<Transform>();
    }

    void Update()
    {
        if (followPlayer == true)
        {
            _Follow();
        }

        else enemy.SetDestination(Enemy.position);
    }

    public void _Follow()
    {
        enemy.SetDestination(Player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            followPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            followPlayer = false;
        }
    }
}
