using DG.Tweening;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void Start()
    {
        StartAnimation();
        
    }

    private void StartAnimation()
    {
        transform.DOMoveY(transform.position.y + 0.75f, 1.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);

        transform.DORotate(Vector3.up * 90, 2f)
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

}
