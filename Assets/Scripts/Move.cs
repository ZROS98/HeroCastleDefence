using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{    
    
    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        _targetPosition = transform.position + Vector3.right * 5;
        StartCoroutine(MoveCoroutine());
    }

    // Update is called once per frame

    IEnumerator MoveCoroutine()
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(_startPosition, _targetPosition, i);
            yield return null;
        }
    }
}
