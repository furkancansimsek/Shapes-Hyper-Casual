using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    GameObject target;
    bool isChoosen;
    public Vector3 firstPos;
    Vector2 mouseP;
    public WhereAmI whereAmIScript;
    public int whereMyObject;
    Vector3 lastPos;
    public int point;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "CubeBase" && !isChoosen)
                {
                    mouseP = Input.mousePosition;
                    target = GameObject.Find("CubeBase");
                    isChoosen = true;
                    firstPos = GameObject.Find("CubeBase").transform.position;
                    WhereMyObj();
                }
                if (hit.transform.name == "TriangleBase" && !isChoosen)
                {
                    mouseP = Input.mousePosition;
                    target = GameObject.Find("TriangleBase");
                    isChoosen = true;
                    firstPos = GameObject.Find("TriangleBase").transform.position;
                    WhereMyObj();
                }
                if (hit.transform.name == "CircleBase" && !isChoosen)
                {
                    mouseP = Input.mousePosition;
                    target = GameObject.Find("CircleBase");
                    isChoosen = true;
                    firstPos = GameObject.Find("CircleBase").transform.position;
                    WhereMyObj();
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 lastMouseP = Input.mousePosition;
            Ray rayLast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitLast;
            if (Physics.Raycast(rayLast, out hitLast))
            {
                if (hitLast.transform.name == "CircleBase" || hitLast.transform.name == "TriangleBase" || hitLast.transform.name == "CubeBase")
                {
                    Vector3 secondObj = hitLast.transform.position;
                    hitLast.transform.position = firstPos;
                    target.transform.position = secondObj;
                    if (target.transform.position == hitLast.transform.position)
                    {
                        Shoot();
                    }
                }
            }
            isChoosen = false;
        }
    }

    void WhereMyObj()
    {
        if (firstPos == new Vector3(-3,0,3))
        {
            whereMyObject = 1;
        }
        else if (firstPos == new Vector3(0, 0, 3))
        {
            whereMyObject = 2;
        }
        else if (firstPos == new Vector3(3, 0, 3))
        {
            whereMyObject = 3;
        }
    }

    void Shoot()
    {
        WhereMyObj();
        whereAmIScript.WhoIs(whereMyObject);
        GameObject spawn = Instantiate(whereAmIScript.bulletType, target.transform.position, Quaternion.Euler(0,-180,0));
        spawn.GetComponent<BoxCollider>().size = new Vector3(2,0,0);
        if (spawn.name == "CubeBase(Clone)")
        {
            spawn.transform.tag = "Blue";
        }
        else if (spawn.name == "TriangleBase(Clone)")
        {
            spawn.gameObject.tag = "Red";
        }
        else if (spawn.name == "CircleBase(Clone)")
        {
            spawn.gameObject.tag = "Green";
        }
        spawn.AddComponent<Bullet>();
    }
}
