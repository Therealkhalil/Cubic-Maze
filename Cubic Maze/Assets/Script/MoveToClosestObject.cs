using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveToClosestObject : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;
    private float inputx, inputz;
    private bool run = false, choose = false,gameover = false;
    [SerializeField] private GameObject Gameov;
    [SerializeField] private GameObject Inq;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if(choose == false && gameover == false)
        { 
        inputx = Input.GetAxisRaw("Horizontal");
        inputz = Input.GetAxisRaw("Vertical");
        }
        // Move the player in the desired direction
        if ((inputz > 0 || (inputx > 0) || (inputx < 0) || inputz < 0 || run) && gameover == false)
        {
        choose = true;
        run = true;
        rb.AddForce(new Vector3(inputx, 0f, inputz) * speed * Time.deltaTime,ForceMode.Impulse);
        }
        Debug.Log(choose);
        Debug.Log("You Won!");
    }

    void OnCollisionEnter(Collision collision)
    {

        // If the player hits a block, stop moving
        
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("You Won!");
            choose = true;
            run = false;
            gameover = true;
            Inq.SetActive(false);
            Gameov.SetActive(true);
        }
        else if (collision.gameObject.tag == "Block" && gameover == false)
        {
            rb.velocity = Vector3.zero;
            Debug.Log("wtf");
            choose = false;
            run = false;
        }
    }
}//rb.MovePosition(rb.position + direction * speed * Time.deltaTime);