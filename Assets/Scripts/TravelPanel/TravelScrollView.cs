using System.Collections.Generic;
using UnityEngine;

public class TravelScrollView : MonoBehaviour
{
    [SerializeField] 
    private GameObject travelPrefab;

    [SerializeField]
    private Canvas canvas;

    private List<GameObject> travels = new List<GameObject>();
    private List<int> travelsIndex;

    public void SpawnPrefabs()
    {
        travelsIndex = TravelData.Instance.GetTravelsIndex();

        for (int i = 0; i < travelsIndex.Count; i++)
        {
            var travel = Instantiate(travelPrefab, transform.position, Quaternion.identity);
            travel.transform.SetParent(canvas.transform);
            travel.transform.localScale = new Vector3(1, 1, 1);
            travel.transform.SetParent(this.gameObject.transform);
            travel.GetComponent<TravelPrefab>().SpawnNotesPrefab(travelsIndex[i]);
            travels.Add(travel);
        }
    }

    public void ResetTravels()
    {
        if (travels.Count != 0)
        {
            for (int i = 0; i < travels.Count; i++)
            {
                Destroy(travels[i]);
                travels.RemoveAt(i);
                ResetTravels();
            }
        }
    }
}
