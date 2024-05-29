using UnityEngine;
using UnityEngine.UI;

public class TravelPanel : MonoBehaviour
{
    [SerializeField] 
    private Button newTravelButton;

    [SerializeField] 
    private GameObject newTravelPanel;

    [SerializeField] 
    private TravelScrollView scrollView;

    private void OnEnable()
    {
        scrollView.ResetTravels();
        scrollView.SpawnPrefabs();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (newTravelButton != null)
        {
            newTravelButton.onClick.RemoveAllListeners();
            newTravelButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                newTravelPanel.SetActive(true);
            });
        }
    }
}
