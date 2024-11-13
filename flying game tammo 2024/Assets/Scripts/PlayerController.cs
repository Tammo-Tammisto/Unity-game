using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float FlySpeed;
    public float YawAmount = 120;
    public int Score;
    public AudioSource Waypoint;
    public TMP_Text ScoreText;
    public TMP_Text WinText;
    private float Yaw;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        ScoreText.text = "Score: " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=transform.forward*FlySpeed*Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0,90,Mathf.Abs(verticalInput))*Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0,20,Mathf.Abs(horizontalInput))*-Mathf.Sign(horizontalInput);

        transform.localRotation = Quaternion.Euler(Vector3.up*Yaw+Vector3.right*pitch+Vector3.forward*roll);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "waypoint")
        {
            Destroy(other.gameObject, 0.1f);
            Waypoint.Play();
            Score++;
            ScoreText.text = "Score: " + Score.ToString();
            if(Score == 5)
            {
                Application.LoadLevel("WinLevelScene");
            }
        }
        
        if(other.gameObject.tag == "danger")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
