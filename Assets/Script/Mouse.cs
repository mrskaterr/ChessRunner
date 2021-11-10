using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mouse : MonoBehaviour
{
  [SerializeField] Transform Knight;
  int KnightNumber;
  int ClickedNumber;
  int KnightLetter;
  int ClickedLetter;
  void OnMouseDown()
  {
    KnightNumber=int.Parse(Knight.parent.parent.name);
    ClickedNumber=int.Parse(this.gameObject.transform.parent.name);
    KnightLetter=Knight.parent.GetSiblingIndex();
    ClickedLetter=this.gameObject.transform.GetSiblingIndex();
    if(this.gameObject.transform.position.y<9.5f){
      if((KnightNumber+1==ClickedNumber || KnightNumber-1==ClickedNumber) 
      && (KnightLetter+2==ClickedLetter || KnightLetter-2==ClickedLetter))
      Knight.SetParent(this.gameObject.transform);
      else if((KnightNumber+2==ClickedNumber || KnightNumber-2==ClickedNumber) 
      && (KnightLetter-1==ClickedLetter || KnightLetter+1==ClickedLetter))
      Knight.SetParent(this.gameObject.transform);  
    }
  }  
}