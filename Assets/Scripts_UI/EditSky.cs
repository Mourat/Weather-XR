using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditSky : MonoBehaviour
{

    public Material rainny;
    public Material sunny;
    public Material cloudy;
    public Material storm;
    public Material snow;

    public DisplayWeather displayWeather;

    public APIManager apiManager;

    /*

    private void Update()
    {
        Debug.Log("EditSky > Update > apiManager.hasWeatherData :" + apiManager.hasWeatherData);

        if (apiManager.hasWeatherData) {

            int weatherCode = apiManager.weatherAPIResult.daily.weathercode[0];

            if (weatherCode >= 0)
            {
                setSkyByWeatherCode(weatherCode);
            }
        }
    }

    */


    // Update SkyBox material
    private void updateSky(Material mat)
    {
        RenderSettings.skybox = mat;
    }


    // Update SkyBox image by weather code.
    public void setSkyByWeatherCode(int code)
    {

        Debug.Log("Method setSkyByWeatherCode, code: " + code);

        string iconName = displayWeather.getIconNameByCode(code);

        Debug.Log("Method setSkyByWeatherCode, iconName: " + iconName);

        switch (iconName)
        {
            case "Sun":
                updateSky(sunny);
                break;

            case "Rain":
                updateSky(rainny);
                break;

            case "Cloud":
                updateSky(cloudy);
                break;

            case "Thunder":
                updateSky(storm);
                break;

            case "Snow":
                updateSky(snow);
                break;

            default:
                updateSky(sunny);
                break;
        }

    }

    /*
     *    TESTS
     * */

    /*

    private void Start()
    {
        setSkyByWeatherCode(45);
    }

    */

}
