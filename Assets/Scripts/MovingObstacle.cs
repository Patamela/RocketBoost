using UnityEngine;
using DG.Tweening;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3(0,3f,0);
    [SerializeField] private float duration = 2f;
    [SerializeField] private float delay = 0f;

    void Start()
    {
        // Ease -> hace como que el movimiento sea más fluido y tenga efecto como de flotar
        // -1 en Loop, es para hacer infinito
        // Delay -> retraso para hacer la animación, en este caso no tendría
        transform.DOLocalMove(transform.localPosition + movement, duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(delay);
    }
}
