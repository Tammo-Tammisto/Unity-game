using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        ScoreText.GetComponent<Text>();
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

        transform.localRotation = Quaternion.Euler(Vector3.up*Yaw+Vector3.forward*roll);
    }
}
