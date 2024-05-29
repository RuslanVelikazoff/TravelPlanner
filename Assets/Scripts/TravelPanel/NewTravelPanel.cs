using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewTravelPanel : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField[] allInputFields;
    
    [Space(13)]
    
    [SerializeField] 
    private TMP_InputField cityInputField;
    [SerializeField] 
    private TMP_InputField placesInputField;
    [SerializeField] 
    private TMP_InputField budgetInputField;
    [SerializeField]
    private TMP_InputField dayInputField;
    [SerializeField] 
    private TMP_InputField monthInputField;
    [SerializeField] 
    private TMP_InputField yearInputField;
    
    [Space(13)]

    [SerializeField]
    private Button createNewTravelButton;
    
    [Space(13)]

    [SerializeField] 
    private GameObject travelPanel;

    private string cityString;
    private string placesString;
    private int budget;

    private int day;
    private int month;
    private int year;

    private DateTime date;

    private void OnEnable()
    {
        ResetAllInputFields();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (createNewTravelButton != null)
        {
            createNewTravelButton.onClick.RemoveAllListeners();
            createNewTravelButton.onClick.AddListener(() =>
            {
                WritingToData();
            });
        }
    }

    private void WritingToData()
    {
        if (!IsEmptyInputFields())
        {
            cityString = cityInputField.text;
            placesString = placesInputField.text;
            budget = Int32.Parse(budgetInputField.text);
            
            day = Int32.Parse(dayInputField.text);
            month = Int32.Parse(monthInputField.text);
            year = Int32.Parse(yearInputField.text);

            if (IsTrueDate(year, month, day))
            {
                date = new DateTime(year, month, day);

                if (IsDateValidate())
                {
                    TravelData.Instance.SetCity(cityString);
                    TravelData.Instance.SetPlaces(placesString);
                    TravelData.Instance.SetBudget(budget);
                    TravelData.Instance.SetDate(date);
                    
                    this.gameObject.SetActive(false);
                    travelPanel.SetActive(true);
                }
            }
        }
    }

    private bool IsEmptyInputFields()
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

    private bool IsTrueDate(int year, int month, int day)
    {
        string dateString = $"{year}.{month}.{day}";

        if (DateTime.TryParse(dateString, out DateTime result))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsDateValidate()
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
        for (int i = 0; i < allInputFields.Length; i++)
        {
            allInputFields[i].text = string.Empty;
        }
    }
}
