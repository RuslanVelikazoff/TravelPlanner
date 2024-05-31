using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public enum NotesCategory
    {
        Null,
        Shopping,
        Travel,
        Education
    }

    public enum ShoppingCategory
    {
        Null,
        Clothes,
        Cosmetics,
        Groceries,
        Electronics
    }

    public enum PhotoCategory
    {
        Null,
        Winter,
        Spring,
        Summer,
        Autumn
    }

    //Notes
    public List<string> textNotes;
    public List<NotesCategory> categoryNotes;
    
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
    
    //Shopping
    public List<ShoppingCategory> categoryShopping;
    public List<string> purchaseName;
    public List<bool> completedPurchase;
    
    //PhotoAlbum
    public List<Texture2D> winterPhotos;
    public List<Texture2D> springPhotos;
    public List<Texture2D> summerPhotos;
    public List<Texture2D> autumnPhotos;

    public GameData()
    {
        textNotes = new List<string>();
        categoryNotes = new List<NotesCategory>();

        city = new List<string>();
        places = new List<string>();
        budget = new List<int>();
        date = new List<DateTime>();
        dateString = new List<string>();

        journalEntry = new List<string>();

        reminderTexts = new List<string>();
        reminderDates = new List<DateTime>();
        reminderDatesString = new List<string>();

        categoryShopping = new List<ShoppingCategory>();
        purchaseName = new List<string>();
        completedPurchase = new List<bool>();

        winterPhotos = new List<Texture2D>();
        springPhotos = new List<Texture2D>();
        summerPhotos = new List<Texture2D>();
        autumnPhotos = new List<Texture2D>();
    }
}
