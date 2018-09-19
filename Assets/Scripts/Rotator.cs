using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // TODO: also add a function that rotates in mobile
    [SerializeField] Transform rotateParent = null; // optional to rotate a different transform
    [SerializeField] bool autoRotate = true;
    [SerializeField] float autoRotateSpeed = 0.5f;
    [SerializeField] float maxRotation = 10f;

    private bool mouseOn;
    private bool rotate;

    private Vector3 targetDir;
    private Quaternion offset;

    Transform objectToRotate;

    void Start()
    {
        objectToRotate = (rotateParent == null) ? transform : rotateParent;
        mouseOn.Equals(false);
        rotate.Equals(autoRotate);
    }

    void Update()
    {
        


        if (mouseOn.Equals(true))
        {
            rotate = false;
        }

        if (mouseOn.Equals(false) && autoRotate.Equals(true))
        {
            rotate = true;
        }



        if (rotate.Equals(true))
        {
            offset = Quaternion.FromToRotation(transform.up, targetDir);
            objectToRotate.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * autoRotateSpeed), 0f);
            
        }
    }

    void OnMouseDrag()
    {

        mouseOn = true;
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //Vector2 mouseDeltaSpeed = new Vector2(Input.acceleration.x * mouseDelta.x, Input.acceleration.y * mouseDelta.y);

        

        objectToRotate.rotation = Quaternion.Euler(mouseDelta.y * mouseDelta.magnitude, -mouseDelta.x * mouseDelta.magnitude, 0) * transform.rotation;
    }
    private void OnMouseUp()
    {
        mouseOn = false;
    }
}
