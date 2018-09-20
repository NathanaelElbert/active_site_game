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

    private bool goOn;
    private bool rotate;

   

    Transform objectToRotate;

    void Start()
    {
        objectToRotate = (rotateParent == null) ? transform : rotateParent;
        goOn.Equals(false);
        rotate.Equals(autoRotate);
    }

    void Update()
    {
        


        if (goOn.Equals(true))
        {
            rotate = false;
        }

        if (goOn.Equals(false) && autoRotate.Equals(true))
        {
            rotate = true;
        }



        if (rotate.Equals(true))
        {
            objectToRotate.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * autoRotateSpeed), 0f);
            
        }


        if (PlayerMoveController.go.Equals(true))
        {
            goOn = true;
        }


       



    }

   
    
}
