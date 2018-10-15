using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTeleport : MonoBehaviour {

    Transform teleported;

   void Start()
    {
        GameObject[] FindGameObjectsWithLayer(int layer)
        {
            GameObject[] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
            List goList = new List();
            for (int i = 0; i < goArray.Length; i++)
            {
                if (goArray[i].layer == layer)
                {
                    goList.Add(goArray[i]);
                }
            }
            if (goList.Count == 0)
            {
                return null;
            }
            return goList.ToArray();
        }
    }
    void OnMouseDown()
    {
        if (teleported.gameObject.layer.Equals(1))
        {
            
        }
    }
}


