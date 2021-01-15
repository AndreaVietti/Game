using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    public float range = 1000;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    void Update()
    {
        RaycastHit raycastHit;
        bool hit = Physics.Raycast(transform.position, transform.forward, out raycastHit, range,
            ~(1 << LayerMask.NameToLayer("NoPhysicsRaycast"))); // transform.position + (transform.forward * (float)offset) can be used for casting not from center.
        if (hit)
        {
            Collider collider = raycastHit.collider;

            line.SetPosition(0, transform.position);
            line.SetPosition(1, raycastHit.point);

            if (collider.gameObject.tag == "Player")
            {
                // Do something like changing laser color
            }
            else if (collider.gameObject.tag == "Enemy")
            {
                // Do something else
            }
        }
        else
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + (transform.forward * range)); // (transform.forward * ((float)offset + range)) can be used for casting not from center.
        }
    }
}