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

    private void updateSky(Material mat)
    {
        RenderSettings.skybox = mat;
    }


    public void setSkyByWeatherCode(int code)
    {
       string iconName = displayWeather.getIconNameByCode(code);

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
