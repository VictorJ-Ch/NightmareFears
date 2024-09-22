using UnityEngine;

public class RaycastFromCamera : MonoBehaviour
{
    public float rayDistance = 10f; // Distancia del raycast
    public Camera cam; // Asigna tu cámara en el inspector

    private GameObject lastHitObject = null; // Último objeto golpeado por el raycast
    private Color originalColor; // Color original del objeto

    void Update()
    {
        // Lanza el raycast desde el centro de la cámara
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

       // Verificar si el raycast golpea un objeto
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Verificar si el objeto tiene el tag "Enemy"
            if (hit.collider.CompareTag("Enemy"))
            {
                // Si es un nuevo objeto, guardar su color original
                if (lastHitObject != hit.collider.gameObject)
                {
                    if (lastHitObject != null)
                    {
                        // Restaurar el color original del último objeto golpeado
                        lastHitObject.GetComponent<Renderer>().material.color = originalColor;
                    }

                    lastHitObject = hit.collider.gameObject;
                    originalColor = lastHitObject.GetComponent<Renderer>().material.color;
                }

                // Cambiar el color del objeto a rojo
                hit.collider.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else
        {
            // Si el raycast no golpea nada, restaurar el color del último objeto golpeado
            if (lastHitObject != null)
            {
                lastHitObject.GetComponent<Renderer>().material.color = originalColor;
                lastHitObject = null;
            }
        }
    }
}