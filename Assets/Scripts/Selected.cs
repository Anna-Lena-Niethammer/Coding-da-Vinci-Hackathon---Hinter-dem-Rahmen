using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Selected : MonoBehaviour
{
    
    public Data _data;
    
    private GameObject _selectedPortrait;

    public GameObject bust;

    public TextMeshProUGUI _portraitTitle;

    private TextMeshProUGUI _personText;
    private TextMeshProUGUI _artistText;
    private TextMeshProUGUI _paintingText;

    private void OnEnable()
    {
        InitializeGameObjectReferences();
        SetActivePortrait();
        SetActiveBust();
    }

    private void SetActiveBust()
    {
        foreach (Transform child in bust.transform) {
            Destroy(child.gameObject);
        }
        
        var material = Resources.Load<GameObject>(_data.GetEntryIdValue(_data.selectedEntry));
        GameObject newBust = Instantiate(material, bust.transform, false);
        
        newBust.transform.localEulerAngles = new Vector3(270, 0, 180);
        newBust.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        newBust.transform.localPosition = new Vector3(-0.03f, -0.07f, 0.15f);
    }

    private void InitializeGameObjectReferences()
    {
        if (_selectedPortrait == null)
        {
            _selectedPortrait = transform.Find("Portrait").gameObject;
        }

        if (_personText == null)
        {
           
            _personText = transform.Find("Infostand").transform.Find("Person").transform.Find("Data").gameObject
                .GetComponent<TextMeshProUGUI>();
        }
        
        if (_artistText == null)
        {
            _artistText = transform.Find("Infostand").transform.Find("Artist").transform.Find("Data").gameObject
                .GetComponent<TextMeshProUGUI>();
        }
        
        if (_paintingText == null)
        {
            _paintingText = transform.Find("Infostand").transform.Find("Painting").transform.Find("Data").gameObject
                .GetComponent<TextMeshProUGUI>();
        }
    }

    private void SetActivePortrait()
    {
        var material = Resources.Load<Texture>(_data.GetEntryIdValue(_data.selectedEntry));
        _selectedPortrait.GetComponent<MeshRenderer>().material.mainTexture = material;
        _portraitTitle.text = _data.GetSelectedTitle();
        
        Entry entry = _data.GetEntry(_data.selectedEntry);

        _personText.text = $"{entry.person.name}\n \n Wohnort \n{entry.person.street}\n \n" +
                           $"{entry.person.yearOfBirth} - {entry.person.yearOfDeath} \n " +
                           $"{entry.person.placeOfBirth}   {entry.person.placeOfDeath}";

        _artistText.text = $"{entry.artist.name}\n \n {entry.artist.yearOfBirth} - {entry.artist.yearOfDeath} \n{entry.artist.placeOfDeath}";

        _paintingText.text = $"Entstehungsjahr \n{entry.painting.year} \n \n{entry.painting.technique}";
    }
}
