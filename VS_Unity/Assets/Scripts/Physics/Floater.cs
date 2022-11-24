 using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Floater : MonoBehaviour
{

    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    public int floaterCount = 1;


    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveManager.instance.GetWaveHeigth(transform.position.x); 

        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01( (waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }

  
}
