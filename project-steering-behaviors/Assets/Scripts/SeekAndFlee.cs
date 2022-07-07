using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType {
    Seek,
    Flee
}

public class SeekAndFlee : MonoBehaviour
{
    [SerializeField] private MovementType movementType;
    [SerializeField] private Transform objectTarget;
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;

    // Update is called once per frame
    void Update()
    {
        if(movementType == MovementType.Seek)
            Seek(objectTarget.position);
        else if(movementType == MovementType.Flee)
            Flee(objectTarget.position);
    }

    void Seek(Vector2 target)
    {
        float distanceToTarget = Vector2.Distance(transform.position, target);
        if(stopDistance > distanceToTarget)
            return;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void Flee(Vector2 target)
    {
        Vector2 myPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 fleeVector = target - myPosition;
        
        transform.position = Vector2.MoveTowards(transform.position, myPosition - fleeVector, speed * Time.deltaTime);
    }
}
