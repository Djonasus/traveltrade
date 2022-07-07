using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectedMenu : MonoBehaviour
{
    public GameObject DestinationLabel;
    public GameObject TimeTitle;
    public GameObject FasterButton;
    public GameObject ConfirmMenuObj;
    public void CloseMenu()
    {
        //GameObject.FindGameObjectWithTag("CameraManager").GetComponent<ControlsManager>().CanCameraAct = true;
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    public void OnStopMoveClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PathMover>().StopMovement();
    }

    public void onFasterClick()
    {
        ConfirmMenuObj.SetActive(true);
    }
    public void onConfirmClick()
    {
        Transform pl = GameObject.FindGameObjectWithTag("Player").transform;
        Transform cty = GameObject.FindGameObjectWithTag("Player").GetComponent<PathMover>().destination.transform;
        int tme = (int)(Vector3.Distance(pl.position, cty.position) / GameObject.FindGameObjectWithTag("Player").GetComponent<PathMover>().Speed);
        if (GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().Crystalls >= (tme/20))
        {
            GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().Crystalls -= tme / 20;
            pl.position = new Vector3(cty.position.x,pl.position.y,cty.position.z);
            GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().UpdateResourcesDisplay();
            onCancelConfirmClick();
            CloseMenu();
        }
    }
    public void onCancelConfirmClick()
    {
        ConfirmMenuObj.SetActive(false);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PathMover>().destination != null) {
            Transform pl = GameObject.FindGameObjectWithTag("Player").transform;
            Transform cty = GameObject.FindGameObjectWithTag("Player").GetComponent<PathMover>().destination.transform;
            int tme = (int) (Vector3.Distance(pl.position, cty.position) / GameObject.FindGameObjectWithTag("Player").GetComponent<PathMover>().Speed);
            TimeTitle.GetComponent<Text>().text = (tme).ToString()+" сек.";
            FasterButton.SetActive(true);
            FasterButton.transform.GetChild(0).GetComponent<Text>().text = (tme / 20).ToString();
        } else
        {
            FasterButton.SetActive(false);
            TimeTitle.GetComponent<Text>().text = "";
        }
    }
}
