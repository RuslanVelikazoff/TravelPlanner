using System;
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
    
    //Travel
    public List<string> city;
    public List<string> places;
    public List<int> budget;
    public List<DateTime> date;
    public List<string> dateString;
    
    //Journal
    public List<string> journalEntry;
    
    //Reminders
    public List<string> reminderTexts;
    public List<DateTime> reminderDates;
    public List<string> reminderDatesString;

    public GameData()
    {
        textNotes = new List<string>();
        categoryNotes = new List<Category>();

        city = new List<string>();
        places = new List<string>();
        budget = new List<int>();
        date = new List<DateTime>();
        dateString = new List<string>();

        journalEntry = new List<string>();

        reminderTexts = new List<string>();
        reminderDates = new List<DateTime>();
        reminderDatesString = new List<string>();
    }
}
