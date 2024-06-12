using UnityEngine;
using UnityEngine.UI;

public class OtherBackground : MonoBehaviour
{
    public PolicyLoader policy;

    public Button backButton;
    public Button forwardButton;

    private void OnEnable()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                policy.BackPage();
            });
        }

        if (forwardButton != null)
        {
            forwardButton.onClick.RemoveAllListeners();
            forwardButton.onClick.AddListener(() =>
            {
                policy.ForwardPage();
            });
        }
    }
}
