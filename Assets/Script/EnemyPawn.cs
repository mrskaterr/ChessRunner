using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : GameFunction
{
    Transform ChessBoard;
    int PawnLetter;
    int PawnNumber;
    void Start()
    {
        ChessBoard=transform.parent.parent.parent;
        PawnLetter=transform.parent.GetSiblingIndex();
        PawnNumber=transform.parent.parent.parent.childCount-1;
    }

    // Update is called once per frame
    void Update()
    {
        AutoPosition(transform);
        if(RedLine(transform))
            PawnAttack(ChessBoard,PawnNumber,PawnLetter);
    }
    public void ChangePawnNumber(){
        --PawnNumber;
    }
}
