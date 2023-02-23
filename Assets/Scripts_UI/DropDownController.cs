using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownController : MonoBehaviour
{
    public APIManager apiManager;
    private CitiesData _citiesAPIResult;
    private TMP_Dropdown _dropdown;
    private List<string> _cityNames;

    private void Update()
    {
        
    }
}
