using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerKnight : GameFunction
{
    Transform Knight;
    
    void Awake()
    {
        Knight=transform;
    }
    void FixedUpdate()
    {
        AutoPosition(Knight);
        if(Knight.parent.childCount>0)
            for(int i=0;i<Knight.parent.childCount;i++)
                if(Knight.parent.GetChild(i).transform!=Knight)
                    Destroy(Knight.parent.GetChild(i).gameObject);
    }
}