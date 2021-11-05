using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardArray : GameFunction
{
    // Start is called before the first frame update
    public Transform[] ChessBoard;

    void Start()
    {
        ChessBoard=new Transform[transform.childCount];
        for(int i=0;i<transform.childCount;i++){
            ChessBoard[i]=transform.GetChild(i);
        }
    }
    public void UpdateArray(){
        Transform[] NewBoard=new Transform[transform.childCount];
        for(int i=1;i<transform.childCount;i++)
        {
            NewBoard[i-1]=ChessBoard[i];
        }
        NewBoard[transform.childCount-1]=ChessBoard[0];
        ChessBoard=NewBoard;
        for(int i=0;i<transform.childCount;i++){
            for(int j=0;j<8;j++){
                if(ChessBoard[i].GetChild(j).childCount==1 
                && ChessBoard[i].GetChild(j).GetChild(0).name=="Bishop(Clone)")
                    ChessBoard[i].GetChild(j).GetChild(0).GetComponent<EnemyBishop>().ChangeBishopNumber();
                if(ChessBoard[i].GetChild(j).childCount==1 
                && ChessBoard[i].GetChild(j).GetChild(0).name=="Hetman(Clone)")
                    ChessBoard[i].GetChild(j).GetChild(0).GetComponent<EnemyHetman>().ChangeHetmanNumber();
                if(ChessBoard[i].GetChild(j).childCount==1 
                && ChessBoard[i].GetChild(j).GetChild(0).name=="Tower(Clone)")
                    ChessBoard[i].GetChild(j).GetChild(0).GetComponent<EnemyTower>().ChangeTowerNumber();
                if(ChessBoard[i].GetChild(j).childCount==1 
                && ChessBoard[i].GetChild(j).GetChild(0).name=="Pawn(Clone)")
                    ChessBoard[i].GetChild(j).GetChild(0).GetComponent<EnemyPawn>().ChangePawnNumber();
            }
        }
    }
}
