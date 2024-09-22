using UnityEngine;
using UnityEngine.UI;

public class RaycastFromCamera : MonoBehaviour
{
    //Barra de ansiedad
   // public Image medidorAnsiedad;
    //public float ansiedadActual;
    //public float ansiedadMaxima;

    //private int meterValue = 0; // Valor del medidor

    //Raycast enemy
    public float rayDistance = 10f; // Distancia del raycast
    public Camera cam; // Asigna tu c�mara en el inspector

    private GameObject lastHitObject = null; // �ltimo objeto golpeado por el raycast
    private Color originalColor; // Color original del objeto



    void Update()
    {
        RaycastEnemy();
        //MedidorAnsiedad();
    }

    private void RaycastEnemy()
    {
        // Lanza el raycast desde el centro de la c�mara
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
                        // Restaurar el color original del �ltimo objeto golpeado
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
            // Si el raycast no golpea nada, restaurar el color del �ltimo objeto golpeado
            if (lastHitObject != null)
            {
                lastHitObject.GetComponent<Renderer>().material.color = originalColor;
                lastHitObject = null;
            }
        }
    }
    /*
    private void MedidorAnsiedad()
    {
        // Obtener la posici�n y direcci�n de la c�mara principal
        Camera mainCamera = Camera.main;
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        // Dibujar el raycast en la escena (solo para depuraci�n)
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);

        // Verificar si el raycast golpea un objeto
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Verificar si el objeto tiene el tag "Enemy"
            if (hit.collider.CompareTag("Enemy"))
            {
                // Si es un nuevo objeto, incrementar el medidor
                if (lastHitObject != hit.collider.gameObject)
                {
                    lastHitObject = hit.collider.gameObject;
                    IncrementMeter();
                }
            }
        }
        else
        {
            // Si el raycast no golpea nada, reiniciar el �ltimo objeto golpeado
            lastHitObject = null;
        }
    }

    void IncrementMeter()
    {
        if (meterValue < 100)
        {
            meterValue++;
            medidorAnsiedad.fillAmount = meterValue / 100f; // Actualizar la imagen del medidor
        }
    }*/

}