using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Scripts_UI
{
    public class DropDownController : MonoBehaviour
    {
        private APIManager _apiManager;
        private CitiesData _citiesAPIResult;
        private TMP_Dropdown _dropdown;
        private List<string> _cityNames;
        // [SerializeField] private Label label;
        // private Button button;

        [SerializeField] EditSky editSky;
        [SerializeField] DisplayInformations displayInformations;

        private void Awake()
        {
            _dropdown = transform.GetComponent<TMP_Dropdown>();
            _apiManager = FindObjectOfType<APIManager>();
        }

        public void FillDropdown(List<string> citiesList)
        {
            _dropdown.options.Clear();
            foreach (string city in citiesList)
            {
                TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(city);
                _dropdown.options.Add(option);
            }
            
            // _apiManager.GetWeekWeather(_citiesAPIResult.results[_dropdown.value].latitude, _citiesAPIResult.results[_dropdown.value].longitude);
            // print(_dropdown.options[_dropdown.value].text);
            // print(_dropdown.value);
            // button.onClick.Invoke();
        }

        public void onValueChanged()
        {

            Debug.Log("DropDownController > onValueChanged : OK");

            print(System.String.Format($"Latitude: {_apiManager.citiesAPIResult.results[_dropdown.value].latitude}"));
            print(System.String.Format($"Longitude: {_apiManager.citiesAPIResult.results[_dropdown.value].longitude}"));

            City city = _apiManager.citiesAPIResult.results[_dropdown.value];

            displayInformations.FillInfos(city);

           // int weatherCode = 0;

           // editSky.setSkyByWeatherCode(weatherCode);


        }
    }
}
