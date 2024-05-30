using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI purchaseText;

    [SerializeField] 
    private Button deletePurchaseButton;
    [SerializeField]
    private Button completedButton;
    [SerializeField]
    private Button notCompletedButton;

    private int purchaseIndex;

    public void SpawnPrefab(int index)
    {
        purchaseIndex = index;
        
        ButtonClickAction();
        SetCompletedButton();
        SetPurchaseText();
    }

    private void SetCompletedButton()
    {
        if (ShoppingData.Instance.IsCompletedPurchase(purchaseIndex))
        {
            completedButton.gameObject.SetActive(true);
            notCompletedButton.gameObject.SetActive(false);
        }
        else
        {
            completedButton.gameObject.SetActive(false);
            notCompletedButton.gameObject.SetActive(true);
        }
    }
    
    private void SetPurchaseText()
    {
        purchaseText.text = "* " + ShoppingData.Instance.GetPurchaseText(purchaseIndex);
    }

    private void ButtonClickAction()
    {
        if (deletePurchaseButton != null)
        {
            deletePurchaseButton.onClick.RemoveAllListeners();
            deletePurchaseButton.onClick.AddListener(() =>
            {
                ShoppingData.Instance.DeletePurchase(purchaseIndex);
                Destroy(this.gameObject);
            });
        }

        if (completedButton != null)
        {
            completedButton.onClick.RemoveAllListeners();
            completedButton.onClick.AddListener(() =>
            {
                ShoppingData.Instance.ChangeCompletePurchase(purchaseIndex, false);
                SetCompletedButton();
            });
        }

        if (notCompletedButton != null)
        {
            notCompletedButton.onClick.RemoveAllListeners();
            notCompletedButton.onClick.AddListener(() =>
            {
                ShoppingData.Instance.ChangeCompletePurchase(purchaseIndex, true);
                SetCompletedButton();
            });
        }
    }
}
