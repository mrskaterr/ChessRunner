using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumHelp : MonoBehaviour
{
    Transform oldParent;
   void Start()
    {
        oldParent = transform.parent;
    }
    public enum Character{
        Pawn,
        Knight,
        Bishop,
        Tower,
        Hetman
    }
    public Character character;
    void OnDisable()
    {
        transform.SetParent(oldParent);
    }
}

