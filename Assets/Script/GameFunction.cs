using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameFunction : MonoBehaviour
{
    public Transform[] Board;
    public void Die()
    {
        Debug.Log("YOU DIE");
        StartCoroutine(Wait(5.0f));
    }
    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Game");
    }
    public void ChangeToBlack(GameObject Chessman,Sprite BlackSprite)
    {
        if(Chessman.GetComponent<SpriteRenderer>().sprite!=BlackSprite)
            Chessman.GetComponent<SpriteRenderer>().sprite=BlackSprite;
    }
    public bool BlackLine(Transform Chessman,double y=9.5f)
    {
        if(Chessman.position.y<=y)
            return true;
        return false;
    }
    public void AutoPosition(Transform Chessman)
    {
        Chessman.position=new Vector3(Chessman.parent.transform.position.x, 
                                    Chessman.parent.transform.position.y,
                                    -1);
    }
    public Transform IsChessman(Transform[] ChessBoard,int i,int j)
    {
        if(ChessBoard[i].GetChild(j).childCount==1)
            return ChessBoard[i].GetChild(j).GetChild(0);
        
        return null;
    }
    public bool IsPlayerDie(Transform[] ChessBoard,int i,int j,GameObject THIS)
    {
        if(IsChessman(ChessBoard,i,j)?.GetComponent<PlayerKnight>())
        {
            ChessBoard[0].parent.gameObject.GetComponent<FieldMove>().Speed=0;
            THIS.GetComponent<SpriteRenderer>().color=Color.red;
            THIS.transform.position-=new Vector3(0,0,1);
            Die();
            return true;
        }
        return false;
    }

    public void PawnAttack(Transform ChessBoard,int Number,int Letter,GameObject THIS)
    {
        Board=ChessBoard.GetComponent<ChessBoardArray>().Board;
        if((Number-1>=0 && Letter>=0 && Letter+1<8))
            IsPlayerDie(Board,Number-1,Letter+1,THIS);
        if((Number-1>=0 && Letter-1>=0))
            IsPlayerDie(Board,Number-1,Letter-1,THIS);
    }

    public void KnightAttack(Transform ChessBoard,int Number,int Letter,GameObject THIS)
    {
        Board=ChessBoard.GetComponent<ChessBoardArray>().Board;

        if(Number+1<Board.Length && Letter+2<8)
            IsPlayerDie(Board,Number+1,Letter+2,THIS);
        if(Number+1<Board.Length && Letter-2>=0)
            IsPlayerDie(Board,Number+1,Letter-2,THIS);
        if(Number-1>=0 && Letter+2<8)
            IsPlayerDie(Board,Number-1,Letter+2,THIS);
        if(Number-1>=0 && Letter-2>=0)
            IsPlayerDie(Board,Number-1,Letter-2,THIS);
        if(Number+2<Board.Length && Letter+1<8 )
            IsPlayerDie(Board,Number+2,Letter+1,THIS);
        if(Number+2<Board.Length && Letter-1>=0)
            IsPlayerDie(Board,Number+2,Letter-1,THIS);
        if(Number-2>=0 && Letter+1<8)
            IsPlayerDie(Board,Number-2,Letter+1,THIS);
        if(Number-2>=0 && Letter-1>=0)
            IsPlayerDie(Board,Number-2,Letter-1,THIS);
    }
    public void krzywyatak(Transform ChessBoard,int Number,int Letter,GameObject THIS)
    {
        Board=ChessBoard.GetComponent<ChessBoardArray>().Board;
        for(int i=Letter,j=0;i<8;i++,j++)
            if(krzywyatakWarunek(Number,i,j,THIS))
                break;
        for(int i=Letter,j=0;i<8;i++,j++)
            if(krzywyatakWarunek2(Number,i,j,THIS))
                break;
        for(int i=Letter,j=0;i>=0;i--,j++)
            if(krzywyatakWarunek(Number,i,j,THIS))
                break;
        for(int i=Letter,j=0;i>=0;i--,j++)
            if(krzywyatakWarunek2(Number,i,j,THIS))
                break;

    }
    public void prostyatak(Transform ChessBoard,int Number,int Letter,GameObject THIS)
    {
        Board=ChessBoard.GetComponent<ChessBoardArray>().Board;
        for(int i=Letter;i<8;i++)
            if(prostyatakwarunek(Number,Letter,i,THIS))
                break;
        for(int i=Letter;i>=0;i--)
            if(prostyatakwarunek(Number,Letter,i,THIS))
                break;
        for(int i=Number;i<Board.Length;i++)
            if(prostyatakwarunek2(Number,Letter,i,THIS))
                break;
        for(int i=Number;i>=0;i--)
            if(prostyatakwarunek2(Number,Letter,i,THIS))
                break;
    }

    public bool krzywyatakWarunek(int Number,int i, int j,GameObject THIS)
    {
        if(Number+j<Board.Length){
            IsPlayerDie(Board,Number+j,i,THIS);
            if(IsChessman(Board,Number+j,i)?.GetComponent<EnemyTower>())return true;
            else if(IsChessman(Board,Number+j,i)?.GetComponent<EnemyPawn>())return true;
            else if(IsChessman(Board,Number+j,i)?.GetComponent<EnemyKnight>())return true;
        }
        return false;
    }
    public bool krzywyatakWarunek2(int Number,int i, int j,GameObject THIS)
    {
        if(Number-j>=0)
        {
            IsPlayerDie(Board,Number-j,i,THIS);
            if((IsChessman(Board,Number-j,i))?.GetComponent<EnemyTower>())return true;
            else if(IsChessman(Board,Number-j,i)?.GetComponent<EnemyPawn>())return true;
            else if(IsChessman(Board,Number-j,i)?.GetComponent<EnemyKnight>())return true;
        }
        return false;
    }
    public bool krzywyatakWarunek3(int Number,int Letter,GameObject THIS)
    {
        for(int i=Letter,j=0;i<8;i++,j++){
            if(j==0)continue;
            if(Number+j<Board.Length){
                if(IsChessman(Board,Number+j,i)?.GetComponent<EnemyHetman>()){
                    Debug.Log(IsChessman(Board,Number+j,i)?.name);
                    return true;
                }
                else if(IsChessman(Board,Number+j,i)?.GetComponent<EnemyBishop>()){
                    Debug.Log(IsChessman(Board,Number+j,i)?.name);
                    return true;
                }
            }
        }
       
        for(int i=Letter,j=0;i>=0;i--,j++)
        {
            if(j==0)continue;
            if(Number+j<Board.Length){
                if(IsChessman(Board,Number+j,i)?.GetComponent<EnemyHetman>())return true;
                else if(IsChessman(Board,Number+j,i)?.GetComponent<EnemyBishop>())return true;
            }
        }
        return false;
    }
    public bool prostyatakwarunek3(int Number,int Letter,GameObject THIS)
    {
        //Board.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(Letter)..localscale=new vector3(.5f,.5f,.5f);
        for(int i=Number+1;i<Board.Length;i++){
                if(IsChessman(Board,i,Letter)?.GetComponent<EnemyTower>()) return true;
                else if(IsChessman(Board,i,Letter)?.GetComponent<EnemyHetman>()) return true;
        }
        return false;
    }
    bool prostyatakwarunek2(int Number,int Letter,int i,GameObject THIS)
    {
        //Board.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(Letter)..localscale=new vector3(.5f,.5f,.5f);
        IsPlayerDie(Board,i,Letter,THIS);
        if(IsChessman(Board,i,Letter)?.GetComponent<EnemyBishop>()) return true;
        else if(IsChessman(Board,i,Letter)?.GetComponent<EnemyPawn>()) return true;
        else if(IsChessman(Board,i,Letter)?.GetComponent<EnemyKnight>()) return true;
        return false;
    }
    bool prostyatakwarunek(int Number,int Letter,int i,GameObject THIS)
    {
        IsPlayerDie(Board,Number,i,THIS);
        if(IsChessman(Board,Number,i)?.GetComponent<EnemyBishop>())return true;
        else if(IsChessman(Board,Number,i)?.GetComponent<EnemyPawn>())return true;
        else if(IsChessman(Board,Number,i)?.GetComponent<EnemyKnight>())return true;
        return false;
    }
}