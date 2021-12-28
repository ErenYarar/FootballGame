using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;

    Vector3 dragStartPos;
    Touch touch;

    //Ball ground hit count
    private int ballHit = 0;

    //Particle 
    public GameObject ps;

    //Stay on the ground count
    public int ballGroundCount = 11;

    int ballGroundCountForText = 0;
    bool isBallGrouded = false;
    public Text ballground_text;


    //Total Ball count
    public int total_ball_Count = 3;

    //Balls
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;

    //CountDown 
    public Image ball1StrikeImage;
    public Image ball2StrikeImage;
    public Image ball3StrikeImage;
    public Button restart_btn;
    public Button menu_btn;
    public Button store_btn;
    public Text timer_Text;
    public float first_timeRemaining = 3;
    public float second_timeRemaining = 3;
    public bool first_timerIsRunning = false;
    public bool second_timerIsRunning = false;

    //Gol Screen
    //public Image GollImage;
    public GolScore gollscore;
    public Text Goll_Text;

    private void Start()
    {
        ball1StrikeImage.gameObject.SetActive(false);
        ball2StrikeImage.gameObject.SetActive(false);
        ball3StrikeImage.gameObject.SetActive(false);
        restart_btn.gameObject.SetActive(false);
        menu_btn.gameObject.SetActive(false);
        store_btn.gameObject.SetActive(false);
        ps.SetActive(false);
        first_timerIsRunning = false;
        second_timerIsRunning = false;

        isBallGrouded = false;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }

        StartGame();
        ShowBallGroundedCount();
    }

    void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }
    void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
        SoundManager.instance.BouncingSound();
    }
    void DragRelease()
    {
        lr.positionCount = 0;

        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;

        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
    }

    void StartGame()
    {
        if (first_timerIsRunning == true)
        {
            if (first_timeRemaining > 0)
            {
                first_timeRemaining -= Time.unscaledDeltaTime;
                timer_Text.text = first_timeRemaining.ToString("0");
            }
            else
            {
                first_timeRemaining = 0;
                first_timerIsRunning = false;

                timer_Text.gameObject.SetActive(false);
                ball1StrikeImage.gameObject.SetActive(false);
                ball2StrikeImage.gameObject.SetActive(false);
                ball3StrikeImage.gameObject.SetActive(false);
                if (Time.timeScale == 0)
                    Time.timeScale = 1;
            }
        }
        if (second_timerIsRunning == true)
        {
            if (second_timeRemaining > 0)
            {
                second_timeRemaining -= Time.unscaledDeltaTime;
                timer_Text.text = second_timeRemaining.ToString("0");
            }
            else
            {
                second_timeRemaining = 0;
                second_timerIsRunning = false;

                timer_Text.gameObject.SetActive(false);
                ball1StrikeImage.gameObject.SetActive(false);
                ball2StrikeImage.gameObject.SetActive(false);
                ball3StrikeImage.gameObject.SetActive(false);
                if (Time.timeScale == 0)
                    Time.timeScale = 1;
            }
        }
    }

    void ShowBallGroundedCount()
    {
        if (isBallGrouded == true)
        {
            if (ballGroundCountForText > 0)
            {
                ballground_text.text = ballGroundCountForText.ToString();
            }
            else
            {
                ballGroundCountForText = 0;
            }
        }
        else
        {
            isBallGrouded = false;
            ballground_text.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "isGrounded")
        {
            ballHit++;
            if (ballHit > 1)
            {
                ballGroundCount -= 1; // 11

                ballGroundCountForText += 1;
                isBallGrouded = true;
                ballground_text.gameObject.SetActive(true);

                if (ballGroundCount == 8)
                {
                    ballGroundCountForText = 0;

                    transform.position = new Vector3(0.02f, -4.5f, 0f);
                    total_ball_Count -= 1;

                    // 
                    isBallGrouded = false;
                    ballground_text.gameObject.SetActive(false);


                    Goll_Text.gameObject.SetActive(false); //Goll text cancel

                    Destroy(ball1);
                    Debug.Log("1. top bitti");

                    Time.timeScale = 0;
                    first_timerIsRunning = true;
                    timer_Text.gameObject.SetActive(true);
                    ball1StrikeImage.gameObject.SetActive(true);

                    SoundManager.instance.DeathSound();
                    SoundManager.instance.CountdownSound();

                    ball2.SetActive(true);
                }

                if (ballGroundCount == 4)
                {
                    ballGroundCountForText = 0;
                    transform.position = new Vector3(0.02f, -4.5f, 0f);
                    total_ball_Count -= 1;

                    //
                    isBallGrouded = false;
                    ballground_text.gameObject.SetActive(false);


                    Goll_Text.gameObject.SetActive(false); //Goll text cancel

                    Destroy(ball2);
                    Debug.Log("2. top bitti");

                    Time.timeScale = 0;
                    second_timerIsRunning = true;
                    timer_Text.gameObject.SetActive(true);
                    ball1StrikeImage.gameObject.SetActive(false);
                    ball2StrikeImage.gameObject.SetActive(true);

                    SoundManager.instance.DeathSound();
                    SoundManager.instance.CountdownSound();

                    ball3.SetActive(true);
                }

                if (ballGroundCount == 0)
                {
                    Time.timeScale = 0;
                    //Game Over Text
                    //Restart - Menü Button
                    //
                    ballGroundCountForText = 0;

                    isBallGrouded = false;
                    ballground_text.gameObject.SetActive(false);

                    Goll_Text.gameObject.SetActive(false); //Goll text cancel

                    gollscore.highscoretext.gameObject.SetActive(true); // HighScore

                    ball2StrikeImage.gameObject.SetActive(false);
                    ball3StrikeImage.gameObject.SetActive(true);

                    restart_btn.gameObject.SetActive(true);
                    menu_btn.gameObject.SetActive(true);
                    store_btn.gameObject.SetActive(true);

                    if (ballGroundCount < 0)
                    {
                        ballGroundCount = 0;
                    }
                    total_ball_Count -= 1;
                    Destroy(ball3);
                    Debug.Log("Oyun Bitti!");

                    SoundManager.instance.DeathSound();
                    SoundManager.instance.GameOverSound();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "gollField")
        {
            Debug.Log("Goll !!");
            ps.SetActive(true);
            //gameObject.SetActive(false);
            //var em = ps.emission;
            //em.enabled = true;
            //ps.Play();

            ballGroundCount += 1;
            ballGroundCountForText = 0;

            gollscore.scoreNum += 1;
            gollscore.myscoreText.text = "" + gollscore.scoreNum;
            StartCoroutine(GollTextTimer());

            transform.position = new Vector3(0.02f, -4.5f, 0f);

            //if (transform.hasChanged)
            //{
            //    print("The transform has changed!");
            //    transform.hasChanged = false;
            //    ps.SetActive(false);
            //}
            SoundManager.instance.GoollSound();

        }

        if (target.gameObject.tag == "destroyer_line")
        {
            transform.position = new Vector3(0.02f, -4.5f, 0f);
        }
    }

    IEnumerator GollTextTimer()
    {
        Goll_Text.gameObject.SetActive(true);
        //Sound
        yield return new WaitForSeconds(2f);
        Goll_Text.gameObject.SetActive(false);

    }
}
