using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatBonkHandler : MonoBehaviour
{

    public CatBonkBehaviour manager;


    void OnMouseDown()
    {

        if (manager != null)
        {
            manager.HandleClick();
        }
    }
}
