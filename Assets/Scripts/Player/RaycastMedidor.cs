using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaycastMedidor : MonoBehaviour
{
    public GameObject doorTuto;
    private bool doorTutoDisabled = false;

    public GameObject enemy;
    public Vector3 newEnemyPosition;

    private float rayDistance = 10f;
    public LayerMask enemyLayer;
    public Image meterImage;
    private float meterValue = 30f;
    private bool isTouchingEnemy = false;
    public string BadEnding;

    public Camera cam;

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
        CheckMeterValue();
    }

    void IncreaseMeter()
    {

        if (rayDistance < 5f && meterValue < 100f)
        {
            meterValue += Time.deltaTime * 8;
        }

        if (meterValue < 100f)
        {
            meterValue += Time.deltaTime * 4;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            meterValue += 100f;

            //other.transform.position = newEnemyPosition;
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
            if (meterValue <= 0 && !doorTutoDisabled) { 
                doorTuto.SetActive(false); 
                doorTutoDisabled = true; 
                }
        }
    }

    void CheckMeterValue()
    {
        if (meterValue >= 100f)
        {
            print("Medidor al máximo, cambiando de escena...");
            SceneManager.LoadScene(BadEnding); 
        }
    }
}
