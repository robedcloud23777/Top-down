using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed;
    public GameManager manager;

    float h, v;
    Rigidbody2D rb;
    Animator anim;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = manager.isAciton ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAciton ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAciton ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAciton ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAciton ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAciton ? false : Input.GetButtonUp("Vertical");

        if (hDown || vUp) isHorizonMove = true;
        else if (vDown || hUp) isHorizonMove = false;
        else if (hUp || vUp) isHorizonMove = h != 0;

        //Animation
        if (anim.GetInteger("hAxisRaw") != h) {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }else if(anim.GetInteger("vAxisRaw") != v){
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else anim.SetBool("isChange", false);

        //Direction
        if(vDown && v == 1) dirVec = Vector3.up;
        else if (vDown && v == -1) dirVec = Vector3.down;
        else if (hDown && h == -1) dirVec = Vector3.left;
        else if (hDown && h == 1) dirVec = Vector3.right;

        //Scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            manager.Action(scanObject);
        }
    }

    void FixedUpdate()
    {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rb.velocity = moveVec * speed;

        //Ray
        Debug.DrawRay(rb.position, dirVec * 0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rb.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else {
            scanObject = null; 
        }
    }
}
