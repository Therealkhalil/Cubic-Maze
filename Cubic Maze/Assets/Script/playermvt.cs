using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermvt : MonoBehaviour
{
    private Rigidbody _rb;
    private float inputx, inputz,firstinputx,firstinputz;
    [SerializeField] private float speed = 10f;
    private bool moving = false;
    [SerializeField] private SceneSwitcher _scswitch;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputx = Input.GetAxisRaw("Horizontal");
        inputz = Input.GetAxisRaw("Vertical");
        movement();
        restart();
    }


    void movement()
    {
        if (inputx != 0 && moving == false)
        {
            firstinputx = inputx;
            moving = true;
        }
        else if(inputz != 0 && moving == false)
        {
            firstinputz = inputz;
            moving = true;
        }

        if (moving)
            _rb.velocity = new Vector3(firstinputx, 0f, firstinputz) * speed;
    }

    void restart()
    {
        if(Input.GetKeyDown(KeyCode.R))
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            moving = false;
            firstinputx = 0f;
            firstinputz = 0f;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            _scswitch.playGame();
        }
    }
}
