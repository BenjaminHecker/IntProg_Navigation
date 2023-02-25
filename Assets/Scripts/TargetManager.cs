using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager instance;

    [System.Serializable]
    struct TargetChance
    {
        public float probability;
        public Target target;
    }
    [SerializeField] private TargetChance[] targets;

    private Target activeTarget;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        NextTarget();
    }

    public static void NextTarget()
    {
        if (instance.targets.Length <= 1) return;

        while (true)
        {
            TargetChance t = instance.targets[Random.Range(0, instance.targets.Length)];

            if (t.target != instance.activeTarget)
            {
                instance.ActivateTarget(t.target);
                break;
            }
        }
    }

    private void ActivateTarget(Target target)
    {
        activeTarget = target;

        foreach (TargetChance t in targets)
            t.target.gameObject.SetActive(t.target == target);
    }
}
