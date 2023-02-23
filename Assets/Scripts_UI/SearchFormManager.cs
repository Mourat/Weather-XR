using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchFormManager : MonoBehaviour
{



    public TMP_InputField cityName;
    public APIManager apiManager;

    private CitiesData citiesAPIResult;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (apiManager.hasCitiesData)
        {
            Debug.Log("Nom de la ville : " + apiManager.citiesAPIResult.results[0].name);
        }
    }

    public void findCity()
    {
        //Debug.Log("--------- Find City : " + cityName.text);

        apiManager.GetCities(cityName.text);
        //apiManager.GetCities("nic");

        apiManager.hasCitiesData = false;
        //apiManager.citiesAPIResult
    }
}
