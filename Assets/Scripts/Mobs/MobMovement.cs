using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{
    private float actualSpeed = 1.0f;
    public Transform transformFinalWayPoint;
    private Vector3 direction;

    private void Start()
    {
        transformFinalWayPoint = gameObject.GetComponent<MobSettings>().transformFinalWayPoint;
    }
    void FixedUpdate()
    {
        direction = Vector3.zero;
        //get the vector from your position to current waypoint
        direction = transformFinalWayPoint.position - transform.position;

        GetComponent<Rigidbody>().velocity = new Vector3(direction.x * actualSpeed, direction.y * actualSpeed, direction.z * actualSpeed);
    }















    /*
    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    //ZATYCZKA
    bool notIsWas = true;
    // Start is called before the first frame update

    private void Update()
    {
        if (notIsWas && !gameObject.GetComponent<MobSettings>().isDefault)
        {
            _startPosition = transform.position;
            _targetPosition = transform.position + Vector3.forward * 5;
            StartCoroutine(MoveCoroutine());
            notIsWas = false;
        }
    }

    // Update is called once per frame

    IEnumerator MoveCoroutine()
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(_startPosition, _targetPosition, i);
            yield return null;
        }
    }*/
}
