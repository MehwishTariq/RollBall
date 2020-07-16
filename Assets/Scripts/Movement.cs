using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed;
    public Text countText,winText;

    private int count;
    private Rigidbody rb;

    //initialization when game starts
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        SetCountText();
    }
    //physics implementation functions come here
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(move*speed);
    }

    //check collision to deactivate the collectables
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUps"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count == 14)
        {
            winText.text = "You Win!";
        }
    }
}
