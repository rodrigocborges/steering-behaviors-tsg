using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    [SerializeField] private float levelBounds;
    [SerializeField] private float amount;
    [SerializeField] private float radius;
    [SerializeField] private float distance;
    [SerializeField] private float maxAcceleration;
    [SerializeField] private float maxVelocity;
    
    
    Vector2 target;
    Vector2 position, velocity, acceleration;

    void Start()
    {
        position = transform.position;
        velocity = new Vector2(Random.Range(-3, 3), 0);
    }

    void Update()
    {
        acceleration = ApplyWander();
        acceleration = Vector2.ClampMagnitude(acceleration, maxAcceleration);
        velocity = velocity + acceleration * Time.deltaTime;
        velocity = Vector2.ClampMagnitude(velocity, maxVelocity);
        position = position + velocity * Time.deltaTime;
        WrapAround(ref position, -levelBounds, levelBounds);
        transform.position = position;
    }

    Vector2 ApplyWander()
    {
        float amountByTime = amount * Time.deltaTime;
        target += new Vector2(0, RandomBinomial() * amountByTime);
        target = target.normalized;
        target *= radius;
        Vector2 targetInLocalSpace = target + new Vector2(0, distance);
        Vector2 targetInWorldSpace = transform.TransformPoint(targetInLocalSpace);
        targetInWorldSpace -= position;
        return targetInWorldSpace.normalized;
    }

    void WrapAround(ref Vector2 vec, float min, float max)
    {
        vec.x = WrapAroundLocal(vec.x, min, max);
        vec.y = WrapAroundLocal(vec.y, min, max);
    }

    float WrapAroundLocal(float value, float min, float max)
    {
        if(value > max)
            value = min;
        else if(value < min)
            value = max;
        return value;
    }

    float RandomBinomial()
    {
        return Random.Range(0f, 1f) - Random.Range(0f, 1f);
    }
}
