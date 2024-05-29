using System.Collections.Generic;
using UnityEngine;

public class JournalScrollView : MonoBehaviour
{
    [SerializeField]
    private GameObject journalEntryPrefab;

    [SerializeField] 
    private Canvas canvas;

    private List<GameObject> journalEntry = new List<GameObject>();
    private List<int> journalEntryIndex;

    public void SpawnPrefabs()
    {
        journalEntryIndex = JournalData.Instance.GetJournalEntryIndex();

        for (int i = 0; i < journalEntryIndex.Count; i++)
        {
            var entry = Instantiate(journalEntryPrefab, transform.position, Quaternion.identity);
            entry.transform.SetParent(canvas.transform);
            entry.transform.localScale = new Vector3(1, 1, 1);
            entry.transform.SetParent(this.gameObject.transform);
            entry.GetComponent<JournalEntryPrefab>().SpawnJournalEntryPrefab(journalEntryIndex[i]);
            journalEntry.Add(entry);
        }
    }

    public void ResetJournalEntry()
    {
        if (journalEntry.Count != 0)
        {
            for (int i = 0; i < journalEntry.Count; i++)
            {
                Destroy(journalEntry[i]);
                journalEntry.RemoveAt(i);
                ResetJournalEntry();
            }
        }
    }
}
