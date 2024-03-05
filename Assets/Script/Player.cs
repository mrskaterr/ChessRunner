using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : GameFunction
{
    
    Transform player;
    
    void Awake()
    {
        Debug.Log("int "+PlayerPrefs.GetInt("Player"));
        Debug.Log("enum " + (EnumHelp.Character)PlayerPrefs.GetInt("Player"));
        GetComponent<EnumHelp>().character = (EnumHelp.Character)PlayerPrefs.GetInt("Player");
        player=transform;
    }
    void FixedUpdate()
    {
        AutoPosition(player);
        if(player.parent.childCount>0)
            for(int i=0;i<player.parent.childCount;i++)
                if(player.parent.GetChild(i).transform!=player)
                    Destroy(player.parent.GetChild(i).gameObject);
    }
}