using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlesController : MonoBehaviour
{

    public Camera camera;

    public GameObject CitiesObj;

    GameObject[] provinces, cities, countries;

    // Start is called before the first frame update
    void Start()
    {
        cities = GameObject.FindGameObjectsWithTag("City");
        provinces = GameObject.FindGameObjectsWithTag("Province");
        countries = GameObject.FindGameObjectsWithTag("Country");

        if (camera == null)
        {
            camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(camera.transform.position.y <= 15)
        {
            foreach (GameObject city in cities)
            {
                city.SetActive(true);
            }
            foreach (GameObject province in provinces)
            {
                province.SetActive(false);
            }
            foreach (GameObject country in countries)
            {
                country.SetActive(false);
            }
            CitiesObj.SetActive(true);
        }
        if (camera.transform.position.y >= 15 && camera.transform.position.y <= 25)
        {
            foreach (GameObject city in cities)
            {
                city.SetActive(false);
            }
            foreach (GameObject province in provinces)
            {
                province.SetActive(true);
            }
            foreach (GameObject country in countries)
            {
                country.SetActive(false);
            }
            CitiesObj.SetActive(false);
        }
        if (camera.transform.position.y >= 25)
        {
            foreach (GameObject city in cities)
            {
                city.SetActive(false);
            }
            foreach (GameObject province in provinces)
            {
                province.SetActive(false);
            }
            foreach (GameObject country in countries)
            {
                country.SetActive(true);
            }
            CitiesObj.SetActive(false);
        }
    }
}
