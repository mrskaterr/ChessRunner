using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class KnightPosition : GameOver
{
    Transform Knight;
    void Start()
    {
        Knight=transform;
    }
    void Update()
    {
        Knight.position=new Vector3(Knight.parent.transform.position.x, Knight.parent.transform.position.y,-1);
        if(Knight.parent.childCount>1)
            for(int i=0;i<Knight.parent.childCount;i++){
                if(Knight.parent.GetChild(i).transform!=Knight)Destroy(Knight.parent.GetChild(i).gameObject);
            }
        if(Knight.position.y<=-1)Die();
    }
}