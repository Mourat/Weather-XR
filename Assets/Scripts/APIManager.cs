using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Unity.VisualScripting;

// public class WeatherData
// {
//     public List<string> Date { get; set; }
//     public List<float> TemperatureMax { get; set; }
//     public List<float> TemperatureMin { get; set; }
//     public List<string> Sunrise { get; set; }
//     public List<string> Sunset { get; set; }
//     public List<string> WeatherCode { get; set; }
// }

public class APIManager : MonoBehaviour
{
    private string _currentDate;
    private string _dateAfter4Days;
    private float _latitude;
    private float _longitude;
    private string _jsonResult;
    public WeatherData WeatherAPIResult;

    // private string _date;
    // private string _weatherCode;
    // private string _temperatureMax;
    // private string _temperatureMin;
    // private string _sunrise;
    // private string _sunset;

    private void Awake()
    {
        _currentDate = System.DateTime.Now.ToString("yyyy-MM-dd");
        _dateAfter4Days = System.DateTime.Now.AddDays(4).ToString("yyyy-MM-dd");
        // _latitude = 43.70f;
        // _longitude = 7.27f;
        // print(currentDate);
        // print(dateAfter4Days);
    }

    public void GetWeekWeather()
    {
        StartCoroutine(GetWeekData());
        // while (true)
        // {
        //     if (WeatherAPIResult?.GetType() != null)
        //     {
                foreach (var theDate in WeatherAPIResult.daily.time)
                {
                    print(theDate);
                }
        //         break;
        //     }
        // }
        
    }

    private void Start()
    {
        GetWeekWeather();
    }

    IEnumerator GetWeekData()
    {
        //Replace <API_URL> with the URL of the API you want to call
        using (UnityWebRequest www = UnityWebRequest.Get(
                   $"https://api.open-meteo.com/v1/meteofrance?latitude={_latitude}&longitude={_longitude}&daily=weathercode,temperature_2m_max,temperature_2m_min,sunrise,sunset&start_date={_currentDate}&end_date={_dateAfter4Days}&timezone=Europe%2FParis"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                print(www.error);
            }
            else
            {
                // Get the response data as a string
                _jsonResult = www.downloadHandler.text;
                // Do something with the response data
                WeatherAPIResult = JsonConvert.DeserializeObject<WeatherData>(_jsonResult);
                foreach (var theDate in WeatherAPIResult.daily.time)
                {
                    print(theDate);
                }
            }
        }
    }
}

public class WeatherData
{
    public Daily daily { get; set; }
}

public class Daily
{
    public string[] time { get; set; }
    public int[] weathercode { get; set; }
    public float[] temperature_2m_max { get; set; }
    public float[] temperature_2m_min { get; set; }
    public string[] sunrise { get; set; }
    public string[] sunset { get; set; }
}



