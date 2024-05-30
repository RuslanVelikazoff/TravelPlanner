using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.iOS.NotificationServices;

public class NotificationController : MonoBehaviour
{
    [SerializeField] 
    private PushNotification pushNotification;

    private void Start()
    {
        StartCoroutine(pushNotification.RequestAuothorization());
        CancelAllLocalNotifications();
    }

    private void OnApplicationQuit()
    {
        CreateNotifications();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            CreateNotifications();
        }
    }

    private void CreateNotifications()
    {
        List<int> remindersNotification = RemindersData.Instance.GetRemindersIndexList();

        for (int i = 0; i < remindersNotification.Count; i++)
        {
            pushNotification.SendNotification("Reminder!", 
                RemindersData.Instance.GetReminderText(i), 
                RemindersData.Instance.GetReminderDate(i));
        }
    }
}
