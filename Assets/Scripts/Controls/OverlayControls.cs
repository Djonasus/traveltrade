using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayControls : MonoBehaviour
{
    public GameObject CityNameObj;

    void Start()
    {
        UpdateCityInfo();
    }
    void LateUpdate()
    {
        UpdateCityInfo();
    }
    public void UpdateCityInfo()
    {
        CityData cty = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().currentCity;
        CityNameObj.GetComponent<Text>().text = cty.name + " / " + cty.Province;
    }
    public void OnCoinClick()
    {
        Debug.Log("Clicked");
    }
    public void OnTpClick()
    {
        Vector3 city = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().currentCity.cityPosition;
        Camera.main.transform.position = new Vector3(city.x, Camera.main.transform.position.y, city.z-16);
    }
}
