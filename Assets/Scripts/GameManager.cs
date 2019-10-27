using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private static GameManager instance;

    public bool isGameOver = false;
    public float totalTime;
    public GameObject txt_GameOver;

    private Text txt_Timer;
    private float timer=0;


    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        txt_Timer = GameObject.Find("Txt_Timer").GetComponent<Text>();
    }

    private void Update()
    {
        if (timer >= 1)
        {
            txt_Timer.text = totalTime.ToString();
            totalTime -= 1;
            if (totalTime <= 0)
            {
                AudioManager.Instance.CloseBGMusic();
                txt_GameOver.SetActive(true);
                totalTime = 0;
                txt_Timer.text = totalTime.ToString();
                isGameOver = true;
                return;
            }
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void OnRestartBtnClick()
    {
        SceneManager.LoadScene(0);
    }
}
