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
    public LayerMask MovPlat;
    //Fin lista de publicos
    List<Rigidbody2D> players = new List<Rigidbody2D>();
    List<Color> colors = new List<Color>();
    List<Color> originalColors = new List<Color>();
    List<SpriteRenderer> renderers = new List<SpriteRenderer>();
    List<Transform> groundCheck = new List<Transform>();

    const float grv = 2.4f;
    const float DRAG_COEFFICIENT = 0.87f;
    const float MULT = 3.0F;
    const float SPEED_X = 1000.0F * MULT;
    const float SPEED_Y = 550.0F * MULT;
    List<Animator> animations = new List<Animator>();
    public int playerChosen = 0;
    const float MAX_VELOCITY_X = 3.8F;
    const float MAX_VELOCITY_Y = 7.0F;
    const float DARKER = 0.6F;
    bool grounded, landed, meow, grd;

    //Audios

    AudioManager am;
    bool rojosonando = false;
    bool azulsonando = false;
    bool blancosonando = false;
    // Start is called before the first frame update
    void Start()
    {
        players.Add(Player1.GetComponent<Rigidbody2D>());
        renderers.Add(Player1.GetComponent<SpriteRenderer>());
        colors.Add(Player1.GetComponent<SpriteRenderer>().color);
        animations.Add(Player1.GetComponent<Animator>());
        players.Add(Player2.GetComponent<Rigidbody2D>());
        renderers.Add(Player2.GetComponent<SpriteRenderer>());
        colors.Add(Player2.GetComponent<SpriteRenderer>().color);
        animations.Add(Player2.GetComponent<Animator>());
        players.Add(Player3.GetComponent<Rigidbody2D>());
        renderers.Add(Player3.GetComponent<SpriteRenderer>());
        colors.Add(Player3.GetComponent<SpriteRenderer>().color);
        animations.Add(Player3.GetComponent<Animator>());

        players.ForEach((item) =>
        {
            item.gravityScale = grv;
        });

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
                colors[i] = originalColors[i] * DARKER;

            renderers[i].color = colors[i];
        }
        groundCheck.Add(gCheck1);
        groundCheck.Add(gCheck2);
        groundCheck.Add(gCheck3);

        //Definición audioManager

        am = FindObjectOfType<AudioManager>();
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
                    colors[i] = originalColors[i] * DARKER;

                renderers[i].color = colors[i];
            }

            am.StopPlaying("PasoRojo");
            am.StopPlaying("PasoBlanco");
            am.StopPlaying("PasoAzul");
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
        meow = Physics2D.OverlapCircle(groundCheck[playerChosen].position, 0.02f, MovPlat);
        grd = grounded || landed || meow;
        //Debug.Log(landed);
        //Debug.Log(grd + " AAAAAAA");
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            renderers[playerChosen].flipX = true;
            //players[playerChosen].drag = 0.2f;
            players[playerChosen].AddForce(new Vector2(-SPEED_X * Time.deltaTime, 0));
            if (players[playerChosen].velocity.x <= -MAX_VELOCITY_X) { players[playerChosen].velocity = new Vector2(-MAX_VELOCITY_X, players[playerChosen].velocity.y); }
        }
        //right
        if (Input.GetKey("right") || Input.GetKey("d"))
        {

            //players[playerChosen].drag = 0.2f;
            players[playerChosen].AddForce(new Vector2(SPEED_X * Time.deltaTime, 0));
            if (players[playerChosen].velocity.x >= MAX_VELOCITY_X) { players[playerChosen].velocity = new Vector2(MAX_VELOCITY_X, players[playerChosen].velocity.y); }

            //Animation zone
            renderers[playerChosen].flipX = false;
        }
    
        if ((Input.GetKey("up") || Input.GetKey("w")) && grd)
        {
            //players[playerChosen].drag = 0.2f;
            players[playerChosen].velocity = new Vector2(players[playerChosen].velocity.x, 0);
            players[playerChosen].AddForce(new Vector2(0, SPEED_Y), ForceMode2D.Force);
            //if (rb.velocity.y >= 15) { rb.velocity = new Vector2(rb.velocity.y,15f); }
            //grounded = false;
        }

        //ANIMATION ZONE
        for (int i = 1; i < 3; i++)
        {
            animations[i].SetFloat("speed", Mathf.Abs(players[i].velocity.x));
            if (!(players[i].velocity.y > -0.1 && players[i].velocity.y < 0.1))
            {
                animations[i].SetBool("jump", true);
            }
            else
            {
                animations[i].SetBool("jump", false);
            }
        }
        //FIN ANIMATION ZONE 

        //SOUND ZONE
        if (Input.GetKey("right") || Input.GetKey("d") || Input.GetKey("left") || Input.GetKey("a"))
        {
            if (playerChosen == 0 || grd)
            {
                if (playerChosen == 0 && rojosonando == false)
                {
                    am.Play("PasoRojo");
                    rojosonando = true;
                }
                if (playerChosen == 1 && azulsonando == false)
                {
                    am.Play("PasoAzul");
                    azulsonando = true;
                }
                if (playerChosen == 2 && blancosonando == false)
                {
                    am.Play("PasoBlanco");
                    blancosonando = true;
                }
            }
        }
        for (int i= 0; i<3; i++){
            if (Mathf.Abs(players[i].velocity.x) <= 0.1 || (grd == false && playerChosen!=0) )
            {
                if (i == 0)
                {
                    am.StopPlaying("PasoRojo");
                    rojosonando = false;
                }
                if (i == 1)
                {
                    am.StopPlaying("PasoAzul");
                    azulsonando = false;
                }
                if (i == 2)
                {
                    am.StopPlaying("PasoBlanco");
                    blancosonando = false;
                }
            }
        }
        //FIN SOUND ZONE
        if (!Input.anyKey || !grd)
        {
            players[playerChosen].velocity = new Vector2(players[playerChosen].velocity.x * DRAG_COEFFICIENT, players[playerChosen].velocity.y);
        }
        //if((Input.GetKeyUp("up") || Input.GetKeyUp("w")) && players[playerChosen].velocity.y > 0 && !grd) players[playerChosen].velocity = new Vector2(players[playerChosen].velocity.x , players[playerChosen].velocity.y* DRAG_COEFFICIENT);
        
    }
}
