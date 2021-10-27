using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mouse : MonoBehaviour
{
  Transform Knight;
  int KnightNumber;
  int ClickedNumber;
  char KnightLetter;
  char ClickedLetter;

  // Start is called before the first frame update
  void Start()
  {
    Knight=gameObject.transform.parent.parent.GetChild(0).GetChild(0).GetChild(0).transform;
  }
  void OnMouseDown()
  {
    KnightNumber=int.Parse(Knight.parent.parent.name);
    ClickedNumber=int.Parse(this.gameObject.transform.parent.name);
    KnightLetter=Knight.parent.name[0];
    ClickedLetter=this.gameObject.name[0];

    if((KnightNumber+1==ClickedNumber || KnightNumber-1==ClickedNumber) 
    && (KnightLetter+2==ClickedLetter || KnightLetter-2==ClickedLetter))
      Knight.SetParent(this.gameObject.transform);
    if((KnightNumber+2==ClickedNumber || KnightNumber-2==ClickedNumber) 
    && (KnightLetter-1==ClickedLetter || KnightLetter+1==ClickedLetter))
      Knight.SetParent(this.gameObject.transform);
  }  
}