using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewReminderPanel : MonoBehaviour
{
    [SerializeField] 
    private Button createNewReminderButton;
    
    [Space(13)]

    [SerializeField] 
    private GameObject reminderPanel;
    
    [Space(13)]

    [SerializeField] 
    private TMP_InputField[] allInputFields;
    
    [Space(13)]

    [SerializeField] 
    private TMP_InputField reminderTextInputField;
    [SerializeField] 
    private TMP_InputField dayInputField;
    [SerializeField] 
    private TMP_InputField monthInputField;
    [SerializeField] 
    private TMP_InputField yearInputField;
    [SerializeField] 
    private TMP_InputField hourInputField;
    [SerializeField] 
    private TMP_InputField minuteInputField;

    private string reminderText;
    private int day;
    private int month;
    private int year;
    private int hour;
    private int minute;
    private int second = 0;

    private DateTime date;

    private void OnEnable()
    {
        ResetAllInputFields();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (createNewReminderButton != null)
        {
            createNewReminderButton.onClick.RemoveAllListeners();
            createNewReminderButton.onClick.AddListener(() =>
            {
                WritingReminderToData();
            });
        }
    }

    private void WritingReminderToData()
    {
        if (!IsEmptyInputField())
        {
            reminderText = reminderTextInputField.text;
            day = Int32.Parse(dayInputField.text);
            month = Int32.Parse(monthInputField.text);
            year = Int32.Parse(yearInputField.text);
            hour = Int32.Parse(hourInputField.text);
            minute = Int32.Parse(minuteInputField.text);

            if (IsTrueDate())
            {
                date = new DateTime(year, month, day, hour, minute, second);

                if (IsValidateDate())
                {
                    RemindersData.Instance.SetReminderText(reminderText);
                    RemindersData.Instance.SetReminderDate(date);

                    this.gameObject.SetActive(false);
                    reminderPanel.SetActive(true);
                }
            }
        }
    }

    private bool IsEmptyInputField()
    {
        for (int i = 0; i < allInputFields.Length; i++)
        {
            if (allInputFields[i].text == string.Empty)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsTrueDate()
    {
        string dateString = $"{year}.{month}.{day} {hour}:{minute}:{second}";

        if (DateTime.TryParse(dateString, out DateTime result))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsValidateDate()
    {
        if (date > DateTime.Now)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ResetAllInputFields()
    {
        reminderText = string.Empty;
        reminderTextInputField.text = reminderText;

        day = 0;
        dayInputField.text = string.Empty;

        month = 0;
        monthInputField.text = string.Empty;

        year = 0;
        yearInputField.text = string.Empty;

        hour = 0;
        hourInputField.text = string.Empty;

        minute = 0;
        minuteInputField.text = string.Empty;
    }

}
