using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;

    public float speed;

    public bool isAppleCollected;

    private Rigidbody _rb;

    private bool _isCharacterWalking;

    public Animator animator;

    public void RestartPlayer()
    {
        gameObject.SetActive(true);
        _rb = GetComponent<Rigidbody>();
        _rb.position = new Vector3(0, 0, -3.5f);
        isAppleCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            gameDirector.LevelCompleted();
        }
    }

    private void Update()
    {
        MovePlayer();

    }

    private void MovePlayer()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
            SetWalkingAnimationSpeed(2.5f);
        }
        else
        {
            speed = 2;
            SetWalkingAnimationSpeed(1f);
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

        if(direction.magnitude < .1f)
        {
            TrigerIdleAnimation();
        }
        else
        {
            TrigerWalkingAnimation();
        }

        transform.LookAt(transform.position + direction);
        _rb.linearVelocity = direction.normalized * speed;
    }

    void TrigerWalkingAnimation()
    {
        if (!_isCharacterWalking)
        {
            animator.SetTrigger("Walk");
            _isCharacterWalking = true;
        }
        
    }

    void TrigerIdleAnimation()
    {
        if (_isCharacterWalking)
        {
            animator.SetTrigger("Idle");
            _isCharacterWalking = false;
        }
    }

    void SetWalkingAnimationSpeed(float s)
    {
        animator.SetFloat("WalkSpeed", s);
    }

}
 