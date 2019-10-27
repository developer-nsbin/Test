using UnityEngine;

public class Turret : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject bullet;
    public GameObject fireEffect;
    public float shootPerTime;

    private Transform pylon;
    private float minAngle=0;
    private float xMaxAngle = 30;
    private float yMaxAngle = 16;
    private Transform firePos;
    private float timer;

    private void Awake()
    {
        pylon = transform.Find("Base/Pylon").transform;
        firePos = transform.Find("Base/Pylon/FirePos").transform;
    }

    private void Update()
    {
        if (GameManager.Instance.isGameOver) return;
        Rotate();
        Shoot();
    }

    private void Rotate()
    {

        float xCurrentProportion = Input.mousePosition.x / Screen.width;
        float yCurrentProportion = Input.mousePosition.y / Screen.height;

        float xAngle = Mathf.Clamp(xCurrentProportion * xMaxAngle, minAngle, xMaxAngle) - 105;//父物体有角度
        float yAngle = Mathf.Clamp(yCurrentProportion * yMaxAngle, minAngle, yMaxAngle) - 1;

        pylon.transform.eulerAngles = new Vector3(0, xAngle, yAngle);
    }

    private void Shoot()
    {
        if (timer >= shootPerTime)
        {
            timer = shootPerTime + 1;//控制timer的最高值

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(fireEffect, firePos.position, Quaternion.identity);
                AudioManager.Instance.PlayEffectMusic(AudioManager.Instance.fireClip);
                Instantiate(bullet, firePos.position, firePos.rotation);
                timer = 0;
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
