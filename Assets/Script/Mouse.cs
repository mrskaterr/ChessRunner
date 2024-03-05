using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
  [SerializeField] Transform Knight;
  int PlayerNumber;
  int ClickedNumber;
  int PlayerLetter;
  int ClickedLetter;
  void OnMouseDown()
  {
    PlayerNumber=int.Parse(Knight.parent.parent.name);
    ClickedNumber=int.Parse(this.gameObject.transform.parent.name);
    PlayerLetter=Knight.parent.GetSiblingIndex();
    ClickedLetter=this.gameObject.transform.GetSiblingIndex();
    if(this.gameObject.transform.position.y<9.5f){
      if((PlayerNumber+1==ClickedNumber || PlayerNumber-1==ClickedNumber) 
      && (PlayerLetter+2==ClickedLetter || PlayerLetter-2==ClickedLetter))
      Knight.SetParent(this.gameObject.transform);
      else if((PlayerNumber+2==ClickedNumber || PlayerNumber-2==ClickedNumber) 
      && (PlayerLetter-1==ClickedLetter || PlayerLetter+1==ClickedLetter))
      Knight.SetParent(this.gameObject.transform);  
    }
    //Bishop
    // if(this.gameObject.transform.position.y<9.5f){
      
    //   if(Mathf.Abs(ClickedNumber-KnightNumber) == Mathf.Abs(ClickedLetter-KnightLetter))
    //     Knight.SetParent(this.gameObject.transform);
    // } 
  }  
}