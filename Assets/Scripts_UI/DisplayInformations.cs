using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInformations : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI city, country, timeZone, population, latitude, longitude, elevation;


    public void FillInfos(City city)
    {
        setCity(city.name);
        setCountry(city.country);
        setLatitude(city.latitude + "");
        setLongitude(city.longitude + "");
        setElevation(city.elevation + "");
        setPopulation(city.population + "");
        setTimeZone(city.timezone);
    }

    public void setCity(string text)
    {
        city.text = text;
    }

    public void setCountry(string text)
    {
        country.text = text;
    }

    public void setTimeZone(string text)
    {
        timeZone.text = text;
    }

    public void setPopulation(string text)
    {
        population.text = text;
    }

    public void setLatitude(string text)
    {
        latitude.text = text;
    }

    public void setLongitude(string text)
    {
        longitude.text = text;
    }

    public void setElevation(string text)
    {
        elevation.text = text;
    }

    //TEST

    /*
    public string cityTest;

    private void Start()
    {
        this.setCity(cityTest);
    }
    */

}
