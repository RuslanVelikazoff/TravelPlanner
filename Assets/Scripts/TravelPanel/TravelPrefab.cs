using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TravelPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI travelText;

    [SerializeField] 
    private Button travelButton;

    private int travelIndex;

    public void SpawnNotesPrefab(int index)
    {
        travelIndex = index;
        
        SetTravelText();
        ButtonClickAction();
    }

    private void SetTravelText()
    {
        travelText.text = TravelData.Instance.GetCityText(travelIndex);
    }

    private void ButtonClickAction()
    {
        if (travelButton != null)
        {
            travelButton.onClick.RemoveAllListeners();
            travelButton.onClick.AddListener(() =>
            {
                TravelViewPanel.Instance.OpenTravelViewPanel(travelIndex);
            });
        }
    }
}
