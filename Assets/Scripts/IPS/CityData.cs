using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New City", menuName = "City Data")]
public class CityData : ScriptableObject
{
    public string CityName;
    public enum cityType
    {
        Little,
        Medium,
        Megapolice,
        Capital,
        Port
    }
    public cityType CityType;
    public enum transferMethod
    {
        Walking,
        Boat
        
    }
    public transferMethod TransferMethod;
    public enum province
    {
        Akwus,
        Degort,
        Naize,
        Narkhalit,
        Kairus,
        Highres,
        LirKardur
    }
    public province Province;
    //public GameObject cityObj;
    public Vector3 cityPosition;
    public CityData[] NearestCities;
}
