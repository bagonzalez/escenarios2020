using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;
    public Transform target;
    [Range (0, 1)]public float lerpValue;
    public float sensibilidad;
    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
         offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
     {
        //  transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
         transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, lerpValue);
         offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * offset;
         transform.LookAt(target);
    }
}
