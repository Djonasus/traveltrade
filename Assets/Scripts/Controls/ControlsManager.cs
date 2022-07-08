using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour
{
    [SerializeField]
    GameObject SelectedMenuObj;
    [SerializeField]
    GameObject PlayerSelectedMenu;
    public bool CanCameraAct = true;

    // Update is called once per frame
    void Update()
    {
        if (CanCameraAct)
        {
            if (Input.GetMouseButtonUp(0))
            {
                SelectCity();
                SelectPlayer();
            }
        }

    }
    void SelectPlayer()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(raycast, out raycastHit))
        {
            if (raycastHit.collider.CompareTag("Player") && raycastHit.collider.GetComponent<PathMover>().GetMoveStatus())
            {
                PlayerSelectedMenu.SetActive(true);
                //CanCameraAct = false;
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
                SelectedMenuObj.SetActive(false);
                PlayerSelectedMenu.GetComponent<PlayerSelectedMenu>().DestinationLabel.GetComponent<Text>().text = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().currentCity.CityName+" -> "+ GameObject.FindGameObjectWithTag("Player").GetComponent<PathMover>().destination.GetComponent<City>().cty.CityName;
            }
        }
    }
    void SelectCity()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(raycast, out raycastHit))
        {
            if (raycastHit.collider.GetComponent<City>() && raycastHit.collider.GetComponent<City>().cty != GetComponent<PlayerData>().currentCity)
            {
                SelectedMenuObj.SetActive(true);
                GameObject city = raycastHit.collider.gameObject;
                //Debug.Log(raycastHit.collider.GetComponent<City>().cty.CityName);
                Camera.main.transform.position = new Vector3(city.transform.position.x, Camera.main.transform.position.y, city.transform.position.z - 4);
                CanCameraAct = false;
                SelectedMenuObj.GetComponent<SelectedMenu>().cty = city.GetComponent<City>();
                city.transform.GetChild(1).gameObject.SetActive(true);
                SelectedMenuObj.GetComponent<SelectedMenu>().CityNameObj.GetComponent<Text>().text = city.GetComponent<City>().cty.CityName + ", " + city.GetComponent<City>().cty.Province;
                PlayerSelectedMenu.SetActive(false);
            }
        }
    }
}
