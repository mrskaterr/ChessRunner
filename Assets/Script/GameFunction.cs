using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFunction : MonoBehaviour
{
    Transform[] Board;
    string Knight="Knight";
    string Tower="Tower(Clone)";
    string Bishop="Bishop(Clone)";
    public void Die(){
        //SceneManager.LoadScene("Game");
        Debug.Log("YOU DIE");
    }
    public bool RedLine(Transform Chessman)
    {
        if(Chessman.position.y<=9.5f)
            return true;
        return false;
    }
    public void AutoPosition(Transform Chessman){
        Chessman.position=new Vector3(Chessman.parent.transform.position.x, 
                                    Chessman.parent.transform.position.y,
                                    -1);
    }
    public void PawnAttack(Transform ChessBoard,int Number,int Letter){
        Board=ChessBoard.GetComponent<ChessBoardArray>().ChessBoard;
        if((Number-1>=0 && Letter-1>=0 && Letter+1<8)){
            if((Board[Number-1].GetChild(Letter-1).childCount==1
            &&  Board[Number-1].GetChild(Letter-1).GetChild(0).name==Knight)
            || (Board[Number-1].GetChild(Letter+1).childCount==1
            &&  Board[Number-1].GetChild(Letter+1).GetChild(0).name==Knight))
                Die();
            else{}
        }

    }
    bool krzywyatakWarunek(int Number,int i, int j){
            //if(Number+j<18)Board[Number+j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
            if(Number+j<18 && Board[Number+j].GetChild(i).childCount==1){
                if(Board[Number+j].GetChild(i).GetChild(0).name==Knight)Die();
                else if(Board[Number+j].GetChild(i).GetChild(0).name==Tower)return true;
            }
            return false;
    }
    bool krzywyatakWarunek2(int Number,int i, int j){
         if(Number-j>=0 && Board[Number-j].GetChild(i).childCount==1){
                if( Board[Number-j].GetChild(i).GetChild(0).name==Knight)Die();
                else if(Board[Number-j].GetChild(i).GetChild(0).name==Tower)return true;
            }
            return false;
    }
    public void krzywyatak(Transform ChessBoard,int Number,int Letter){
        Board=ChessBoard.GetComponent<ChessBoardArray>().ChessBoard;
        for(int i=Letter,j=0;i<8;i++,j++)
            if(krzywyatakWarunek(Number,i,j))break;
        for(int i=Letter,j=0;i<8;i++,j++)
            if(krzywyatakWarunek2(Number,i,j))break;

        for(int i=Letter,j=0;i>=0;i--,j++)
            if(krzywyatakWarunek(Number,i,j))break;
        for(int i=Letter,j=0;i>=0;i--,j++)
            if(krzywyatakWarunek2(Number,i,j))break;
    }
    bool prostyatakwarunek2(int Number,int Letter,int i){
        //Board.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(Letter)..localscale=new vector3(.5f,.5f,.5f);
        if(Board[i].GetChild(Letter).childCount==1){
            if(Board[i].GetChild(Letter).GetChild(0).name==Knight) Die();
            else if(Board[i].GetChild(Letter).GetChild(0).name==Bishop) return true;
        }
        return false;
    }
    bool prostyatakwarunek(int Number,int Letter,int i){
            if(Board[Number].GetChild(i).childCount==1){
                if( Board[Number].GetChild(i).GetChild(0).name==Knight)Die();
                else if(Board[Number].GetChild(i).GetChild(0).name==Bishop)return true;
            }
        return false;
    }
    public void prostyatak(Transform ChessBoard,int Number,int Letter){
        Board=ChessBoard.GetComponent<ChessBoardArray>().ChessBoard;
        for(int i=Letter;i<8;i++){
            if(prostyatakwarunek(Number,Letter,i))break;
        }
        for(int i=Letter;i>=0;i--){
            if(prostyatakwarunek(Number,Letter,i))break;
        }
        for(int i=Number;i<Board.Length;i++){
            if(prostyatakwarunek2(Number,Letter,i))break;
        }
        for(int i=Number;i>=0;i--){
            if(prostyatakwarunek2(Number,Letter,i))break;
        }
    }
}