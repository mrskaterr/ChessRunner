using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    public int HetmanMinDistance;
    public int TowerMinDistance;
    public int BishopMinDistance;
    public int KnightMinDistance;
    int LastHetmanDistance;
    int LastTowerDistance;
    int LastBishopDistance;
    int LastKnightDistance;
    int SpawnZ=-1;
    int RND;
    public Transform[] Enemy;
    void Start()
    {
        LastHetmanDistance=HetmanMinDistance;
        LastTowerDistance=TowerMinDistance;
        LastBishopDistance=BishopMinDistance;
        LastKnightDistance=KnightMinDistance;
    }
    public void Spawn(Transform Fields)
    {
        Transform Field;
        Field=Fields.GetChild(Random.Range(0,Fields.childCount));
        while(true)
        {
            RND=Random.Range(0,Enemy.Length);

            if (Enemy[RND].gameObject.activeSelf)
                break;
            if(Enemy[RND].GetComponent<EnemyHetman>() && LastHetmanDistance>=HetmanMinDistance && LastTowerDistance>1)
            {
                Enemy[RND].SetParent(Field);
                Enemy[RND].gameObject.SetActive(true);
                LastHetmanDistance = 0;
            }
            if(Enemy[RND].GetComponent<EnemyTower>() && LastTowerDistance>=TowerMinDistance && LastHetmanDistance>1)
            {
                Enemy[RND].SetParent(Field);
                Enemy[RND].gameObject.SetActive(true);
                LastTowerDistance = 0;
            }
            if(Enemy[RND].GetComponent<EnemyBishop>() && LastBishopDistance>=BishopMinDistance)
            {
                Enemy[RND].SetParent(Field);
                Enemy[RND].gameObject.SetActive(true);
                LastBishopDistance = 0;
            }
            if(Enemy[RND].GetComponent<EnemyKnight>() && LastKnightDistance>=KnightMinDistance)
            {
                Enemy[RND].SetParent(Field);
                Enemy[RND].gameObject.SetActive(true);
                LastKnightDistance =  0;
            }
            if(Enemy[RND].GetComponent<EnemyPawn>())
            {
                Enemy[RND].SetParent(Field);
                Enemy[RND].gameObject.SetActive(true);
            }
            break;
        }
        LastHetmanDistance++;
        LastTowerDistance++;
        LastBishopDistance++;
        LastKnightDistance++;
    }
}