using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : GameFunction
{
    // Start is called before the first frame update
    Transform ChessBoard;
    int KnightLetter;
    int KnightNumber;
    void Start()
    {
        ChessBoard=transform.parent.parent.parent;
        KnightLetter=transform.parent.GetSiblingIndex();
        KnightNumber=transform.parent.parent.parent.childCount-1;
    }
    // Update is called once per frame
    void Update()
    {
        AutoPosition(transform);
        if(RedLine(transform)){
            KnightAttack(ChessBoard,KnightNumber,KnightLetter);
        }
    }
    public void ChangeKnightNumber(){
        --KnightNumber;
    }
}
