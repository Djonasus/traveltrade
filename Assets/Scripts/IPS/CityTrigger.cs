using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTrigger : MonoBehaviour
{
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
            Debug.Log("Hello");
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().currentCity != GetComponent<City>().cty) && (other.GetComponent<PathMover>().destination.GetComponent<City>() == GetComponent<City>()))
        {
            GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().currentCity = GetComponent<City>().cty;
            other.GetComponent<PathMover>().StopMovement();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PathMover>().ToCityObj.SetActive(true);

        }
    }
}
