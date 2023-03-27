using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Ball_Control : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;
    public float jumpSpeed;
    private float jumpForce;
    public bool onGround;
    private int coin;
    public TMP_Text coinUI;
    private AudioSource coinSound;
    public int targetScore;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coin = 0;
        coinSound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector3.up * jumpSpeed);
            onGround = false;
        }
        else
        {
            jumpForce = 0f;
        }

        Vector3 movement = new Vector3 (moveHorizontal,jumpForce, moveVertical);
        rb.AddForce(movement*speed*Time.deltaTime);
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            //Debug.Log("hit the floor");
            onGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coin++;
            coinUI.text = "Coin:" + coin;
            coinSound.Play();

            targetScore--;
            if (targetScore == 0 )
            {
                SceneManager.LoadScene(nextScene);
            }
        }
        else if (other.gameObject.tag == "Boundary")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
