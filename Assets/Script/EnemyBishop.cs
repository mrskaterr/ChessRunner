using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBishop : GameFunction
{
    Sprite BlackSprite;
    Transform ChessBoard;
    Transform Parent;
    int BishopLetter;
    int BishopNumber;
    void Start()
    {
        BlackSprite = Resources.Load<Sprite>("Sprite/BlackBishop");
        ChessBoard=transform.parent.parent.parent;
        BishopLetter=transform.parent.GetSiblingIndex();
        BishopNumber=transform.parent.parent.parent.childCount-1;
    }
    void FixedUpdate()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            ChangeToBlack(gameObject,BlackSprite);
            krzywyatak(ChessBoard,BishopNumber,BishopLetter,gameObject);
        }
    }
    public void ChangeBishopNumber()
    {
        --BishopNumber;
    }
}
