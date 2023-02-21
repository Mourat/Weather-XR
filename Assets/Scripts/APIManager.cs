using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class APIManager : MonoBehaviour
{
    private string _currentDate;
    private string _dateAfter4Days;
    private float _latitude;
    private float _longitude;
    private string _jsonResult;
    private WeatherData _weatherAPIResult;
    public bool hasData;
    private NumberFormatInfo _nfi = new NumberFormatInfo();

    private void Awake()
    {
        _currentDate = System.DateTime.Now.ToString("yyyy-MM-dd");
        _dateAfter4Days = System.DateTime.Now.AddDays(4).ToString("yyyy-MM-dd");
        _latitude = 43.70f;
        _longitude = 7.27f;
        hasData = false;
        _nfi.NumberDecimalSeparator = ".";
    }

    public void GetWeekWeather(float latitude, float longitude, string startDate, string endDate)
    {
        StartCoroutine(GetWeekData(latitude, longitude, startDate, endDate));
    }

    IEnumerator GetWeekData(float latitude, float longitude, string startDate, string endDate)
    {
        hasData = false;
        //Replace <API_URL> with the URL of the API you want to call
        using (UnityWebRequest www = UnityWebRequest.Get(
                   $"https://api.open-meteo.com/v1/meteofrance?latitude={latitude.ToString(_nfi)}&longitude={longitude.ToString(_nfi)}&daily=weathercode,temperature_2m_max,temperature_2m_min,sunrise,sunset&start_date={startDate}&end_date={endDate}&timezone=Europe%2FParis"))
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
                _weatherAPIResult = JsonConvert.DeserializeObject<WeatherData>(_jsonResult);
                hasData = true;
            }
        }
        // print(latitude);
        // print(longitude);
        print($"https://api.open-meteo.com/v1/meteofrance?latitude={latitude.ToString(_nfi)}&longitude={longitude.ToString(_nfi)}&daily=weathercode,temperature_2m_max,temperature_2m_min,sunrise,sunset&start_date={startDate}&end_date={endDate}&timezone=Europe%2FParis");

        yield break;
    }


    #region Remove this code

    private void Start()
    {
        GetWeekWeather(_latitude, _longitude, _currentDate, _dateAfter4Days);
    }

    private void Update()
    {
        if (hasData)
        {
            foreach (var theDate in _weatherAPIResult.daily.time)
            {
                print(theDate);
            }

            hasData = false;
        }
    }

    #endregion
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