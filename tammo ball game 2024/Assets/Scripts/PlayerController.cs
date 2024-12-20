using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TMP_Text ScoreText;
    public TMP_Text WinText;
    public GameObject Wall;
    private Rigidbody rb;
    public int Score;
    public AudioSource source;
    public AudioClip pickupSound;
    public float SprintSpeed = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Score = 0;
        SetScoreText();
        WinText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement=new Vector3(moveHorizontal, 0.0f, moveVertical);

        

        //Reestart Level
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        //Quit Game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //Stop Player
        if(Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(movement * SprintSpeed);
        }
        else{
            rb.AddForce(movement * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("coin")) 
        {
            other.gameObject.SetActive(false);
            Score = Score + 1;
            source.PlayOneShot(pickupSound);
            SetScoreText();
            if(Score >= 5) 
            {
                Wall.gameObject.SetActive(false);
            }
        }

        if(other.gameObject.tag=="danger")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void SetScoreText()
    { 
        ScoreText.text = "Score: "+Score.ToString(); 
        if(Score>=10)
        {
            WinText.text = "YOU WIN!!! Press R to play again or Escape to close the game";
        }
    }
}
