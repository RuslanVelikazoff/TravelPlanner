using System.Collections.Generic;
using UnityEngine;

public class ShoppingScrollView : MonoBehaviour
{
    [SerializeField] 
    private GameObject shoppingPrefab;

    [SerializeField] 
    private Canvas canvas;

    private List<GameObject> purchases = new List<GameObject>();
    private List<int> purchasesIndex;

    public void SpawnPrefabs(GameData.ShoppingCategory category)
    {
        purchasesIndex = ShoppingData.Instance.GetPurchasesIndexList(category);

        for (int i = 0; i < purchasesIndex.Count; i++)
        {
            var purchase = Instantiate(shoppingPrefab, transform.position, Quaternion.identity);
            purchase.transform.SetParent(canvas.transform);
            purchase.transform.localScale = new Vector3(1, 1, 1);
            purchase.transform.SetParent(this.gameObject.transform);
            purchase.GetComponent<ShoppingPrefab>().SpawnPrefab(purchasesIndex[i]);
            purchases.Add(purchase);
        }
    }

    public void ResetPurchases()
    {
        if (purchases != null)
        {
            for (int i = 0; i < purchases.Count; i++)
            {
                Destroy(purchases[i]);
                purchases.RemoveAt(i);
                ResetPurchases();
            }
        }
    }
}
