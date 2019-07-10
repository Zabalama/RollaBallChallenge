using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerScene2 : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text totalCount;
    public Text winText;
    public Text liveCount;
    public Text loseText;
    private Rigidbody rb;
    private int count;
    private int total;
    private int lives;
    private static bool playerExists;
        

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } 
        else
        {
            Destroy (gameObject);
        }

        count = 0;
        total = 0;
        lives = 3;
        SetCountText ();
        SetTotalCount();
        SetLivesCount();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            total = total + 1;
            SetCountText();
            SetTotalCount();
        }

         if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count - 0;
            total = total - 1;
            lives = lives - 1;
            SetCountText();
            SetTotalCount();
            SetLivesCount();
        }
    }

   
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
       
    }

     void SetTotalCount()
    {
        totalCount.text = "Score: " + total.ToString();
         if (total >= 12)
            {
                winText.text = "You Win!";
            }
     
    }
     
    void SetLivesCount()
    {
        liveCount.text = "Lives: " + lives.ToString();
        {
        if (lives <= 0)
            {
                gameObject.SetActive(false);
                loseText.text = "Try again";
            }
        }
    }

 
    void Update ()
    {
        if (Input.GetKey("escape"))
     Application.Quit();

    }

}
