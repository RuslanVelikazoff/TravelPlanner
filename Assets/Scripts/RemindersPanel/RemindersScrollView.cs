using System.Collections.Generic;
using UnityEngine;

public class RemindersScrollView : MonoBehaviour
{
    [SerializeField] 
    private GameObject reminderPrefab;

    [SerializeField] 
    private Canvas canvas;

    private List<GameObject> reminders = new List<GameObject>();
    private List<int> remindersIndex;

    public void SpawnPrefabs()
    {
        remindersIndex = RemindersData.Instance.GetRemindersIndexList();

        for (int i = 0; i < remindersIndex.Count; i++)
        {
            var reminder = Instantiate(reminderPrefab, transform.position, Quaternion.identity);
            reminder.transform.SetParent(canvas.transform);
            reminder.transform.localScale = new Vector3(1, 1, 1);
            reminder.transform.SetParent(this.gameObject.transform);
            reminder.GetComponent<ReminderPrefab>().SpawnReminderPrefab(remindersIndex[i]);
            reminders.Add(reminder);
        }
    }

    public void ResetReminders()
    {
        if (reminders.Count != 0)
        {
            for (int i = 0; i < reminders.Count; i++)
            {
                Destroy(reminders[i]);
                reminders.RemoveAt(i);
                ResetReminders();
            }
        }
    }
}
