using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardArray : GameFunction
{
    [SerializeField] Player player;
    Transform Character;
    public Player Player()
    {
        return player;
    }
    void Start()
    {
        Board=new Transform[transform.childCount];
        for(int i=0;i<transform.childCount;i++){
            Board[i]=transform.GetChild(i);
            Board[i].GetComponent<Row>().realNumber = i;
            Board[i].GetComponent<Row>().distanceNumber = i+1;
        }
        
    }
   
    public void UpdateArray(){
        Transform[] NewBoard=new Transform[transform.childCount];
        for(int i=1;i<transform.childCount;i++)
        {
            NewBoard[i-1]=Board[i];
        }
        Board[0].GetComponent<Row>().distanceNumber = Board[Board.Length - 1].GetComponent<Row>().distanceNumber + 1;
        NewBoard[transform.childCount-1]=Board[0];

        Board=NewBoard;
        for(int i=0;i<transform.childCount;i++){
                Board[i].GetComponent<Row>().realNumber = i;
            for (int j=0;j<8;j++){
                if (Board[i].GetChild(j).childCount==1)
                {
                    Character=Board[i].GetChild(j).GetChild(0);

                    Character.GetComponent<EnemyBishop>()?.ChangeBishopNumber();
                    Character.GetComponent<EnemyHetman>()?.ChangeHetmanNumber();
                    Character.GetComponent<EnemyTower>()?.ChangeTowerNumber();
                    Character.GetComponent<EnemyPawn>()?.ChangePawnNumber();
                    Character.GetComponent<EnemyKnight>()?.ChangeKnightNumber();
                } 
            }
        }
    }
}
