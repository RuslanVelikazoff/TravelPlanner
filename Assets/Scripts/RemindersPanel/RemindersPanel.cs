using UnityEngine;
using UnityEngine.UI;

public class RemindersPanel : MonoBehaviour
{
    [SerializeField] 
    private Button timerButton;
    [SerializeField] 
    private Button newReminderButton;
    
    [Space(13)]

    [SerializeField] 
    private GameObject timerPanel;
    [SerializeField] 
    private GameObject newReminderPanel;

    [Space(13)] 
    
    [SerializeField] 
    private RemindersScrollView scrollView;

    private void OnEnable()
    {
        scrollView.ResetReminders();
        scrollView.SpawnPrefabs();
        
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (timerButton != null)
        {
            timerButton.onClick.RemoveAllListeners();
            timerButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                timerPanel.SetActive(true);
            });
        }

        if (newReminderButton != null)
        {
            newReminderButton.onClick.RemoveAllListeners();
            newReminderButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                newReminderPanel.SetActive(true);
            });
        }
    }
}
