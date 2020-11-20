using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 _startPos;

    public float speed = -7;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject spawnDeath = GameObject.Find("potato_man_1");
        PotatoMan potatoScript = spawnDeath.GetComponent<PotatoMan>();

        if (potatoScript.spawnObstacles == false)
        {
            transform.position = _startPos;
            speed = 0;
        }
        else
        {
            speed = -7;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);

        if(transform.position.x <= -10.5)
        {
            transform.position = _startPos;
        }
    }
}
