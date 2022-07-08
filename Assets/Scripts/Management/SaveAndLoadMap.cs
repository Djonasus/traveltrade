using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadMap : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().Money = PlayerPrefs.GetInt("Money");
        }
        if (PlayerPrefs.HasKey("Crystalls"))
        {
            GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().Crystalls = PlayerPrefs.GetInt("Crystalls");
        }
        GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().UpdateResourcesDisplay();
        if (PlayerPrefs.HasKey("XPos"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(PlayerPrefs.GetFloat("XPos"), GameObject.FindGameObjectWithTag("Player").transform.position.y, PlayerPrefs.GetFloat("ZPos"));
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("XPos", GameObject.FindGameObjectWithTag("Player").transform.position.x);
        PlayerPrefs.SetFloat("ZPos", GameObject.FindGameObjectWithTag("Player").transform.position.z);
        PlayerPrefs.SetInt("Money", GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().Money);
        PlayerPrefs.SetInt("Crystalls", GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().Crystalls);
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            PlayerPrefs.SetFloat("XPos", GameObject.FindGameObjectWithTag("Player").transform.position.x);
            PlayerPrefs.SetFloat("ZPos", GameObject.FindGameObjectWithTag("Player").transform.position.z);
            PlayerPrefs.SetInt("Money", GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().Money);
            PlayerPrefs.SetInt("Crystalls", GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().Crystalls);
        }
    }
}
