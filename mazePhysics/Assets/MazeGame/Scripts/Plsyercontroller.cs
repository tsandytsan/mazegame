using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Plsyercontroller : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    public int forceApplied;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    //    SetCountText();
     //   winText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVerticle =Input.GetAxis("Vertical");
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector3(0, forceApplied, 0), ForceMode.Impulse);
        }
        { 
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVerticle);
            movement = Quaternion.LookRotation(Quaternion.Euler(-90, 0, 0) * (Physics.gravity)) * movement;
            rb.AddForce(movement * speed);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }
    void OnCollisionEnter(Collision collision)
    {
                 
            Physics.gravity = (-collision.contacts[0].normal) * 9.8f;
    }
    void SetCountText()
    {
    //    countText.text = "Count: " + count.ToString();
    //    if(count >= 13)
    //    {
    //        winText.text = "You Win!";
    //    }
    }
}
