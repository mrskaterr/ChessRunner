using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : GameFunction
{    
    Sprite BlackSprite;
    Transform ChessBoard;
    int PawnLetter;
    int PawnNumber;
    void Start()
    {
        BlackSprite=Resources.Load<Sprite>("Sprite/BlackPawn");
        ChessBoard=transform.parent.parent.parent;
        PawnLetter=transform.parent.GetSiblingIndex();
        PawnNumber=transform.parent.parent.parent.childCount-1;
    }
    void FixedUpdate()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            ChangeToBlack(gameObject,BlackSprite);
            PawnAttack(ChessBoard,PawnNumber,PawnLetter,gameObject);
        }

    }
    public void ChangePawnNumber()
    {
        --PawnNumber;
    }
}
