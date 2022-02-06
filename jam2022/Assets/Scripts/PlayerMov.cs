using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMov : MonoBehaviour
{
    //Lista de publicos programables desde unity
    public GameObject Player1; public GameObject Player2; public GameObject Player3;
    public Transform gCheck1; public Transform gCheck2; public Transform gCheck3;
    public LayerMask ground;
    public LayerMask interact;
    //Fin lista de publicos
    List<Rigidbody2D> players = new List<Rigidbody2D>();
    List<Color> colors = new List<Color>();
    List<Color> originalColors = new List<Color>();
    List<SpriteRenderer> renderers = new List<SpriteRenderer>();
    List<Transform> groundCheck = new List<Transform>();
    int playerChosen = 1;
    const float MAX_VELOCITY_X = 7.0F;
    const float DARKER = 0.5F;
    bool grounded, landed, grd;
    // Start is called before the first frame update
    void Start()
    {
        players.Add(Player1.GetComponent<Rigidbody2D>());
        renderers.Add(Player1.GetComponent<SpriteRenderer>());
        colors.Add(Player1.GetComponent<SpriteRenderer>().color);
        players.Add(Player2.GetComponent<Rigidbody2D>());
        renderers.Add(Player2.GetComponent<SpriteRenderer>());
        colors.Add(Player2.GetComponent<SpriteRenderer>().color);
        players.Add(Player3.GetComponent<Rigidbody2D>());
        renderers.Add(Player3.GetComponent<SpriteRenderer>());
        colors.Add(Player3.GetComponent<SpriteRenderer>().color);

        colors.ForEach((item) =>
        {
            originalColors.Add(new Color(item.r, item.g, item.b, item.a));
        });

        for (int i = 0; i < colors.Count; i++)
        {
            if (i == playerChosen)
            {
                colors[i] = originalColors[i];
            }
            else
                colors[i] = originalColors[i]*DARKER;

            renderers[i].color = colors[i];
        }
        groundCheck.Add(gCheck1);
        groundCheck.Add(gCheck2);
        groundCheck.Add(gCheck3);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("j"))
        {
            playerChosen++;
            if (playerChosen > 2) playerChosen = 0;
            Debug.Log(playerChosen);
        }

        if (Input.GetKeyDown("k"))
        {
            playerChosen--;
            if (playerChosen < 0) playerChosen = 2;
            Debug.Log(playerChosen);
        }

        if (Input.GetKeyDown("j") || Input.GetKeyDown("k"))
        {
            for (int i = 0; i < colors.Count; i++)
            {
                if (i == playerChosen)
                {
                    colors[i] = originalColors[i];
                }
                else
                    colors[i] = originalColors[i]*DARKER;

                renderers[i].color = colors[i];
            }
        }

        if (Input.GetKeyUp("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    void FixedUpdate()
    {
        //players[playerChosen].drag = 10;
        grounded = Physics2D.OverlapCircle(groundCheck[playerChosen].position, 0.02f, ground);
        landed = Physics2D.OverlapCircle(groundCheck[playerChosen].position, 0.02f, interact);
        grd = grounded || landed;
        Debug.Log(landed);
        Debug.Log(grounded);
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            //players[playerChosen].drag = 0.2f;
            players[playerChosen].AddForce(new Vector2(-1000f * Time.deltaTime, 0));
            if (players[playerChosen].velocity.x <= -MAX_VELOCITY_X) { players[playerChosen].velocity = new Vector2(-MAX_VELOCITY_X, players[playerChosen].velocity.y); }
        }
        //right
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            //players[playerChosen].drag = 0.2f;
            players[playerChosen].AddForce(new Vector2(1000f * Time.deltaTime, 0));
            if (players[playerChosen].velocity.x >= MAX_VELOCITY_X) { players[playerChosen].velocity = new Vector2(MAX_VELOCITY_X, players[playerChosen].velocity.y); }
        }
        if (Input.GetKey("up") || Input.GetKey("w") && (grd))
        {
            //players[playerChosen].drag = 0.2f;
            players[playerChosen].velocity = new Vector2(players[playerChosen].velocity.x, 0);
            players[playerChosen].AddForce(new Vector2(0, 400), ForceMode2D.Force);
            //if (rb.velocity.y >= 15) { rb.velocity = new Vector2(rb.velocity.y,15f); }
            //grounded = false;
        }
        if (!Input.anyKey || !grd)
        {
            players[playerChosen].velocity = new Vector2(players[playerChosen].velocity.x * 0.95f, players[playerChosen].velocity.y);
        }
        


    }

}
