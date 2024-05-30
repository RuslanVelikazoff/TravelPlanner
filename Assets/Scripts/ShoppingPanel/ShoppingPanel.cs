using UnityEngine;
using UnityEngine.UI;

public class ShoppingPanel : MonoBehaviour
{
    [SerializeField]
    private Button allPurchaseButton;
    [SerializeField] 
    private Button clothesButton;
    [SerializeField] 
    private Button cosmeticsButton;
    [SerializeField] 
    private Button groceriesButton;
    [SerializeField] 
    private Button electronicsButton;
    [SerializeField] 
    private Button newPurchaseButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject newPurchasePanel;
    [SerializeField] 
    private CategoryPanel categoryPanel;

    private void Awake()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (newPurchaseButton != null)
        {
            newPurchaseButton.onClick.RemoveAllListeners();
            newPurchaseButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                newPurchasePanel.SetActive(true);
            });
        }

        if (allPurchaseButton != null)
        {
            allPurchaseButton.onClick.RemoveAllListeners();
            allPurchaseButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                categoryPanel.OpenPanel(GameData.ShoppingCategory.Null);
            });
        }

        if (clothesButton != null)
        {
            clothesButton.onClick.RemoveAllListeners();
            clothesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                categoryPanel.OpenPanel(GameData.ShoppingCategory.Clothes);
            });
        }

        if (cosmeticsButton != null)
        {
            cosmeticsButton.onClick.RemoveAllListeners();
            cosmeticsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                categoryPanel.OpenPanel(GameData.ShoppingCategory.Cosmetics);
            });
        }

        if (groceriesButton != null)
        {
            groceriesButton.onClick.RemoveAllListeners();
            groceriesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                categoryPanel.OpenPanel(GameData.ShoppingCategory.Groceries);
            });
        }

        if (electronicsButton != null)
        {
            electronicsButton.onClick.RemoveAllListeners();
            electronicsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                categoryPanel.OpenPanel(GameData.ShoppingCategory.Electronics);
            });
        }
    }
}
