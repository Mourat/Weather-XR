using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class APIManager : MonoBehaviour
{
    private string _startDate;
    private string _endDate;
    // private float _latitude;
    // private float _longitude;
    private string _jsonResult;
    public WeatherData weatherAPIResult;
    public CitiesData citiesAPIResult;
    public bool hasWeatherData;
    public bool hasCitiesData;
    private NumberFormatInfo _nfi = new NumberFormatInfo();

    private void Awake()
    {
        _startDate = System.DateTime.Now.ToString("yyyy-MM-dd");
        _endDate = System.DateTime.Now.AddDays(4).ToString("yyyy-MM-dd");
        // _latitude = 43.70f;
        // _longitude = 7.27f;
        hasWeatherData = false;
        hasCitiesData = false;
        _nfi.NumberDecimalSeparator = ".";
    }

    public void GetWeekWeather(float latitude, float longitude)
    {
        StartCoroutine(GetWeekData(latitude, longitude, _startDate, _endDate));
    }
    
    public void GetCities(string queryName)
    {
        StartCoroutine(GetCitiesData(queryName));
    }

    IEnumerator GetWeekData(float latitude, float longitude, string startDate, string endDate)
    {
        hasWeatherData = false;
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
                weatherAPIResult = JsonConvert.DeserializeObject<WeatherData>(_jsonResult);
                hasWeatherData = true;
            }
        }
    }
    
    IEnumerator GetCitiesData(string queryName)
    {
        hasCitiesData = false;
        using (UnityWebRequest www = UnityWebRequest.Get(
                   $"https://geocoding-api.open-meteo.com/v1/search?count=5&name={queryName}"))
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
                citiesAPIResult = JsonConvert.DeserializeObject<CitiesData>(_jsonResult);
                hasCitiesData = true;
            }
        }
    }


    #region Remove this code
    // private void Start()
    // {
    //     GetWeekWeather(_latitude, _longitude);
    // }
    //
    // private void Update()
    // {
    //     if (hasWeatherData)
    //     {
    //         foreach (var theDate in _weatherAPIResult.daily.time)
    //         {
    //             print(theDate);
    //         }
    //
    //         hasWeatherData = false;
    //     }
    // }
    
    // private void Start()
    // {
    //     GetCities("nice");
    // }
    //
    // private void Update()
    // {
    //     if (hasCitiesData)
    //     {
    //         foreach (var city in citiesAPIResult.results)
    //         {
    //             print($"{city.name} / {city.country}");
    //         }
    //
    //         hasCitiesData = false;
    //     }
    // }
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

public class CitiesData
{
    public City[] results { get; set; }
}

public class City
{
    public string name { get; set; }
    public float latitude { get; set; }
    public float longitude { get; set; }
    public string country { get; set; }
}

