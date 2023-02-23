using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayWeather : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI tempMin, tempMax, weatherCode, date, rain, sun;


    [SerializeField]   Image [] icons;

    public void setTempMin(string text)
    {
        tempMin.text = text;
    }

    public void setTempMax(string text)
    {
        tempMax.text = text;
    }

    public void setWeatherCode(string text)
    {
        weatherCode.text = text;
    }

    public void setDate(string text)
    {
        date.text = text;
    }

    public void setRainPercent(string text)
    {
        rain.text = text;
    }

    public void setUV(string text)
    {
        sun.text = text;
    }

    //=========================
    //    TESTS
    //=========================

    public string minTemp;

    private void Start()
    {
        this.setTempMin(minTemp + "°C");
    }

}
