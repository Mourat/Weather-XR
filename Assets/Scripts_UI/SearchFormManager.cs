using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Scripts_UI
{
    public class SearchFormManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _cityName;
        private APIManager _apiManager;
        private CitiesData _citiesAPIResult;

        private DropDownController _dropDownController;
        // private TMP_Dropdown _dropdown;
        private List<string> _cityNames;


        private void Awake()
        {
            // _apiManager = GetComponent<APIManager>();
            _apiManager = FindObjectOfType<APIManager>();
            _dropDownController = FindObjectOfType<DropDownController>();
            _cityNames = new List<string>();
            // _dropdown = GetComponent<TMP_Dropdown>();
        }

        // private void Start()
        // {
        //     apiManager.GetCities("nice");
        // }
        //
        // private void Update()
        // {
        //     if (apiManager.hasCitiesData)
        //     {
        //         foreach (var city in apiManager.citiesAPIResult.results)
        //         {
        //             print($"{city.name} / {city.country}");
        //         }
        //
        //         apiManager.hasCitiesData = false;
        //     }
        // }

        private void FindCity()
        {
            _apiManager.GetCities(_cityName.text);
            // _apiManager.GetCities("nice");



            // if (apiManager.hasCitiesData)
            // {
            //     // print(_citiesAPIResult.results[0].name);
            //     foreach (City city in apiManager.citiesAPIResult.results)
            //     {
            //         _cityNames.Add(String.Format($"{city.name}/{city.country}"));
            //     }
            //     _dropdown.ClearOptions();
            //     _dropdown.AddOptions(_cityNames);
            // }


        }

        // private void Start()
        // {
        //     _apiManager.GetCities("nice");
        //     
        // }

    private void Update()
        {
            if (_apiManager.hasCitiesData)
            {
                
                foreach (var city in _apiManager.citiesAPIResult.results)
                {
                    // print($"{city.name} / {city.country}");
                    _cityNames.Add(city.name + " / " + city.country);
                }
                _dropDownController.FillDropdown(_cityNames);
                _apiManager.hasCitiesData = false;
            }
        }
    }
}
