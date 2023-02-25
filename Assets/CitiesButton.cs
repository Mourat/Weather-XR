using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitiesButton : MonoBehaviour
{

    public City city = null;
    [SerializeField] APIManager apiManager;

    public void buttonClick()
    {
        
        if (city != null)
        {
           // Debug.Log("CitiesButton > city.latitude : " + city.latitude);

            apiManager.GetWeekWeather(city.latitude, city.longitude);
        }
    }

}
