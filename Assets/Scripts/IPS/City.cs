using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class City : MonoBehaviour
{
    public CityData cty;

    public void OnClck()
    {
        Debug.Log(cty.CityName);
        Debug.Log(cty.CityType);
    }
    public void Awake()
    {
        transform.GetChild(0).GetComponent<TextMeshPro>().text = cty.CityName;
    }
}
