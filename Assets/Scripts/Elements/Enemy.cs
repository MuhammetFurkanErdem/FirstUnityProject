using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;
    private Animator _animator;
    public Transform zPrefab;

    private bool _isWalking = false;

    private Transform _z1, _z2;

    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        transform.Rotate(0, Random.Range(0, 360), 0); // Randomly rotate the enemy at the start
        CreateAndAnimateZ();
    }

    private void CreateAndAnimateZ()
    {
        _z1 = Instantiate(zPrefab);
        _z1.position = transform.position + Vector3.up * 2;
        _z1.localScale = Vector3.zero;
        _z1.DOMoveY(_z1.position.y + 1f, 1f)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
        _z1.DOScale(1, 1f).SetLoops(-1, LoopType.Restart);

        _z2 = Instantiate(zPrefab);
        _z2.position = transform.position + Vector3.up * 2;
        _z2.localScale = Vector3.zero;
        _z2.DOMoveY(_z1.position.y + 1f, 1f)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear)
            .SetDelay(.5f);
        _z2.DOScale(1, 1f).SetLoops(-1, LoopType.Restart).SetDelay(.5f);
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
        _z1.DOKill();
        _z2.DOKill();
        Destroy(_z1.gameObject);
        Destroy(_z2.gameObject);
    }   

}
