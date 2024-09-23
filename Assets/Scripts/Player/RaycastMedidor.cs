using UnityEngine;
using UnityEngine.UI;

public class RaycastMedidor : MonoBehaviour
{
    public float rayDistance = 10f;
    public LayerMask enemyLayer;
    public Image meterImage;
    private float meterValue = 0f;
    private bool isTouchingEnemy = false;

    public Camera cam; // Asigna tu cámara en el inspector

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
    }

    void IncreaseMeter()
    {
        if (meterValue < 100f)
        {
            meterValue += Time.deltaTime * 10; // Incrementa el medidor a una velocidad de 10 unidades por segundo
        }
    }

    void UpdateMeterUI()
    {
        meterImage.fillAmount = meterValue / 100f;
    }
}
