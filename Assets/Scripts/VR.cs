using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VR : MonoBehaviour
{
    
    public Data _data;
    
    private GameObject _selectedPortrait;

    private void OnEnable()
    {
        InitializeGameObjectReferences();
        SetActivePortrait();
    }

    private void InitializeGameObjectReferences()
    {
        if (_selectedPortrait == null)
        {
            _selectedPortrait = transform.Find("Portrait").gameObject;
        }
    }

    private void SetActivePortrait()
    {
        var material = Resources.Load<Texture>(_data.GetEntryIdValue(_data.selectedEntry));
        _selectedPortrait.GetComponent<MeshRenderer>().material.mainTexture = material;
    }
}