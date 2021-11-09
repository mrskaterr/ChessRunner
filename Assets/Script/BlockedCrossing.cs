using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedCrossing : GameFunction
{
    Transform ChessBoard;
    int ChessmanLetter;
    int ChessmanNumber;
    void Start()
    {
        ChessBoard=transform.parent.parent.parent;
        ChessmanLetter=transform.parent.GetSiblingIndex();
        ChessmanNumber=transform.parent.parent.parent.childCount-1;
    }
    void Update()
    {
            if(krzywyatakWarunek3(ChessmanNumber,ChessmanLetter)){
                Debug.Log("KRZYWA OSŁONA");
                ChessBoard.GetComponent<FieldMove>().Speed=0;
            }
            if(prostyatakwarunek3(ChessmanNumber,ChessmanLetter)){
                Debug.Log("PROSTA OSŁONA");
                ChessBoard.GetComponent<FieldMove>().Speed=0;
            }
    }
}
