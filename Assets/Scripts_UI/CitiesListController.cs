using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CitiesListController : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    [SerializeField] APIManager apiManager;
    [SerializeField] GameObject citiesForm;
    [SerializeField] GameObject citiesInfos;

    private void Start()
    {
        // Set visible / unvisible
        citiesForm.transform.localScale = new Vector3(0,0,0);
        citiesInfos.transform.localScale = new Vector3(1, 1, 1);
    }

    // When cities list loaded display city selector
    private void Update()
    {
        if (apiManager.hasCitiesData)
        {
            citiesForm.transform.localScale = new Vector3(1,1,1);
            citiesInfos.transform.localScale = new Vector3(0, 0, 0);

            CitiesData data = apiManager.citiesAPIResult;
            this.FillCitiesList(data);
        }
    }

    public void FillCitiesList(CitiesData data)
    {
        for (int i=0; i< data.results.Length; i++)
        {
            if (i > 4)
            {
                return;
            }

            string city = data.results[i].name + " / " + data.results[i].country;

           // Debug.Log("CitiesListController > FillCitiesList > city : " + city);

            buttons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = city;
            buttons[i].GetComponent<CitiesButton>().city = data.results[i];
        }

   
        apiManager.hasCitiesData = false;

    }

}
