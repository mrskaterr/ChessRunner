using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardArray : GameFunction
{
    // Start is called before the first frame update
    void Start()
    {
        Board=new Transform[transform.childCount];
        for(int i=0;i<transform.childCount;i++){
            Board[i]=transform.GetChild(i);
        }
    }
    public void UpdateArray(){
        Transform[] NewBoard=new Transform[transform.childCount];
        for(int i=1;i<transform.childCount;i++)
        {
            NewBoard[i-1]=Board[i];
        }
        NewBoard[transform.childCount-1]=Board[0];
        Board=NewBoard;
        for(int i=0;i<transform.childCount;i++){
            for(int j=0;j<8;j++){
                if(Board[i].GetChild(j).childCount==1 
                && Board[i].GetChild(j).GetChild(0).name=="Bishop(Clone)")
                    Board[i].GetChild(j).GetChild(0).GetComponent<EnemyBishop>().ChangeBishopNumber();
                if(Board[i].GetChild(j).childCount==1 
                && Board[i].GetChild(j).GetChild(0).name=="Hetman(Clone)")
                    Board[i].GetChild(j).GetChild(0).GetComponent<EnemyHetman>().ChangeHetmanNumber();
                if(Board[i].GetChild(j).childCount==1 
                && Board[i].GetChild(j).GetChild(0).name=="Tower(Clone)")
                    Board[i].GetChild(j).GetChild(0).GetComponent<EnemyTower>().ChangeTowerNumber();
                if(Board[i].GetChild(j).childCount==1 
                && Board[i].GetChild(j).GetChild(0).name=="Pawn(Clone)")
                    Board[i].GetChild(j).GetChild(0).GetComponent<EnemyPawn>().ChangePawnNumber();
            }
        }
    }
}
