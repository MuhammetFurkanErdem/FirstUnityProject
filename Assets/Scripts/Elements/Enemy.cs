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
        transform.Rotate(0, Random.Range(0, 360), 0); // Randomly rotate the enemy at the start
    }

    private void Update()
    {
        if (_player == null)
            return;

        if (_player.isAppleCollected)
        {
            if (navMeshAgent != null && navMeshAgent.isActiveAndEnabled)
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
