using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class WeatherCode
{
    public int codeId { get; set; }

    public string nameEng { get; set; }

    public string nameFr { get; set; }

    public string iconName { get; set; }

    public override string ToString()
    {
        return "ID: " + codeId + "   Name Eng: " + nameEng;
    }

}


public class DisplayWeather : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI tempMin, tempMax, weatherCode, date, rain, sun;
    [SerializeField] Sprite[] icons;
    [SerializeField] Image weatherIcon;

    private List<WeatherCode> codesList;

    private void Awake()
    {
        buidWeatherCodesList();
    }

    public void setTempMin(string text)
    {
        tempMin.text = text;
    }

    public void setTempMax(string text)
    {
        tempMax.text = text;
    }


    public string getIconNameByCode(int code)
    {
        string result = null;

        result = codesList[code].iconName;

        return result ;
    }


    public void setWeatherCode(int code)
    {
 
        Debug.Log("WeatherCode : " + code );
        Debug.Log("Weather object :" + codesList[code].ToString());

        Sprite newSprite = null;

        string spriteName = codesList[code].iconName;

        for (int i=0; i < icons.Length; i++)
        {
            if (icons[i].name == spriteName)
            {
                newSprite = icons[i];
            }
        }

        if (newSprite != null) {
            weatherIcon.sprite = newSprite;
        }

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


    private List<WeatherCode> buidWeatherCodesList()
    {

        // Pfiu c'est du taf !

        codesList = new List<WeatherCode>();

        // Add parts to the list.
        codesList.Add(new WeatherCode() {  codeId = 0, nameEng = "Partly cloudy", nameFr = "", iconName = "Sun"});
        codesList.Add(new WeatherCode() { codeId = 1, nameEng = "Fog", nameFr = "", iconName = "Cloud" });
        codesList.Add(new WeatherCode() { codeId = 2, nameEng = "Fog", nameFr = "", iconName = "Fog" });
        codesList.Add(new WeatherCode() { codeId = 3, nameEng = "Light rain", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 4, nameEng = "Moderate rain", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 5, nameEng = "Heavy rain", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 6, nameEng = "Rain showers", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 7, nameEng = "Light snow", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 8, nameEng = "Moderate snow", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 9, nameEng = "Heavy snow", nameFr = "", iconName = "Snow" });

        codesList.Add(new WeatherCode() { codeId = 10, nameEng = "Snow showers", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 11, nameEng = "Sleet", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 12, nameEng = "Freezing rain", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 13, nameEng = "Hail", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 14, nameEng = "Thunderstorm", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 15, nameEng = "Mist", nameFr = "", iconName = "Fog" });
        codesList.Add(new WeatherCode() { codeId = 16, nameEng = "Haze", nameFr = "", iconName = "Fog" });
        codesList.Add(new WeatherCode() { codeId = 17, nameEng = "Smoke", nameFr = "", iconName = "Fog" });
        codesList.Add(new WeatherCode() { codeId = 18, nameEng = "Sand/dust", nameFr = "", iconName = "Fog" });
        codesList.Add(new WeatherCode() { codeId = 19, nameEng = "Windy", nameFr = "", iconName = "Default" });

        codesList.Add(new WeatherCode() { codeId = 20, nameEng = "Tornado", nameFr = "", iconName = "Default" });
        codesList.Add(new WeatherCode() { codeId = 21, nameEng = "Hurricane/typhoon", nameFr = "", iconName = "Default" });
        codesList.Add(new WeatherCode() { codeId = 22, nameEng = "Cold", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 23, nameEng = "Hot", nameFr = "", iconName = "Sun" });
        codesList.Add(new WeatherCode() { codeId = 24, nameEng = "Cloudy", nameFr = "", iconName = "Cloud" });
        codesList.Add(new WeatherCode() { codeId = 25, nameEng = "Overcast", nameFr = "", iconName = "Cloud" });
        codesList.Add(new WeatherCode() { codeId = 26, nameEng = "Drizzle", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 27, nameEng = "Freezing drizzle", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 28, nameEng = "Ice pellets", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 29, nameEng = "Light freezing rain", nameFr = "", iconName = "Snow" });

        codesList.Add(new WeatherCode() { codeId = 30, nameEng = "Heavy freezing rain", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 31, nameEng = "Light sleet", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 32, nameEng = "Moderate sleet", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 33, nameEng = "Heavy sleet", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 34, nameEng = "Light snow grains", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 35, nameEng = "Moderate snow grains", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 36, nameEng = "Heavy snow grains", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 37, nameEng = "Light snow pellets", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 38, nameEng = "Moderate snow pellets", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 39, nameEng = "Heavy snow pellets", nameFr = "", iconName = "Snow" });

        codesList.Add(new WeatherCode() { codeId = 40, nameEng = "Light ice pellets", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 41, nameEng = "Moderate ice pellets", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 42, nameEng = "Heavy ice pellets", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 43, nameEng = "Light hail", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 44, nameEng = "Moderate hail", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 45, nameEng = "Heavy hail", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 46, nameEng = "Blowing snow", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 47, nameEng = "Blizzard", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 48, nameEng = "Drifting snow", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 49, nameEng = "Low drifting snow", nameFr = "", iconName = "Snow" });

        codesList.Add(new WeatherCode() { codeId = 50, nameEng = "Heavy snow showers", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 51, nameEng = "Moderate rain", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 52, nameEng = "Heavy rain showers", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 53, nameEng = "Heavy rain", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 54, nameEng = "Light freezing rain showers", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 55, nameEng = "Moderate or heavy freezing rain showers", nameFr = "", iconName = "Rain" });
        codesList.Add(new WeatherCode() { codeId = 56, nameEng = "Heavy snow showers", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 57, nameEng = "Light rain and snow", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 58, nameEng = "Moderate or heavy rain and snow", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 59, nameEng = "Light sleet showers", nameFr = "", iconName = "Snow" });

        codesList.Add(new WeatherCode() { codeId = 60, nameEng = "Moderate or heavy sleet showers", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 61, nameEng = "Light snow shower", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 62, nameEng = "Moderate or heavy snow shower", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 63, nameEng = "Light rain and snow shower", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 64, nameEng = "Moderate or heavy rain and snow shower", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 65, nameEng = "Light sleet", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 66, nameEng = "Moderate sleet", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 67, nameEng = "Heavy sleet", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 68, nameEng = "Light snow", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 69, nameEng = "Moderate snow", nameFr = "", iconName = "Snow" });

        codesList.Add(new WeatherCode() { codeId = 70, nameEng = "Heavy snow", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 71, nameEng = "Thunderstorm with light rain", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 72, nameEng = "Thunderstorm with moderate rain", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 73, nameEng = "Thunderstorm with heavy rain", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 74, nameEng = "Thunderstorm with light freezing rain", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 75, nameEng = "Thunderstorm with moderate or heavy freezing rain", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 76, nameEng = "Thunderstorm with light sleet", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 77, nameEng = "Thunderstorm with moderate or heavy sleet", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 78, nameEng = "Thunderstorm with light snow", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 79, nameEng = "Thunderstorm with moderate or heavy snow", nameFr = "", iconName = "Thunder" });
        
        codesList.Add(new WeatherCode() { codeId = 80, nameEng = "Thunderstorm with light rain shower", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 81, nameEng = "Thunderstorm rain shower moderate", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 82, nameEng = "Thunderstorm rain shower violent", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 83, nameEng = "Thunder", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 84, nameEng = "Thunder", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 85, nameEng = "Snow showers slight", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 86, nameEng = "Snow showers slight and heavy", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 87, nameEng = "Snow showers slight and heavy", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 88, nameEng = "Snow showers slight and heavy", nameFr = "", iconName = "Snow" });
        codesList.Add(new WeatherCode() { codeId = 89, nameEng = "Snow showers slight and heavy", nameFr = "", iconName = "Snow" });

        codesList.Add(new WeatherCode() { codeId = 90, nameEng = "Thunderstorm: Slight or moderate", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 91, nameEng = "Thunderstorm: Slight or moderate", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 92, nameEng = "Thunderstorm: Slight or moderate", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 93, nameEng = "Thunderstorm: Slight or moderate", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 94, nameEng = "Thunderstorm: Slight or moderate", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 95, nameEng = "Thunderstorm: Slight or moderate", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 96, nameEng = "Thunderstorm with slight and heavy hail", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 97, nameEng = "Thunderstorm with slight and heavy hail", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 98, nameEng = "Thunderstorm with slight and heavy hail", nameFr = "", iconName = "Thunder" });
        codesList.Add(new WeatherCode() { codeId = 99, nameEng = "Thunderstorm with slight and heavy hail", nameFr = "", iconName = "Thunder" });


        return codesList;
    }


    //=========================
    //    TESTS
    //=========================

    /*
    public string minTemp;

    private void Start()
    {
        this.setTempMin(minTemp + "°C");

        setWeatherCode(52);
    }
    */




    /*
     * 
     * 
     * 
   
    Code 0: Clear/Sunny

Code 1: Partly cloudy
Code 2: Fog
Code 3: Light rain
Code 4: Moderate rain
Code 5: Heavy rain
Code 6: Rain showers


Code 7: Light snow
Code 8: Moderate snow
Code 9: Heavy snow
Code 10: Snow showers
Code 11: Sleet
Code 12: Freezing rain
Code 13: Hail
Code 14: Thunderstorm
Code 15: Mist
Code 16: Haze
Code 17: Smoke
Code 18: Sand/dust
Code 19: Windy
Code 20: Tornado
Code 21: Hurricane/typhoon
Code 22: Cold
Code 23: Hot
Code 24: Cloudy
Code 25: Overcast
Code 26: Drizzle
Code 27: Freezing drizzle
Code 28: Ice pellets
Code 29: Light freezing rain
Code 30: Heavy freezing rain
Code 31: Light sleet
Code 32: Moderate sleet
Code 33: Heavy sleet
Code 34: Light snow grains
Code 35: Moderate snow grains
Code 36: Heavy snow grains
Code 37: Light snow pellets
Code 38: Moderate snow pellets
Code 39: Heavy snow pellets
Code 40: Light ice pellets
Code 41: Moderate ice pellets
Code 42: Heavy ice pellets
Code 43: Light hail
Code 44: Moderate hail
Code 45: Heavy hail
Code 46: Blowing snow
Code 47: Blizzard
Code 48: Drifting snow
Code 49: Low drifting snow
Code 50: Heavy snow showers
Code 51: Moderate rain
Code 52: Heavy rain showers
Code 53: Heavy rain
Code 54: Light freezing rain showers
Code 55: Moderate or heavy freezing rain showers
Code 56: Heavy snow showers
Code 57: Light rain and snow
Code 58: Moderate or heavy rain and snow
Code 59: Light sleet showers
Code 60: Moderate or heavy sleet showers
Code 61: Light snow shower
Code 62: Moderate or heavy snow shower
Code 63: Light rain and snow shower
Code 64: Moderate or heavy rain and snow shower
Code 65: Light sleet
Code 66: Moderate sleet
Code 67: Heavy sleet
Code 68: Light snow
Code 69: Moderate snow
Code 70: Heavy snow


Code 71: Thunderstorm with light rain
Code 72: Thunderstorm with moderate rain
Code 73: Thunderstorm with heavy rain
Code 74: Thunderstorm with light freezing rain
Code 75: Thunderstorm with moderate or heavy freezing rain
Code 76: Thunderstorm with light sleet
Code 77: Thunderstorm with moderate or heavy sleet
Code 78: Thunderstorm with light snow
Code 79: Thunderstorm with moderate or heavy snow
Code 80: Thunderstorm with light rain shower
Code 81: Thunder


     * 0    Clear sky
1, 2, 3    Mainly clear, partly cloudy, and overcast
45, 48    Fog and depositing rime fog
51, 53, 55    Drizzle: Light, moderate, and dense intensity
56, 57    Freezing Drizzle: Light and dense intensity
61, 63, 65    Rain: Slight, moderate and heavy intensity
66, 67    Freezing Rain: Light and heavy intensity
71, 73, 75    Snow fall: Slight, moderate, and heavy intensity
77    Snow grains
80, 81, 82    Rain showers: Slight, moderate, and violent
85, 86    Snow showers slight and heavy
95 *    Thunderstorm: Slight or moderate
96, 99 *    Thunderstorm with slight and heavy hail
    */

    /*

    ----- SUN ----
    Code 0 : Clair/Ensoleillé


    ---- Rain -----


Code 3 : Pluie légère
Code 4 : Pluie modérée
Code 5 : Fortes pluies
Code 6 : Averses de pluie
 Code 26 : Bruine
 Code 27 : Bruine verglaçante
Code 51 : Pluie modérée
Code 52 : Fortes averses
Code 53 : Fortes pluies
Code 54 : Légères averses de pluie verglaçante
Code 55 : Averses de pluie verglaçante modérées ou fortes

    ----------- Divers --------

Code 2 : Brouillard
Code 15 : Brume
Code 16 : Brume
Code 17 : Fumée
Code 18 : Sable/poussière
Code 22 : Froid
Code 23 : Chaud
    

    ------ Flocon -------

Code 7 : Légère neige
Code 8 : Neige modérée
Code 9 : Neige abondante
Code 10 : Averses de neige
Code 11 : grésil
Code 12 : Pluie verglaçante
Code 13 : Grêle
Code 28 : Granules de glace
Code 29 : Légère pluie verglaçante
Code 30 : Forte pluie verglaçante
Code 31 : Léger grésil
Code 32 : grésil modéré
Code 33 : grésil lourd
Code 34 : Grains de neige légers
Code 35 : grains de neige modérés
Code 36 : Gros grains de neige
Code 37 : Neige roulée légère
Code 38 : Neige roulée modérée
Code 39 : Neige roulée lourde
Code 40 : grésil léger
Code 41 : grésil modéré
Code 42 : Granules de glace lourds
Code 43 : Légère grêle
Code 44 : Grêle modérée
Code 45 : Forte grêle
    Code 47 : Blizzard
Code 48 : Chute de neige
Code 49 : Faible poudrerie
    Code 46 : Poudrerie
Code 50 : fortes averses de neige

Code 56 : fortes averses de neige
Code 57 : Pluie légère et neige
Code 58 : Pluie et neige modérées ou fortes
Code 59 : Légères averses de grésil
Code 60 : Averses de grésil modérées ou fortes
Code 61 : Légère averse de neige
Code 62 : Averse de neige modérée ou abondante
Code 63 : Pluie légère et averse de neige
Code 64 : Pluie modérée ou forte et averse de neige
Code 65 : grésil léger
Code 66 : grésil modéré
Code 67 : grésil lourd
Code 68 : Légère neige
Code 69 : Neige modérée
Code 70 : Neige abondante


    ------  Orage ---------
Code 14 : Orage
    Code 71 : Orage avec pluie légère
Code 72 : Orage avec pluie modérée
Code 73 : Orage avec fortes pluies
Code 74 : Orage avec faible pluie verglaçante
Code 75 : Orage avec pluie verglaçante modérée ou forte
Code 76 : Orage avec grésil léger
Code 77 : Orage avec grésil modéré ou fort
Code 78 : Orage avec faible neige
Code 79 : Orage avec neige modérée ou abondante
Code 80 : Orage avec pluie légère
Code 81 : Tonnerre


  ----  vent ----

Code 19 : venteux
Code 20 : Tornade
Code 21 : ouragan/typhon

    ------- nuageux ----
Code 1 : Partiellement nuageux
Code 24 : Nuageux
Code 25 : Couvert










    */

}
