using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditSky : MonoBehaviour
{

    public Material rainny;
    public Material sunny;
    public Material cloody;
    public Material storm;
    public Material snow;

   

    private void updateSky(Material mat)
    {
        RenderSettings.skybox = mat;
    }

    public void setSkyRain()
    {
        updateSky(rainny);
    }

    public void setSkySunny()
    {
        updateSky(sunny);
    }
    public void setSkyCloody()
    {
        updateSky(cloody);
    }
    public void setSkyStrom()
    {
        updateSky(storm);
    }
    public void setSkySnow()
    {
        updateSky(snow);
    }
}
