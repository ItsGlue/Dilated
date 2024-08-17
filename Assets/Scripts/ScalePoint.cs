using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePoint : MonoBehaviour
{
    private CircleCollider2D col;

    [SerializeField]
    private GameObject player;

    private Vector2 savedVelocity;
    private bool scaling;
    private Vector3 prevPosition;
    private float scaleFactor = 0.03f;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        scaling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && col.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            savedVelocity = player.GetComponent<Rigidbody2D>().velocity;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.SendMessage("Control", false);
            scaling = true;
            prevPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) {
            player.GetComponent<Rigidbody2D>().isKinematic = false;
            player.GetComponent<Rigidbody2D>().velocity = savedVelocity;
            player.SendMessage("Control", true);
            scaling = false;
        }
        if (scaling) {
            Vector2 mouse = Input.mousePosition - prevPosition;
            Vector2 playerVec = player.transform.position - transform.position;
            float dist = mouse.magnitude * Mathf.Cos(Vector2.Angle(mouse, playerVec) * Mathf.Deg2Rad);
            player.transform.Translate(-playerVec.normalized * dist * scaleFactor);
            player.transform.localScale *= (player.transform.position - transform.position).magnitude/playerVec.magnitude;
            prevPosition = Input.mousePosition;
        }
    }
}
