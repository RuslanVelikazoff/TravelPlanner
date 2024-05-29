using TMPro;
using UnityEngine;

public class ReminderPrefab : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI reminderText;

    private int reminderIndex;

    public void SpawnReminderPrefab(int index)
    {
        reminderIndex = index;
        
        SetReminderText();
    }

    private void SetReminderText()
    {
        reminderText.text = RemindersData.Instance.GetReminderText(reminderIndex);
    }
}
