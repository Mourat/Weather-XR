using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchFormManager : MonoBehaviour
{



    public TMP_InputField cityName;
    public APIManager apiManager;
    private CitiesData _citiesAPIResult;
    private TMP_Dropdown _dropdown;
    private List<string> _cityNames;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (apiManager.hasCitiesData)
        // {
        //     Debug.Log("Nom de la ville : " + apiManager.citiesAPIResult.results[0].name);
        // }
    }

    public void FindCity()
    {
        apiManager.GetCities(cityName.text);
        
        // if (apiManager.hasCitiesData)
        // {
        //     foreach (var city in _citiesAPIResult.results)
        //     {
        //         print(city);
        //     }
        //     apiManager.hasCitiesData = false;
        // }
        
        if (apiManager.hasCitiesData)
        {
            // print(_citiesAPIResult.results[0].name);
            foreach (City city in _citiesAPIResult.results)
            {
                _cityNames.Add(String.Format($"{city.name}/{city.country}"));
            }
            _dropdown.ClearOptions();
            _dropdown.AddOptions(_cityNames);
        }

        apiManager.hasCitiesData = false;
    }
}
