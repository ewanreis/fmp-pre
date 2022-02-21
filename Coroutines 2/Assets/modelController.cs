using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class modelController : MonoBehaviour
{
    public Rigidbody vehicle;
    void Start() => StartCoroutine(Routine());
    IEnumerator Routine()
    {
        for (int i = 0; i <= 75; i++)
        {
            float torque = Random.Range(-50f, 50f), timer = Random.Range(0.5f, 3.1f);
            vehicle.AddTorque(0f, torque, 0f);
            yield return new WaitForSeconds(timer);
            vehicle.AddTorque(0f, -torque, 0f);
            vehicle.AddRelativeForce(Vector3.forward * 30);
            yield return new WaitForSeconds(2f);
            vehicle.velocity = Vector3.zero;
        }
        yield return null;
    }
}