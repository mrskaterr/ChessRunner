using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class KnightPosition : GameFunction
{
    Transform Knight;
    void Start()
    {
        Knight=transform;
    }
    void Update()
    {
        AutoPosition(Knight);
        if(Knight.position.y<=-1)Die();
        if(Knight.parent.childCount>0)
            for(int i=0;i<Knight.parent.childCount;i++){
                if(Knight.parent.GetChild(i).transform!=Knight)
                    Destroy(Knight.parent.GetChild(i).gameObject);
            }
        
    }
}