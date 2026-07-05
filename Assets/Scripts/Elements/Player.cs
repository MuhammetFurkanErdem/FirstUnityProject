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

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void RestartPlayer()
    {
        gameObject.SetActive(true);

        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        transform.position = new Vector3(0, 0, -3.5f);

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

        if (other.CompareTag("Enemy"))
        {
            gameDirector.GameOver();
            gameObject.SetActive(false);
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

        if (Input.GetKey(KeyCode.W))
            direction += Vector3.forward;

        if (Input.GetKey(KeyCode.S))
            direction += Vector3.back;

        if (Input.GetKey(KeyCode.A))
            direction += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;

        if (direction.sqrMagnitude < 0.01f)
        {
            TrigerIdleAnimation();
        }
        else
        {
            TrigerWalkingAnimation();
            transform.forward = direction.normalized;
        }

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
 