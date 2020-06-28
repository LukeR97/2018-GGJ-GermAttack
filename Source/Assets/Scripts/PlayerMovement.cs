using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    int count = 0;
    public Text countText;
    public SpriteRenderer red1;
    public SpriteRenderer red2;
    public SpriteRenderer red3;
    public ParticleSystem p1;
    public ParticleSystem p2;
    public ParticleSystem p3;
    public AudioClip death;
    public AudioSource playerSource;


	void Start () {

        rb = GetComponent<Rigidbody2D>();
        count = 0;

        SetCountText();
        if (gameObject.tag.Equals("DedCells"))
        {
            red1 = gameObject.GetComponent<SpriteRenderer>();
            red2 = gameObject.GetComponent<SpriteRenderer>();
            red3 = gameObject.GetComponent<SpriteRenderer>();
        }
        red1.enabled = false;
        red2.enabled = false;
        red3.enabled = false;

        if (gameObject.name.Equals("Partical System")) {
            p1 = gameObject.GetComponent<ParticleSystem>();
            p2 = gameObject.GetComponent<ParticleSystem>();
            p3 = gameObject.GetComponent<ParticleSystem>();
        }
	}
	
	
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * 3);

        if(count == 3)
        {
            Application.LoadLevel("win");
        }
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp") && collision.gameObject.name.Equals("Item1")) {
            red1.enabled = true;
            p1.Stop();
            collision.gameObject.SetActive(false);

            count = count + 1;
            SetCountText();
        }
        if(collision.gameObject.CompareTag("PickUp") && collision.gameObject.name.Equals("Item2"))
        {
            red2.enabled = true;
            p2.Stop();
            collision.gameObject.SetActive(false);

            count = count + 1;
            SetCountText();
        }

        if (collision.gameObject.CompareTag("Enemy")) {
           // playerSource.PlayOneShot(death);
            Application.LoadLevel("endscreen");
        }
        if(collision.gameObject.CompareTag("PickUp") && collision.gameObject.name.Equals("Item3"))
        {
            red3.enabled = true;
            p3.Stop();
            collision.gameObject.SetActive(false);

            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText() {
        countText.text = "Count " + count.ToString();
    }
}
