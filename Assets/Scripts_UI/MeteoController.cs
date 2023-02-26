using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoController : MonoBehaviour
{

    [SerializeField] APIManager apiManager;
    [SerializeField] DisplayWeather[] weekInfos;  // fields
    [SerializeField] EditSky editSky;

    [SerializeField] GameObject citiesForm;
    [SerializeField] GameObject citiesInfos;

    WeatherData weatherData = null;


    private void Update()
    {

        //When week loaded display 5 days
        if (apiManager.hasWeatherData)
        {
            // Hide cities form
            citiesForm.transform.localScale = new Vector3(0, 0, 0);

            // Display curent city
            citiesInfos.transform.localScale = new Vector3(1, 1, 1);

            Debug.Log("MeteoController > Update >  hasWeatherData : true ");
            weatherData = apiManager.weatherAPIResult;
            FillDays(weatherData);
        }
    }



    public void FillDays(WeatherData data)
    {
        for (int i= 0; i < weekInfos.Length; i++ )
        {
            int weatherCode = data.daily.weathercode[i];
            weekInfos[i].setWeatherCode(weatherCode);

            if (i == 0)
            {
                editSky.setSkyByWeatherCode(weatherCode);
            }

            float tempMin = data.daily.temperature_2m_min[i];
            weekInfos[i].setTempMin(tempMin +"°C");

            float tempMax = data.daily.temperature_2m_max[i];
            weekInfos[i].setTempMax(tempMin + "°C");

            string sunset = data.daily.sunset[i];
            string[] tabSunset = sunset.Split("T");
           // Debug.Log("tabSunset : " + tabSunset[1]);
            weekInfos[i].setSunset(tabSunset[1]);

            string sunrise = data.daily.sunrise[i];
            string[] tabSunrise = sunrise.Split("T");
            weekInfos[i].setSunrise(tabSunrise[1]);

            string time = data.daily.time[i];

            if (i == 0)
            {
                time = "Aujourd'hui";
            }

            weekInfos[i].setDate(time);

        }

        // Prevent loop display
        apiManager.hasWeatherData = false;

    }

    /*
     *  ===========  Format ==================
     * 
    "daily":{
    "time":["2023-02-25","2023-02-26","2023-02-27","2023-02-28","2023-03-01"],
    "weathercode":[3,51,53,53,3],
    "temperature_2m_max":[15.6,15.1,9.5,13.8,12.3],
    "temperature_2m_min":[10.5,7.9,7.5,7.4,10.1],
    "sunrise":["2023-02-25T07:12","2023-02-26T07:11","2023-02-27T07:09","2023-02-28T07:07","2023-03-01T07:06"],
    "sunset":["2023-02-25T18:15","2023-02-26T18:16","2023-02-27T18:17","2023-02-28T18:19","2023-03-01T18:20"]}}
     *
     **/
}
