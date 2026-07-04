using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;

    public float speed;

    public bool isAppleCollected;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            isAppleCollected = true;
            gameDirector.levelManager.AppleCollected();
        }
        if (other.CompareTag("Door") && isAppleCollected)
        {
            gameDirector.LevelCompleted();
        }
    }

    [System.Obsolete]
    void Update()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
        }
        else
        {
            speed = 2;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.W)) 
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {    
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        _rb.velocity = direction.normalized * speed;

    }
}
 