using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBishop : GameOver
{
    Transform ChessBoard;
    int BishopLetter;
    int BishopNumber;
    // Start is called before the first frame update
    void Start()
    {
        ChessBoard=transform.parent.parent.parent;
        BishopLetter=transform.parent.GetSiblingIndex();
        BishopNumber=17;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y,-1);//AutoPosition
        for(int i=BishopLetter,j=0;i<8;i++,j++){
            if(BishopNumber+j<18 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[BishopNumber+j].GetChild(i).childCount==1
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[BishopNumber+j].GetChild(i).GetChild(0).name=="Knight")
                Die();
            if(BishopNumber-j>=0 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[BishopNumber-j].GetChild(i).childCount==1 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[BishopNumber-j].GetChild(i).GetChild(0).name=="Knight")
                Die();
        }
        for(int i=BishopLetter,j=0;i>=0;i--,j++){
            if(BishopNumber+j<18
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[BishopNumber+j].GetChild(i).childCount==1
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[BishopNumber+j].GetChild(i).GetChild(0).name=="Knight")
                Die();
            if(BishopNumber-j>=0 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[BishopNumber-j].GetChild(i).childCount==1 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[BishopNumber-j].GetChild(i).GetChild(0).name=="Knight")
                Die();
        }
    }
    public void ChangeBishopNumber(){
        --BishopNumber;
    }
}
