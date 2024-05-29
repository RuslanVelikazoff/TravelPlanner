using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerPanel : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField] 
    private Button pauseButton;
    [SerializeField] 
    private Button resetButton;
    
    [Space(13)]
    
    [SerializeField] 
    private TMP_InputField nameInputField;
    
    [Space(13)]

    [SerializeField] 
    private TextMeshProUGUI timerText;

    private int hour = 0;
    private string hourString;
    private int minute = 0;
    private string minuteString;
    private float seconds = 0f;
    private string secondString;

    private bool startTimer = false;

    private void OnEnable()
    {
        ButtonClickAction();
        ResetTimerPanel();
    }

    private void OnDisable()
    {
        startTimer = false;
    }

    private void Update()
    {
        if (startTimer)
        {
            seconds += Time.deltaTime;
            if (seconds >= 60)
            {
                minute++;
                seconds = 0;
                if (minute >= 60)
                {
                    hour++;
                    minute = 0;
                }
            }

            SetTimerText();
        }
    }

    private void ButtonClickAction()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(() =>
            {
                startTimer = true;
                playButton.gameObject.SetActive(false);
                pauseButton.gameObject.SetActive(true);
            });
        }

        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(() =>
            {
                startTimer = false;
                playButton.gameObject.SetActive(true);
                pauseButton.gameObject.SetActive(false);
            });
        }

        if (resetButton != null)
        {
            resetButton.onClick.RemoveAllListeners();
            resetButton.onClick.AddListener(() =>
            {
                ResetTimerPanel();
            });
        }
    }

    private void SetTimerText()
    {
        if (seconds < 10)
        {
            secondString = "0" + (int) seconds;
        }
        else
        {
            secondString = ((int)seconds).ToString();
        }

        if (minute < 10)
        {
            minuteString = "0" + minute;
        }
        else
        {
            minuteString = minute.ToString();
        }

        if (hour < 10)
        {
            hourString = "0" + hour;
        }
        else
        {
            hourString = hour.ToString();
        }

        timerText.text = $"{hourString}:{minuteString}:{secondString}";
    }

    private void ResetTimerPanel()
    {
        startTimer = false;
        nameInputField.text = string.Empty;
        seconds = 0;
        minute = 0;
        hour = 0;
        SetTimerText();
        
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(true);
    }
}
