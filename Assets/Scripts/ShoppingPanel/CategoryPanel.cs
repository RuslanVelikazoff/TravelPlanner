using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryPanel : MonoBehaviour
{
    [SerializeField]
    private Button newPurchaseButton;
    
    [SerializeField] 
    private GameObject newPurchasePanel;
    
    [SerializeField] 
    private TextMeshProUGUI categoryText;

    [SerializeField] 
    private ShoppingScrollView scrollView;

    private GameData.ShoppingCategory category;
    
    public void OpenPanel(GameData.ShoppingCategory selectedCategory)
    {
        this.gameObject.SetActive(true);
        category = selectedCategory;

        scrollView.ResetPurchases();
        scrollView.SpawnPrefabs(category);
        
        SetCategoryText();
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
    }

    private void SetCategoryText()
    {
        switch (category)
        {
            case GameData.ShoppingCategory.Null:
                categoryText.text = "All purchases";
                break;
            case GameData.ShoppingCategory.Clothes:
                categoryText.text = "Clothes";
                break;
            case GameData.ShoppingCategory.Cosmetics:
                categoryText.text = "Cosmetics";
                break;
            case GameData.ShoppingCategory.Groceries:
                categoryText.text = "Groceries";
                break;
            case GameData.ShoppingCategory.Electronics:
                categoryText.text = "Electronics";
                break;
        }
    }
}
