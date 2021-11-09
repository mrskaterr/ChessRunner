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

    // Update is called once per frame
    void Update()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            PawnAttack(ChessBoard,PawnNumber,PawnLetter);
            if(GetComponent<SpriteRenderer>().sprite!=BlackSprite)
                GetComponent<SpriteRenderer>().sprite=BlackSprite;
        }

    }
    public void ChangePawnNumber(){
        --PawnNumber;
    }
}
