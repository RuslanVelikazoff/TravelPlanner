using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public enum Category
    {
        Null,
        Shopping,
        Travel,
        Education
    }
    
    //Notes
    public List<string> textNotes;
    public List<Category> categoryNotes;

    public GameData()
    {
        textNotes = new List<string>();
        categoryNotes = new List<Category>();
    }
}
