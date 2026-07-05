using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;
    private Animator _animator;

    private bool _isWalking = false;

    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (_player.isAppleCollected)
        {
            /* var direction = (_player.transform.position - transform.position).normalized;
            direction.y = 0; // Keep the enemy on the same plane as the player
            _rb.position += direction * speed * Time.deltaTime;  */

            navMeshAgent.SetDestination(_player.transform.position);

            if (!_isWalking)
            {
                _animator.SetTrigger("Walk");
                _isWalking = true;
            }

        }
    }

    public void StopMovement()
    {
        navMeshAgent.speed = 0;
        _animator.SetTrigger("Idle");
    }   

}
