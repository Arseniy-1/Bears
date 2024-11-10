using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class TargetScaner : MonoBehaviour
{
    [SerializeField] private float _scanRadius = 150f;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _scanDelay = 1;

    private WaitForSeconds _delay;

    public ITarget ClosestTarget { get; private set; }
    public bool HasTarget => ClosestTarget != null;

    private void Start()
    {
        _delay = new WaitForSeconds(_scanDelay);
        StartCoroutine(Scaning());
    }

    private IEnumerator Scaning()
    {
        while (enabled)
        {
            yield return _delay;
            Scan();
        }
    }

    public void Scan()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _scanRadius);
        HashSet<ITarget> targets = new HashSet<ITarget>();

        foreach (Collider2D hit in hits)
            if (hit.TryGetComponent(out ITarget target) && (_targetLayer & (1 << hit.gameObject.layer)) != 0)
                targets.Add(target);

        if (targets.Count > 0)
        {
            ClosestTarget = targets.ToArray()[0];
        }
        else
        {
            ClosestTarget = null;
        }
    }
}
