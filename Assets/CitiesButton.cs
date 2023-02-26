using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitiesButton : MonoBehaviour
{

    public City city = null;
    [SerializeField] APIManager apiManager;
    [SerializeField] DisplayInformations displayInformations;

    public void buttonClick()
    {
        
        if (city != null)
        {
            // Debug.Log("CitiesButton > city.latitude : " + city.latitude);

            // Display city informations
            displayInformations.FillInfos(city);

            // Load weather informations
            apiManager.GetWeekWeather(city.latitude, city.longitude);
        }
    }

}
