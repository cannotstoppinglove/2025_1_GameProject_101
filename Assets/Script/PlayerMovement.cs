using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public bool isGrounded = true;

    public int coinCount = 0;
    public int totalCoin = 5;

    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVertical * moveSpeed);

        if(Input.GetButtonDown("Jump") && isGrounded) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")    //�浹�� �Ͼ ��ü�� Tag�� Ground�� ��� 
        {
            isGrounded = true;
        }

    }

    private void OnTriggerEnter(Collider other)    //Ʈ���� ���� �ȿ� ���Գ��� �˻��ϴ� �Լ�
    {
        if(other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
            Debug.Log("���� ���� : {coinCount}/{totalCoins}");
        }

        if(other.gameObject.tag == "Door" && coinCount == totalCoin)
        {
            Debug.Log("���� Ŭ����");
        }

    }
}
