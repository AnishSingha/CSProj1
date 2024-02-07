using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineMovement : AbstractSpline
{
    public SplineContainer splineContainer;
    public float speed = 2.0f;
    public bool loop = true;

    [Range(0, 1)]
    [SerializeField]public float t = 0.0f;


    private void Update()
    {
        if (splineContainer != null && splineContainer.Splines.Count > 0)
        {
            t += speed * Time.deltaTime;

            if (t > 1.0f)
            {
                if (loop)
                {
                    t = 0.0f;
                }
                else
                {
                    t = 1.0f;
                }
            }

            if (splineContainer.Evaluate(t, out var position, out var tangent, out _))
            {

                transform.SetPositionAndRotation(position, Quaternion.LookRotation(tangent, Vector3.up));
            }
        }
    }
}
