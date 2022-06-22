using System;
using UnityEngine;

public class Data : MonoBehaviour
{

    private Entry[] entries;

    public int selectedEntry;
    // Start is called before the first frame update
    
    
    void Start()
    {
        var jsonString = Resources.Load<TextAsset>("archive").ToString();
        jsonString = fixJson(jsonString);
        entries = JsonHelper.FromJson<Entry>(jsonString);
    }

    public Entry[] GetEntries()
    {
        return entries;
    }

    public int GetEntriesSize()
    {
        return entries.Length;
    }

    public Entry GetEntry(int id)
    {
        return entries[id];
    }

    public string GetEntryIdValue(int id)
    {
        return entries[id].id;
    }
    
    private string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    public string GetSelectedTitle()
    {
        return entries[selectedEntry].title;
    }
}


[Serializable]
public class Artist
{
    public string name ;
    public int yearOfBirth ;
    public int yearOfDeath ;
    public string placeOfDeath ;

    public Artist(string name, int yearOfBirth, int yearOfDeath, string placeOfDeath)
    {
        this.name = name;
        this.yearOfBirth = yearOfBirth;
        this.yearOfDeath = yearOfDeath;
        this.placeOfDeath = placeOfDeath;
    }
}

[Serializable]
public class Person
{
    public string name ;
    public int yearOfBirth ;
    public int yearOfDeath ;
    public string placeOfBirth ;
    public string placeOfDeath ;
    public string placeOfLiving ;
    public string street ;

    public Person (string name, int yearOfBirth, int yearOfDeath, string placeOfBirth, 
        string placeOfDeath, string placeOfLiving, string street)
    {
        this.name = name;
        this.yearOfBirth = yearOfBirth;
        this.yearOfDeath = yearOfDeath;
        this.placeOfBirth = placeOfBirth;
        this.placeOfDeath = placeOfDeath;
        this.placeOfLiving = placeOfLiving;
        this.street = street;
    }
}

[Serializable]
public class Painting
{
    public string year ;
    public string technique ;
    public string dimension ;

    public Painting(string year, string technique, string dimension)
    {
        this.year = year;
        this.technique = technique;
        this.dimension = dimension;
    }
}

[Serializable]
public class Entry
{
    public string id ;
    public string title ;
    public Artist artist ;
    public Painting painting ;
    public Person person ;
    public bool hasVR ;

    public Entry( string id, string title, Artist artist, Painting painting, Person person, bool hasVR)
    {
        this.id = id;
        this.title = title;
        this.artist = artist;
        this.painting = painting;
        this.person = person;
        this.hasVR = hasVR;
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }
    
    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}