using UnityEngine;
using DG.Tweening;

public class ScalingObstacle : MonoBehaviour
{
    [SerializeField] private float duration = 2f;

    void Start()
    {
        transform.DOScale(new Vector3(2, 2, 1), duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
