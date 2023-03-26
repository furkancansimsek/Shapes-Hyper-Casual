using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 50;
    Text pointText;
    Controller controllerScript;

     void Start()
    {
        Destroy(gameObject,10f);
        pointText = GameObject.Find("Point").GetComponent<Text>();
        controllerScript = GameObject.Find("GameController").GetComponent<Controller>();
    }
    void Update()
    {
        transform.position += Vector3.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            controllerScript.point++;
            pointText.text = controllerScript.point.ToString();
        }
        else if (other.gameObject.tag != "Base")
        {
            SceneManager.LoadScene(0);
        }
    }
}
