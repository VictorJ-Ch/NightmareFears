using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] Points;
    public int current;
    public float speed, rotSpeed, _distance;

    void Update()
    {
        if (Vector3.Distance(this.transform.position, Points[current].transform.position) < _distance)
        {
            current++;
        }

        if (current >= Points.Length)
        {
            current = 0;
        }

        Quaternion lookAtWP = Quaternion.LookRotation(Points[current].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWP, Time.deltaTime * rotSpeed);
        this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }
}
