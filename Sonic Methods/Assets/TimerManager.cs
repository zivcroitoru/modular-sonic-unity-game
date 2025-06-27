using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public int startTime = 300;
    private float timer;
    public TextMeshProUGUI timerText;
    public GameObject player;

    void Start()
    {
        timer = startTime;

        if (timerText == null)
            timerText = FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            int displayTime = Mathf.CeilToInt(timer);
            timerText.text = $"{displayTime}<size=60%> SEC</size>";
        }
        else
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        if (player != null)
        {
            Debug.Log("Time's up! Player is dead.");
            Destroy(player);
            enabled = false;
        }
    }
}
