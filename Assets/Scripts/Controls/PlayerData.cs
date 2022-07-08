using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int Crystalls = 100;
    public GameObject CrystallsTextObj;
    public int Money = 1000;
    public GameObject MoneyTextObj;

    public CityData currentCity;
    public float BaseSpeed;
    public float SpeedMulti;

    private void Start()
    {
        UpdateResourcesDisplay();
    }
    public void UpdateResourcesDisplay()
    {
        CrystallsTextObj.GetComponent<Text>().text = Crystalls.ToString();
        MoneyTextObj.GetComponent<Text>().text = Money.ToString();
    }
}
