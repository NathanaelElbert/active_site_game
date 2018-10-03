using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {



     void Update()
    {
        x = Input.mousePosition.x / mainCamera.pixelWidth;
        y = Input.mousePosition.y / mainCamera.pixelHeight;
        transform.position = Vector3(x, y, 0);

    }

    


}
