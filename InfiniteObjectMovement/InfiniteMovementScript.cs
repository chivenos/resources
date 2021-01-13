using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMovementScript : MonoBehaviour
{
    [SerializeField] private GameObject _targetObject; //Target object
    [SerializeField] private float _speed; //Speed of the object
    private Vector3 _targetDirection; //Target Direction of the object
    
    // Start is called before the first frame update
    void Start()
    {
        _targetDirection = (_targetObject.transform.position - transform.position).normalized;
        //returns the normalized value of distance between object's starting position and target position
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = _targetDirection * _speed * Time.deltaTime; //Velocity
        transform.Translate(velocity); //Moving the object
    }
}
