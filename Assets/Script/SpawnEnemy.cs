using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    string LastEnemyName;
    Transform LastEnemyTransform;
    int LastEnemyLetter;
    public Transform[] Enemy;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space))GetComponent<FieldMove>().Speed=100;
    }
    public void Spawn(Transform Fields){
        Transform Field;
        //Random.Range(0,3)==0
        if(true){
            while(true){
                Field=Fields.GetChild(Random.Range(0,Fields.childCount));
                Instantiate(Enemy[Random.Range(0,Enemy.Length)], new Vector3(Field.position.x,Field.position.y,-1),Field.rotation).SetParent(Field);
                if(LastEnemyName=="Hetman(Clone)" 
                && Field.GetChild(0).name=="Hetman(Clone)"
                &&(LastEnemyLetter==Field.GetSiblingIndex() 
                || LastEnemyLetter==Field.GetSiblingIndex()+1 
                || LastEnemyLetter==Field.GetSiblingIndex()-1)){
                    Debug.Log("Double");
                    //Fields.parent.GetComponent<FieldMove>().Speed=0;
                    //Destroy(Field.GetChild(0).gameObject);
                    
                    break;
                }
                    
                else if(LastEnemyName=="Tower(Clone)" 
                && Field.GetChild(0).name=="Tower(Clone)" 
                && LastEnemyLetter==Field.GetSiblingIndex()){
                    Debug.Log("Double");
                    //Fields.parent.GetComponent<FieldMove>().Speed=0;

                   //Destroy(Field.GetChild(0).gameObject);
                    
                    break;
                }
                else if(LastEnemyName=="Tower(Clone)" 
                && Field.GetChild(0).name=="Hetman(Clone)" 
                && LastEnemyLetter==Field.GetSiblingIndex()){
                    Debug.Log("Double");
                    //Fields.parent.GetComponent<FieldMove>().Speed=0;
                    
                    //Destroy(Field.GetChild(0).gameObject);
                    
                    break;
                }
                else if(LastEnemyName=="Hetman(Clone)" 
                && Field.GetChild(0).name=="Tower(Clone)" 
                && LastEnemyLetter==Field.GetSiblingIndex()){
                    Debug.Log("Double");
                    //Fields.parent.GetComponent<FieldMove>().Speed=0;
                    
                    //Destroy(Field.GetChild(0).gameObject);
                    
                    break;
                }
                // //
                
                else{
                    LastEnemyLetter=Field.GetSiblingIndex();
                    LastEnemyName=Field.GetChild(0).name;
                    LastEnemyTransform=Field.GetChild(0);

                    break;
                }
            }
            if((LastEnemyName=="Hetman(Clone)" || LastEnemyName=="Tower(Clone)") 
            && (Field.GetChild(0).name=="Hetman(Clone)"  || Field.GetChild(0).name=="Tower(Clone)" ))
                Field.GetChild(0).GetComponent<BlockedCrossing>().enabled=true;
        }
        // else{
        //     LastEnemyName="";
        // }
    }
}