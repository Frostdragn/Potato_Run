using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector3 _startPos;
    public int coins = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _startPos = new Vector3(Random.Range(50.0f, 80.0f), Random.Range(-1.5f, 2.5f), 0);
        transform.Translate(-7 * Time.deltaTime, 0, 0);

        if (transform.position.x <= -10.5)
        {
            transform.position = _startPos;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        if (collision)
        {
            coins = coins + 1;
            Debug.Log("Coins = " + coins);
            gameObject.SetActive(false);
        }
    }
}
