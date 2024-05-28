using System.Collections.Generic;
using UnityEngine;

public class NotesScrollView : MonoBehaviour
{
    [SerializeField] private GameObject notesPrefab;

    [SerializeField] private Canvas canvas;

    private List<GameObject> notes = new List<GameObject>();
    private List<int> notesIndex;

    public void SpawnPrefabs(GameData.Category category)
    {
        notesIndex = NotesData.Instance.GetCategoryListIndex(category);

        for (int i = 0; i < notesIndex.Count; i++)
        {
            var note = Instantiate(notesPrefab, transform.position, Quaternion.identity);
            note.transform.SetParent(canvas.transform);
            note.transform.localScale = new Vector3(1, 1, 1);
            note.transform.SetParent(this.gameObject.transform);
            note.GetComponent<NotesPrefab>().SpawnNotesPrefab(notesIndex[i]);
            notes.Add(note);
        }
    }
    
    public void ResetNotes()
    {
        if (notes.Count != 0)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                Destroy(notes[i]);
                notes.RemoveAt(i);
                ResetNotes();
            }
        }
    }
}
