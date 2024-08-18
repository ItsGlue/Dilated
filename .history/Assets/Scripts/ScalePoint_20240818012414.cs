using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePoint : MonoBehaviour
{
    private CircleCollider2D col;

    private GameObject player;

    private Vector2 savedVelocity;
    private bool scaling;
    private Vector3 prevPosition;
    private float scaleFactor = 0.03f;

    private Vector2 mouse;
    private Vector2 playerVec;
    private float ratio;
    public Sprite Active;
    public Sprite InActive;

    // Reference to the SpriteRenderer component of the GameObject
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        scaling = false;
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && col.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            savedVelocity = player.GetComponent<Rigidbody2D>().velocity;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.SendMessage("Control", false);
            scaling = true;
            prevPosition = Input.mousePosition;
            player.GetComponent<PlayerMovement>().currScalePoint = gameObject;
            player.AddComponent<SliderJoint2D>();
            player.GetComponent<Joint2D>().connectedBody = gameObject.GetComponent<Rigidbody2D>();
            ratio = player.transform.localScale.magnitude / (player.transform.position - transform.position).magnitude;
            Debug.Log(ratio);
        }
        if (Input.GetMouseButtonUp(0) && scaling) {
            player.GetComponent<Rigidbody2D>().gravityScale = player.transform.localScale.y;
            player.GetComponent<Rigidbody2D>().velocity = savedVelocity;
            player.SendMessage("Control", true);
            scaling = false;
            player.GetComponent<PlayerMovement>().currScalePoint = null;
            Destroy(player.GetComponent<SliderJoint2D>());
        }
        if (scaling) {
            mouse = Input.mousePosition - prevPosition;
            playerVec = player.transform.position - transform.position;
            float dist = mouse.magnitude * Mathf.Cos(Vector2.Angle(mouse, playerVec) * Mathf.Deg2Rad);
            if (dist > 0) {
                player.GetComponent<PlayerMovement>().direction = true;
            } else if (dist < 0){
                player.GetComponent<PlayerMovement>().direction = false;
            }
            if ((dist > 0 || player.GetComponent<PlayerMovement>().canOut) && (dist < 0 || player.GetComponent<PlayerMovement>().canIn)) {
                player.transform.Translate(-playerVec.normalized * Mathf.Clamp(dist * scaleFactor,-0.2f,0.2f));
                player.transform.localScale = player.transform.localScale.normalized * ratio * (player.transform.position - transform.position).magnitude;
                if (Vector2.Angle(player.transform.position - transform.position,playerVec) > 90) {
                    //player.transform.localScale *= -(player.transform.position - transform.position).magnitude/playerVec.magnitude;
                    Vector3 scaler = player.transform.localScale;
                    scaler.y *= -1;
                    scaler.z *= -1;
                    player.transform.localScale = scaler;
                } else {
                    //player.transform.localScale *= (player.transform.position - transform.position).magnitude/playerVec.magnitude;
                }
            }
            
            prevPosition = Input.mousePosition;
        }
    }

    public void ActiveSprite()
    {

            spriteRenderer.sprite = newSprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite is not assigned.");
        }
    }
}
