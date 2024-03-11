using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field2 : MonoBehaviour
{
    static Save save;
    int ClickedNumber;
    int ClickedLetter;
    public enum Letter
    {
        A = 0, B, C, D, E, F, G, H
    }

    [SerializeField]
    private Letter letter;

    private void Awake()
    {
        save = transform.parent.parent.GetComponent<Save>();
    }


    void OnMouseDown()
    {
        if (transform.childCount == 0)
        {
            ClickedNumber = transform.parent.GetComponent<Row>().distanceNumber;
            ClickedLetter = (int)letter;
            if (save.last() != null)
                Instantiate(save.last(), transform);

        }
        else Destroy(transform.GetChild(0).gameObject);


    }
}
