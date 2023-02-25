using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EditorTools;

public class MovingTarget : Target
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private float cycle = 10f;

    private Vector3 startPos;
    private float timer = 0f;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float ratio = Mathf.Sin(Mathf.InverseLerp(0, cycle, timer) * 2 * Mathf.PI) / 2f + 0.5f;
        transform.position = Vector3.Lerp(startPos, destination, ratio);

        timer += Time.deltaTime;
        if (timer > cycle)
            timer = 0f;
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(startPos, transform.localScale);
        Gizmos.DrawWireCube(destination, transform.localScale);
    }

#endif
}
