using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    //Lista de publicos programables desde unity
    public GameObject Player1; public GameObject Player2; public GameObject Player3;
    public Transform gCheck1; public Transform gCheck2; public Transform gCheck3;
    public LayerMask ground;
    //Fin lista de públicos
    List<Rigidbody2D> players = new List<Rigidbody2D>();
    List<Transform> groundCheck = new List<Transform>();
    int playerChosen = 0;
    bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        players.Add(Player1.GetComponent<Rigidbody2D>());
        players.Add(Player2.GetComponent<Rigidbody2D>());
        players.Add(Player3.GetComponent<Rigidbody2D>());
        groundCheck.Add(gCheck1);
        groundCheck.Add(gCheck2);
        groundCheck.Add(gCheck3);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp("c"))
        {
            playerChosen++;
            if (playerChosen > 2) playerChosen = 0;
            Debug.Log(playerChosen);
        }
       
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck[playerChosen].position, 0.02f, ground);
        Debug.Log(grounded);
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            players[playerChosen].AddForce(new Vector2(-2000f * Time.deltaTime, 0));
            if (players[playerChosen].velocity.x <= -10) { players[playerChosen].velocity = new Vector2(-10f, players[playerChosen].velocity.y); }
        }
        //right
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            players[playerChosen].AddForce(new Vector2(2000f * Time.deltaTime, 0));
            if (players[playerChosen].velocity.x >= 10) { players[playerChosen].velocity = new Vector2(10f, players[playerChosen].velocity.y); }
        }
        if (Input.GetKey("w") && grounded == true)
        {
            players[playerChosen].velocity = new Vector2(players[playerChosen].velocity.x, 0);
            players[playerChosen].AddForce(new Vector2(0, 400), ForceMode2D.Force);
            //if (rb.velocity.y >= 15) { rb.velocity = new Vector2(rb.velocity.y,15f); }
            //grounded = false;
        }
    }

}
