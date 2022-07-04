using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedMenu : MonoBehaviour
{

    public City cty;
    public GameObject CityNameObj;

    public void OnCancelClick()
    {
        GameObject.FindGameObjectWithTag("CameraManager").GetComponent<ControlsManager>().CanCameraAct = true;
        cty.transform.GetChild(1).gameObject.SetActive(false);
        //cty = null;
        gameObject.SetActive(false);
    }
}
