using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 15;

    public float speedH = 2.0f;

    public float speedV = 2.0f;

    private float yaw = 0.0f;

    private float pitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        Vector3 vectorMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        gameObject.transform.position += vectorMovement.normalized * moveSpeed * Time.deltaTime;
    }

    public void CameraRotation()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        
        transform.eulerAngles = new Vector3(pitch,yaw, 0.0f);
    }
}
