using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    PathNode prevNode;
    public PathNode destination;
    bool Walking;
    public float Speed;
    public GameObject ToCityObj;
    // Start is called before the first frame update
    void Start()
    {
        Speed = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().BaseSpeed * GameObject.FindGameObjectWithTag("CameraManager").GetComponent<PlayerData>().SpeedMulti;
    }

    // Update is called once per frame
    void Update()
    {
        if (Walking)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, Speed*Time.deltaTime);
        }
    }
    public void MoveSafety(PathNode dest)
    {
        Walking = true;
        destination = dest;
    }
    public void StopMovement()
    {
        Walking = false;
        destination = null;
    }
    public bool GetMoveStatus()
    {
        return Walking;
    }
}
