using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewPurchasePanel : MonoBehaviour
{
    [SerializeField] 
    private Button createButton;
    [SerializeField]
    private GameObject shoppingPanel;

    [Space(13)] 
    
    [SerializeField] 
    private Button clothesCategoryButton;
    [SerializeField] 
    private Button cosmeticsCategoryButton;
    [SerializeField] 
    private Button groceriesCategoryButton;
    [SerializeField] 
    private Button electronicsCategoryButton;

    [Space(13)]
    
    [SerializeField] 
    private Color activeColor;
    [SerializeField] 
    private Color inactiveColor;

    [Space(13)]
    
    [SerializeField] private TMP_InputField purchaseInputField;

    private string purchaseText;
    private GameData.ShoppingCategory category;

    private void OnEnable()
    {
        purchaseText = string.Empty;
        category = GameData.ShoppingCategory.Null;
        purchaseInputField.text = purchaseText;
        
        SetCategoryButtonSprites();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (clothesCategoryButton != null)
        {
            clothesCategoryButton.onClick.RemoveAllListeners();
            clothesCategoryButton.onClick.AddListener(() =>
            {
                category = GameData.ShoppingCategory.Clothes;
                SetCategoryButtonSprites();
            });
        }

        if (cosmeticsCategoryButton != null)
        {
            cosmeticsCategoryButton.onClick.RemoveAllListeners();
            cosmeticsCategoryButton.onClick.AddListener(() =>
            {
                category = GameData.ShoppingCategory.Cosmetics;
                SetCategoryButtonSprites();
            });
        }

        if (groceriesCategoryButton != null)
        {
            groceriesCategoryButton.onClick.RemoveAllListeners();
            groceriesCategoryButton.onClick.AddListener(() =>
            {
                category = GameData.ShoppingCategory.Groceries;
                SetCategoryButtonSprites();
            });
        }

        if (electronicsCategoryButton != null)
        {
            electronicsCategoryButton.onClick.RemoveAllListeners();
            electronicsCategoryButton.onClick.AddListener(() =>
            {
                category = GameData.ShoppingCategory.Electronics;
                SetCategoryButtonSprites();
            });
        }

        if (createButton != null)
        {
            createButton.onClick.RemoveAllListeners();
            createButton.onClick.AddListener(() =>
            {
                if (CreateNewPurchase())
                {
                    this.gameObject.SetActive(false);
                    shoppingPanel.SetActive(true);
                }
            });
        }
    }

    private bool CreateNewPurchase()
    {
        purchaseText = purchaseInputField.text;

        if (purchaseText != string.Empty && category != GameData.ShoppingCategory.Null)
        {
            ShoppingData.Instance.CreatePurchase(purchaseText, category);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetCategoryButtonSprites()
    {
        switch (category)
        {
            case GameData.ShoppingCategory.Null:
                clothesCategoryButton.GetComponent<Image>().color = inactiveColor;
                cosmeticsCategoryButton.GetComponent<Image>().color = inactiveColor;
                groceriesCategoryButton.GetComponent<Image>().color = inactiveColor;
                electronicsCategoryButton.GetComponent<Image>().color = inactiveColor;
                break;
            case GameData.ShoppingCategory.Clothes:
                clothesCategoryButton.GetComponent<Image>().color = activeColor;
                cosmeticsCategoryButton.GetComponent<Image>().color = inactiveColor;
                groceriesCategoryButton.GetComponent<Image>().color = inactiveColor;
                electronicsCategoryButton.GetComponent<Image>().color = inactiveColor;
                break;
            case GameData.ShoppingCategory.Cosmetics:
                clothesCategoryButton.GetComponent<Image>().color = inactiveColor;
                cosmeticsCategoryButton.GetComponent<Image>().color = activeColor;
                groceriesCategoryButton.GetComponent<Image>().color = inactiveColor;
                electronicsCategoryButton.GetComponent<Image>().color = inactiveColor;
                break;
            case GameData.ShoppingCategory.Groceries:
                clothesCategoryButton.GetComponent<Image>().color = inactiveColor;
                cosmeticsCategoryButton.GetComponent<Image>().color = inactiveColor;
                groceriesCategoryButton.GetComponent<Image>().color = activeColor;
                electronicsCategoryButton.GetComponent<Image>().color = inactiveColor;
                break;
            case GameData.ShoppingCategory.Electronics:
                clothesCategoryButton.GetComponent<Image>().color = inactiveColor;
                cosmeticsCategoryButton.GetComponent<Image>().color = inactiveColor;
                groceriesCategoryButton.GetComponent<Image>().color = inactiveColor;
                electronicsCategoryButton.GetComponent<Image>().color = activeColor;
                break;
        }
    }
}
