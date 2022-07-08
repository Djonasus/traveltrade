using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectedMenu : MonoBehaviour
{
    public GameObject WarningPanel;

    public City cty;
    public GameObject CityNameObj;
    public PathMover player;

    public void OnCancelClick()
    {
        GameObject.FindGameObjectWithTag("CameraManager").GetComponent<ControlsManager>().CanCameraAct = true;
        cty.transform.GetChild(1).gameObject.SetActive(false);
        //cty = null;
        gameObject.SetActive(false);
    }
    public void OnSafeTransferClick()
    {
        CityData currCity = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().currentCity;
        
        if (!currCity.NearestCities.Contains<CityData>(cty.cty))
        {
            WarningPanel.SetActive(true);
            return;
        }
        player.MoveSafety(cty.GetComponent<PathNode>());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PathMover>().ToCityObj.SetActive(false);
        OnCancelClick();
    }
    public void OnFastTransferClick()
    {

    }
    public void CloseWarningMessage()
    {
        WarningPanel.SetActive(false);
    }
}
