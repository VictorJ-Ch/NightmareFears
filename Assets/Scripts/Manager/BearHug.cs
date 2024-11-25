using System;
using UnityEngine;

public class BearHug : MonoBehaviour
{
    public static event Action Hug;
    public static event Action UnHug;

    public GameObject Right, Left, Visor;
    public bool Hands, Head, hug/*, prueba*/;

    public float HandsX, VisorY, VisorZ, rightHandY, rightHandZ, leftHandY, leftHandZ;

    private void Awake()
    {
        bear.onGrab += grab;
        bear.onRelease += release;
    }
    void Update()
    {
        canHug();
    }

    void canHug()
    {
        //Calculo abrazo start
        Vector3 RightHand = new Vector3(Right.transform.position.x, Right.transform.position.y, Right.transform.position.z);
        Vector3 LeftHand = new Vector3(Left.transform.position.x, Left.transform.position.y, Left.transform.position.z);
        Vector3 VisorHead = new Vector3(Visor.transform.position.x, Visor.transform.position.y, Visor.transform.position.z);

        rightHandY = VisorHead.y - RightHand.y;
        rightHandZ = VisorHead.z - RightHand.z;

        leftHandY = VisorHead.y - LeftHand.y;
        leftHandZ = VisorHead.z - LeftHand.z;

        float handsX = (RightHand.x - LeftHand.x);
        //Calculo abrazo end

        if (rightHandY <= VisorY && leftHandY <= VisorY && rightHandZ <= VisorZ && leftHandZ <= VisorZ && handsX <= HandsX && hug == true)
        {
            Hug?.Invoke();
        }
        else
        {
            UnHug?.Invoke();
        }
        //if(prueba == true)
        //{
        //    Hug?.Invoke();
        //}
    }

    void grab()
    {
        hug = true;
    }

    void release()
    {   
        hug = false;
    }
}
