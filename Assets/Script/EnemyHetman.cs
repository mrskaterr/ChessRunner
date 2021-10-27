using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHetman : GameOver
{
    Transform ChessBoard;
    int HetmanLetter;
    int HetmanNumber;
    int Count;
    // Start is called before the first frame update
    void Start()
    {
        ChessBoard=transform.parent.parent.parent;
        Count=transform.parent.parent.parent.childCount;
        HetmanLetter=transform.parent.GetSiblingIndex();
        HetmanNumber=17;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y,-1);//AutoPosition
        for(int i=HetmanLetter,j=0;i<8;i++,j++){
            if(HetmanNumber+j<18
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[HetmanNumber+j].GetChild(i).childCount==1
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[HetmanNumber+j].GetChild(i).GetChild(0).name=="Knight")
                Die();
            if(HetmanNumber-j>=0 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[HetmanNumber-j].GetChild(i).childCount==1 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[HetmanNumber-j].GetChild(i).GetChild(0).name=="Knight")
                Die();
        }
        for(int i=HetmanLetter,j=0;i>=0;i--,j++){
            if(HetmanNumber+j<18
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[HetmanNumber+j].GetChild(i).childCount==1
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[HetmanNumber+j].GetChild(i).GetChild(0).name=="Knight")
                Die();
            if(HetmanNumber-j>=0 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[HetmanNumber-j].GetChild(i).childCount==1 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[HetmanNumber-j].GetChild(i).GetChild(0).name=="Knight")
                Die();
        }
        for(int i=0;i<8;i++){
            if(ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[HetmanNumber].GetChild(i).childCount==1
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[HetmanNumber].GetChild(i).GetChild(0).name=="Knight")
                Die();
        }
        for(int i=0;i<Count;i++){
            if(ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(HetmanLetter).childCount==1 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(HetmanLetter).GetChild(0).name=="Knight" )
                Die();
        }
    }
    public void ChangeHetmanNumber(){
        --HetmanNumber;
    }
}
