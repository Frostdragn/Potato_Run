using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMan : MonoBehaviour
{
    private Rigidbody2D _body;
    private BoxCollider2D _box;
    private Animator _anim;

    public bool bombCollected = false;
    public bool spawnObstacles = true;

    public GameObject UI;
    public GameObject zButton;
    public GameObject bomb;
    public GameObject coin;

    public Vector3 bombStartPos;

    float timer = 0;

    public int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        Vector3 bombStartPos = new Vector3(Random.Range(50.0f, 80.0f), Random.Range(-1.5f, 2.5f), 0);

        //_anim.SetFloat("speed", 0);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                _body.AddForce(Vector2.up * 350);
            }
        }

        if (timer <= 2.1)
        {
            timer += Time.deltaTime;
        }

        if (Input.GetKeyDown("z") && bombCollected == true)
        {
            timer = 0;
            Debug.Log("Z pressed");
            bombCollected = false;
            spawnObstacles = false;
            bomb.SetActive(true);
        }

        if (timer >= 2)
        {
            spawnObstacles = true;
        }

        if (bombCollected == false)
        {
            UI.SetActive(false);
            zButton.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
            zButton.SetActive(true);
            bomb.SetActive(false);
            bomb.transform.position = bombStartPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        if (collision.tag == "Bomb")
        {
            bombCollected = true;
            Debug.Log("Bomb get!");
        }

        if (collision.tag == "Coin")
        {
            coins = coins + 1;
            Debug.Log("Coins = " + coins);
            //coin.SetActive(false);
        }
    }
}
