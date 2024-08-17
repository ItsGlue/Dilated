using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePoint : MonoBehaviour
{
    private CircleCollider2D col;

    [SerializeField]
    private GameObject player;

    private Vector2 savedVelocity;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && col.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            savedVelocity = player.GetComponent<Rigidbody2D>().velocity;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (Input.GetMouseButtonUp(0)) {
            player.GetComponent<Rigidbody2D>().isKinematic = false;
            player.GetComponent<Rigidbody2D>().velocity = savedVelocity;
        }
    }
}
