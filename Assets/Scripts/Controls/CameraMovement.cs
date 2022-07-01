using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera Camera;
    public bool Rotate;
    protected Plane Plane;
    public Vector2 ZoomBounds = new Vector2(2f, 20f);
    public Vector2 XBounds, ZBounds;
    [SerializeField]
    float CurrentZoom;
    //public float maxZoom=0.1f, minZoom=3f;

    private void Awake()
    {
        if (Camera == null)
            Camera = Camera.main;
    }

    private void Update()
    {

        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Flying");
        
        Camera.main.transform.position += new Vector3(x,h,z)*Time.deltaTime*12;


        //Update Plane
        if (Input.touchCount >= 1)
            Plane.SetNormalAndPosition(transform.up, transform.position);

        var Delta1 = Vector3.zero;
        var Delta2 = Vector3.zero;

        //Scroll
        if (Input.touchCount >= 1)
        {
            Delta1 = PlanePositionDelta(Input.GetTouch(0));
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
                Camera.transform.Translate(Delta1, Space.World);
        }

        //Pinch
        if (Input.touchCount >= 2)
        {
            var pos1  = PlanePosition(Input.GetTouch(0).position);
            var pos2  = PlanePosition(Input.GetTouch(1).position);
            var pos1b = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
            var pos2b = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

            //calc zoom
            var zoom = Vector3.Distance(pos1, pos2) /
                       Vector3.Distance(pos1b, pos2b);
            //edge case
            if (zoom == 1 || zoom > 10)
                return;
            
            //Move cam amount the mid ray
            Camera.transform.position = Vector3.LerpUnclamped(pos1, Camera.transform.position, 1 / zoom);
            //Camera.transform.forward = new Vector3(Mathf.Clamp(Camera.transform.forward.x,minZoom,maxZoom), Camera.transform.forward.y, Camera.transform.forward.z);
            //Camera.transform.position = new Vector3(Camera.transform.forward.x, Camera.transform.forward.y, Mathf.Clamp(Camera.transform.forward.z, minZoom, maxZoom)) * Camera.transform.position;

            if (Rotate && pos2b != pos2)
                Camera.transform.RotateAround(pos1, Plane.normal, Vector3.SignedAngle(pos2 - pos1, pos2b - pos1b, Plane.normal));
        }
        CameraLimit();
    }



    protected Vector3 PlanePositionDelta(Touch touch)
    {
        //not moved
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;

        //delta
        var rayBefore = Camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = Camera.ScreenPointToRay(touch.position);
        if (Plane.Raycast(rayBefore, out var enterBefore) && Plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);

        //not on plane
        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos)
    {
        //position
        var rayNow = Camera.ScreenPointToRay(screenPos);
        if (Plane.Raycast(rayNow, out var enterNow))
            return rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }

    void CameraLimit()
    {
        Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, XBounds.x, XBounds.y), Mathf.Clamp(Camera.main.transform.position.y, ZoomBounds.x, ZoomBounds.y), Mathf.Clamp(Camera.main.transform.position.z, ZBounds.x, ZBounds.y));
    }
}
