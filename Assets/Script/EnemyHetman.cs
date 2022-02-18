using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHetman : GameFunction
{
    Transform ChessBoard;
    Sprite BlackSprite;
    int HetmanLetter;
    int HetmanNumber;
    void Start()
    {
        BlackSprite=Resources.Load<Sprite>("Sprite/BlackHetman");
        ChessBoard=transform.parent.parent.parent;
        HetmanLetter=transform.parent.GetSiblingIndex();
        HetmanNumber=transform.parent.parent.parent.childCount-1;
    }
    void FixedUpdate()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            ChangeToBlack(gameObject,BlackSprite);
            prostyatak(ChessBoard,HetmanNumber,HetmanLetter,gameObject);
            krzywyatak(ChessBoard,HetmanNumber,HetmanLetter,gameObject);
        }
    }
    public void ChangeHetmanNumber()
    {
        --HetmanNumber;
    }
}
