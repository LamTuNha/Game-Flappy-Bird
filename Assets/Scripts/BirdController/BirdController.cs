using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;
    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive;
    private bool didFlap;

    private GameObject random;

    public float flag = 1;

    public int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        isAlive= true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _MakeInstance();
        random = GameObject.Find("Random Pipe");

    }
    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMoveMent();
    }

    void _BirdMoveMent()
    {
        if (isAlive)
        {
            if (didFlap)
            {
                didFlap= false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }
        if (myBody.velocity.y>0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0,90,myBody.velocity.y/7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }else if(myBody.velocity.y == 0) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }else if (myBody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    public void FlapButton()
    {
        didFlap = true;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder")
        {
            score++;
            if (GamePlay.instance != null)
            {
                GamePlay.instance._SetScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Floor")
        {
            flag = 0;
            if(isAlive)
            {
                isAlive = false;
                Destroy(random);
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");
            }
            if (GamePlay.instance != null)
            {
                GamePlay.instance._GameOverPanel(score);
            }

        }
    }
}
