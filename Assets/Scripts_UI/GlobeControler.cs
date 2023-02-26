using Scripts_UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static System.Math;

public class GlobeControler : MonoBehaviour
{

    [SerializeField] APIManager apiManager;
    [SerializeField] DisplayInformations displayInformations;
    [SerializeField] SearchFormManager searchFormManager;

    private bool isClicked;
    private Vector3 clickPos;
    private Vector2 longLat;


    void OnMouseDown()
    {
        isClicked = Input.GetMouseButtonDown(0);
        clickPos = Input.mousePosition;

        RaycastHit rt;
        Ray ray = Camera.main.ScreenPointToRay(clickPos);
        if (Physics.Raycast(ray, out rt) && isClicked)
        {
            //  Debug.Log("Coordonnées cartésiennes : " + rt.point);
            // Transform into collider's local coordinate system.
            Vector3 offset = rt.collider.transform.InverseTransformPoint(rt.point);
            longLat = ToSpherical(offset);

            float latitude = longLat.y;
            float longitude = longLat.x;

            // Get weather data
            apiManager.GetWeekWeather(latitude, longitude);

            City city = new City();
            city.latitude = latitude;
            city.longitude = longitude;

            // Display city informations
            displayInformations.FillInfos(city);

            // clean search form
            searchFormManager.Clean();
        }
    }

    public Vector2 ToSpherical(Vector3 position)
    {
        // Convert to a unit vector so our y coordinate is in the range -1...1.
        position.Normalize();

        // The vertical coordinate (y) varies as the sine of latitude, not the cosine.
        float lat = Mathf.Asin(position.y) * Mathf.Rad2Deg;

        // Use the 2-argument arctangent, which will correctly handle all four quadrants.
        float lon = 90 - Mathf.Atan2(position.x, position.z) * Mathf.Rad2Deg;
        if (lon > 180f)
        {
            lon -= 360f;
        }
        // Here I'm assuming (0, 0, 1) = 0 degrees longitude, and (1, 0, 0) = +90.
        // You can exchange/negate the components to get a different longitude convention.

        Debug.Log(lat + ", " + lon);

        // I usually put longitude first because I associate vector.x with "horizontal."
        return new Vector2(lon, lat);
    }

    /**
     
    public Transform marker; // marker object
    public float radius = 5; // globe ball radius (unity units)
    public float latitude = 51.5072f; // lat
    public float longitude = 0.1275f; // long

    
    private void Start()
    {
        // calculation code taken from 
        // @miquael http://www.actionscript.org/forums/showthread.php3?p=722957#post722957
        // convert lat/long to radians

        latitude = Mathf.PI * latitude / 180;
        longitude = Mathf.PI * longitude / 180;

        // adjust position by radians	
        latitude -= 1.570795765134f; // subtract 90 degrees (in radians)

        // and switch z and y (since z is forward)
        float xPos = (radius) * Mathf.Sin(latitude) * Mathf.Cos(longitude);
        float zPos = (radius) * Mathf.Sin(latitude) * Mathf.Sin(longitude);
        float yPos = (radius) * Mathf.Cos(latitude);

        // move marker to position
        marker.position = new Vector3(xPos, yPos, zPos);
    }
    */


}
