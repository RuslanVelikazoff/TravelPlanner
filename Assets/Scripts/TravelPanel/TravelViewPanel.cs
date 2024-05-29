using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TravelViewPanel : MonoBehaviour
{
    public static TravelViewPanel Instance { get; private set; }

    [SerializeField] 
    private TextMeshProUGUI cityText;
    [SerializeField] 
    private TextMeshProUGUI placesText;
    [SerializeField] 
    private TextMeshProUGUI budgetText;
    [SerializeField] 
    private TextMeshProUGUI dateText;

    [Space(13)]
    
    [SerializeField]
    private Button deleteButton;
    
    [Space(13)]
    
    [SerializeField] 
    private GameObject travelPanel;
    
    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    public void OpenTravelViewPanel(int travelIndex)
    {
        this.gameObject.SetActive(true);
        travelPanel.SetActive(false);
        ButtonClickAction(travelIndex);
        
        cityText.text = TravelData.Instance.GetCityText(travelIndex);
        placesText.text = TravelData.Instance.GetPlacesText(travelIndex);
        budgetText.text = TravelData.Instance.GetBudget(travelIndex).ToString();
        dateText.text = TravelData.Instance.GetDate(travelIndex).ToString("dd/MM/yyyy");
    }

    private void ButtonClickAction(int travelIndex)
    {
        if (deleteButton != null)
        {
            deleteButton.onClick.RemoveAllListeners();
            deleteButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                travelPanel.SetActive(true);
                TravelData.Instance.DeleteTravel(travelIndex);
            });
        }
    }
}
