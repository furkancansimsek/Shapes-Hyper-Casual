using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereAmI : MonoBehaviour
{
    public Transform[] bases;
    Vector3 konum;
    public GameObject bulletType;

    void Update()
    {
        
    }

    public void WhoIs(int kolon)
    {
        switch (kolon)
        {
            case 1:
                konum = new Vector3(-3,0,3);
                break;
            case 2:
                konum = new Vector3(0, 0, 3);
                break;
            case 3:
                konum = new Vector3(3, 0, 3);
                break;
        }
        for (int i = 0; i < bases.Length; i++)
        {
            if (bases[i].transform.position == konum)
            {
                bulletType = bases[i].gameObject;
            }
        }
    }
}
