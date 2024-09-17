using UnityEngine;

public class RaycastFromCamera : MonoBehaviour
{
    public Camera cam; // Asigna tu cámara en el inspector

    void Update()
    {
        // Lanza el raycast desde el centro de la cámara
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Si el raycast golpea un GameObject
            Renderer renderer = hit.transform.GetComponent<Renderer>();
            if (renderer != null)
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    // Si el GameObject tiene el tag "Enemy", cambia su color a rojo
                    renderer.material.color = Color.red;
                }
                
            }
        }
    }
}