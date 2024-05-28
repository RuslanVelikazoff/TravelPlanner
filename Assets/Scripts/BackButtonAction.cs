using UnityEngine;
using UnityEngine.UI;

public class BackButtonAction : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    
    [SerializeField] 
    private GameObject openPanel;
    [SerializeField] 
    private GameObject closePanel;

    private void OnEnable()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                openPanel.SetActive(true);
                closePanel.SetActive(false);
            });
        }
    }
}
