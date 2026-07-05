using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Player _player;

    public float speed;
    public NavMeshAgent navMeshAgent;
    public Transform zPrefab;

    private Rigidbody _rb;
    private Animator _animator;

    private bool _isWalking;

    private Transform _z1;
    private Transform _z2;

    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();

        transform.Rotate(0, Random.Range(0, 360), 0);

        CreateAndAnimateZ();
    }

    private void CreateAndAnimateZ()
    {
        _z1 = Instantiate(zPrefab, transform);
        _z1.position = transform.position + Vector3.up * 2;
        _z1.localScale = Vector3.zero;

        _z1.DOMoveY(_z1.position.y + 1f, 1f)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);

        _z1.DOScale(1f, 1f)
            .SetLoops(-1, LoopType.Restart);

        _z1.LookAt(_z1.position + Vector3.back);

        _z2 = Instantiate(zPrefab, transform);
        _z2.position = transform.position + Vector3.up * 2;
        _z2.localScale = Vector3.zero;

        _z2.DOMoveY(_z2.position.y + 1f, 1f)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear)
            .SetDelay(0.5f);

        _z2.DOScale(1f, 1f)
            .SetLoops(-1, LoopType.Restart)
            .SetDelay(0.5f);

        _z2.LookAt(_z2.position + Vector3.back);
    }

    private void Update()
    {
        if (_player == null)
            return;

        if (_player.isAppleCollected)
        {
            if (navMeshAgent != null && navMeshAgent.isActiveAndEnabled)
            {
                navMeshAgent.SetDestination(_player.transform.position);
            }

            if (!_isWalking)
            {
                HideZ();
                _animator.SetTrigger("Walk");
                _isWalking = true;
            }
        }
    }

    public void StopMovement()
    {
        if (navMeshAgent != null && navMeshAgent.isActiveAndEnabled)
        {
            navMeshAgent.ResetPath();
            navMeshAgent.speed = 0;
        }

        if (_animator != null)
            _animator.SetTrigger("Idle");

        KillTweens();
    }

    private void KillTweens()
    {
        if (_z1 != null)
        {
            _z1.DOKill();
            Destroy(_z1.gameObject);
            _z1 = null;
        }

        if (_z2 != null)
        {
            _z2.DOKill();
            Destroy(_z2.gameObject);
            _z2 = null;
        }

        transform.DOKill();
    }

    private void OnDestroy()
    {
        KillTweens();
    }

    private void HideZ()
    {
        if (_z1 != null)
        {
            Transform z = _z1;
            _z1 = null;

            z.DOKill();
            z.DOScale(0f, 0.2f)
                .OnComplete(() =>
                {
                    if (z != null)
                        Destroy(z.gameObject);
                });
        }

        if (_z2 != null)
        {
            Transform z = _z2;
            _z2 = null;

            z.DOKill();
            z.DOScale(0f, 0.2f)
                .OnComplete(() =>
                {
                    if (z != null)
                        Destroy(z.gameObject);
                });
        }
    }

}
