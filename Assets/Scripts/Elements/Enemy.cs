using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;

    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_player.isAppleCollected)
        {
            /* var direction = (_player.transform.position - transform.position).normalized;
            direction.y = 0; // Keep the enemy on the same plane as the player
            _rb.position += direction * speed * Time.deltaTime;  */

            navMeshAgent.SetDestination(_player.transform.position);
        }
    }

    public void StopMovement()
    {
        navMeshAgent.speed = 0;
    }   

}
