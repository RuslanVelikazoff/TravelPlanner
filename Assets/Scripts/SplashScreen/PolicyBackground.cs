using UnityEngine;
using UnityEngine.UI;

public class PolicyBackground : MonoBehaviour
{
    public PolicyLoader policy;

    public Button agreeButton;

    private void OnEnable()
    {
        if (agreeButton != null)
        {
            agreeButton.onClick.RemoveAllListeners();
            agreeButton.onClick.AddListener(() =>
            {
                policy.ConfirmPolicy();
            });
        }
    }
}
