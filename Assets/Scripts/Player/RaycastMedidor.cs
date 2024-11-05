using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar escenas
using UnityEngine.UI;

public class RaycastMedidor : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 newEnemyPosition;

    private float rayDistance = 10f;
    public LayerMask enemyLayer;
    public Image meterImage;
    private float meterValue = 0f;
    private bool isTouchingEnemy = false;
    public string BadEnding; // Escena del final malo

    public Camera cam; // Asigna tu cámara en el inspector

    private void Start()
    {
        BearHug.Hug += HuggingBear;
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance, enemyLayer))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                isTouchingEnemy = true;
            }
        }
        else
        {
            isTouchingEnemy = false;
        }

        if (isTouchingEnemy)
        {
            IncreaseMeter();
        }

        UpdateMeterUI();
        CheckMeterValue(); // Llamamos al método para verificar si se debe cambiar de escena
    }

    void IncreaseMeter()
    {

        if (rayDistance < 5f && meterValue < 100f)
        {
            meterValue += Time.deltaTime * 8;
        }

        if (meterValue < 100f)
        {
            meterValue += Time.deltaTime * 4; // Incrementa el medidor a una velocidad de 10 unidades por segundo
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            meterValue += 15f;

            other.transform.position = newEnemyPosition;
            //enemy.tr = new Vector3(21.79f, -6f, -13.89f);

        }
    }




    void UpdateMeterUI()
    {
        meterImage.fillAmount = meterValue / 100f;
    }

    void HuggingBear()
    {
        if (meterValue >= 0)
        {
            meterValue -= Time.deltaTime * 10;
        }
    }

    // Nueva función para verificar el valor del medidor y cambiar de escena
    void CheckMeterValue()
    {
        if (meterValue >= 100f)
        {
            print("Medidor al máximo, cambiando de escena...");
            SceneManager.LoadScene(BadEnding); // Cambiar a la escena de "Bad Ending"
        }
    }
}
