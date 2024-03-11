using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class GameFunction : MonoBehaviour
{
    
    [HideInInspector]public static Transform[] Board;
    public static bool PlayerDead = false;
    public const short const_0 = 0;
    public const short const_1 = 1;
    public const short const_2 = 2;
    public void DebLog(string txt )
    {
        Debug.Log(txt);
    }


    public void Die(Transform player)
    {
        if (!PlayerDead)
        {
            PlayerDead = true;
            DebLog("YOU DIE");
            StartCoroutine(Wait(2.0f, player));
        }
    }
    IEnumerator Wait(float waitTime, Transform player)
    {
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<Player>().DeadScreen();
        //SceneManager.LoadScene("Game");
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

            Chessman.position = new Vector3(Chessman.parent.transform.position.x,
                                       Chessman.parent.transform.position.y,
                                       -1);
        
    }
    public Transform IsChessman(int i,int j)
    {
        if(Board[i].GetChild(j).childCount==1)
            return Board[i].GetChild(j).GetChild(0);
        
        return null;
    }

    public bool IsPlayerDie(int i,int j)
    {
        if(IsChessman(i,j)?.GetComponent<Player>())
        {
            Board[0].parent.gameObject.GetComponent<FieldMove>().Speed=0;
            GetComponent<SpriteRenderer>().color=Color.red;
            transform.position-=new Vector3(0,0,1);

            Die(IsChessman( i, j));
            return true;
        }
        return false;
    }

    public void PawnAttack(int Number,int Letter)
    {
        if((Number-1>=0 && Letter>=0 && Letter+1<8))
            IsPlayerDie(Number-1,Letter+1);
        if((Number-1>=0 && Letter-1>=0))
            IsPlayerDie(Number-1,Letter-1);
    }

    public void KnightAttack(int Number,int Letter)
    {
        if(Number+1<Board.Length && Letter+2<8)
            IsPlayerDie(Number+1,Letter+2);
        if(Number+1<Board.Length && Letter-2>=0)
            IsPlayerDie(Number+1,Letter-2);
        if(Number-1>=0 && Letter+2<8)
            IsPlayerDie(Number-1,Letter+2);
        if(Number-1>=0 && Letter-2>=0)
            IsPlayerDie(Number-1,Letter-2);
        if(Number+2<Board.Length && Letter+1<8 )
            IsPlayerDie(Number+2,Letter+1);
        if(Number+2<Board.Length && Letter-1>=0)
            IsPlayerDie(Number+2,Letter-1);
        if(Number-2>=0 && Letter+1<8)
            IsPlayerDie(Number-2,Letter+1);
        if(Number-2>=0 && Letter-1>=0)
            IsPlayerDie(Number-2,Letter-1);
    }
    public void krzywyatak(int Number,int Letter)
    {
        for(int i=Letter,j=0;i<8;i++,j++)
            if(krzywyatakWarunek(Number,i,j))
                break;
        for(int i=Letter,j=0;i<8;i++,j++)
            if(krzywyatakWarunek2(Number,i,j))
                break;
        for(int i=Letter,j=0;i>=0;i--,j++)
            if(krzywyatakWarunek(Number,i,j))
                break;
        for(int i=Letter,j=0;i>=0;i--,j++)
            if(krzywyatakWarunek2(Number,i,j))
                break;
    }
    public void prostyatak(int Number,int Letter)
    {
        for(int i=Letter;i<8;i++)
            if(prostyatakwarunek(Number,Letter,i))
                break;
        for(int i=Letter;i>=0;i--)
            if(prostyatakwarunek(Number,Letter,i))
                break;
        for(int i=Number;i<Board.Length;i++)
            if(prostyatakwarunek2(Number,Letter,i))
                break;
        for(int i=Number;i>=0;i--)
            if(prostyatakwarunek2(Number,Letter,i))
                break;
    }

    public bool krzywyatakWarunek(int Number,int i, int j)
    {
        if(Number+j<Board.Length){
            IsPlayerDie(Number+j,i);
            if(IsChessman( Number+j,i)?.GetComponent<EnemyTower>())return true;
            else if(IsChessman(Number+j,i)?.GetComponent<EnemyPawn>())return true;
            else if(IsChessman(Number+j,i)?.GetComponent<EnemyKnight>())return true;
        }
        return false;
    }
    public bool krzywyatakWarunek2(int Number,int i, int j)
    {
        if(Number-j>=0)
        {
            IsPlayerDie(Number-j,i);
            if(IsChessman(Number-j,i)?.GetComponent<EnemyTower>()) return true;
            else if(IsChessman(Number - j, i)?.GetComponent<EnemyPawn>()) return true;
            else if (IsChessman(Number - j, i)?.GetComponent<EnemyKnight>()) return true;
        }
        return false;
    }

    bool prostyatakwarunek2(int Number,int Letter,int i)
    {
        IsPlayerDie(i, Letter);
        if(IsChessman(i,Letter)?.GetComponent<EnemyBishop>()) return true;
        else if(IsChessman(i,Letter)?.GetComponent<EnemyPawn>()) return true;
        else if(IsChessman(i,Letter)?.GetComponent<EnemyKnight>()) return true;
        return false;
    }
    bool prostyatakwarunek(int Number,int Letter,int i )
    {
        IsPlayerDie(Number,i);
        if(IsChessman(Number,i)?.GetComponent<EnemyBishop>())return true;
        else if(IsChessman(Number,i)?.GetComponent<EnemyPawn>())return true;
        else if(IsChessman(Number,i)?.GetComponent<EnemyKnight>())return true;
        return false;
    }
    //public bool krzywyatakWarunek3(int Number, int Letter)
    //{
    //    for (int i = Letter, j = 0; i < 8; i++, j++)
    //    {
    //        if (j == 0) continue;
    //        if (Number + j < Board.Length)
    //        {
    //            if (IsChessman(Number + j, i)?.GetComponent<EnemyHetman>())
    //            {
    //                DebLog(IsChessman(Number + j, i)?.name);
    //                return true;
    //            }
    //            else if (IsChessman(Number + j, i)?.GetComponent<EnemyBishop>())
    //            {
    //                DebLog(IsChessman(Number + j, i)?.name);
    //                return true;
    //            }
    //        }
    //    }

    //    for (int i = Letter, j = 0; i >= 0; i--, j++)
    //    {
    //        if (j == 0) continue;
    //        if (Number + j < Board.Length)
    //        {
    //            if (IsChessman(Number + j, i)?.GetComponent<EnemyHetman>()) return true;
    //            else if (IsChessman(Number + j, i)?.GetComponent<EnemyBishop>()) return true;
    //        }
    //    }
    //    return false;
    //}
    //public bool prostyatakwarunek3(int Number, int Letter)
    //{
    //    for (int i = Number + 1; i < Board.Length; i++)
    //    {
    //        if (IsChessman(i, Letter)?.GetComponent<EnemyTower>()) return true;
    //        else if (IsChessman(i, Letter)?.GetComponent<EnemyHetman>()) return true;
    //    }
    //    return false;
    //}
    //public Transform IsChessman( int i, int j)
    //{
    //
    //    if (Board[i].GetChild(j).childCount == 1)
    //        return Board[i].GetChild(j).GetChild(0);
    //
    //    return null;
    //}
}