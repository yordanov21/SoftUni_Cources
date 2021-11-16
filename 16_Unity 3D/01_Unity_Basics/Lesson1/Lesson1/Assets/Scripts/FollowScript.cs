using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour
{
    public Transform sphere;
    public float followSpeed;
    public float minDistance;

	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (sphere != null)
        {
            this.transform.LookAt(sphere);

            if (Vector3.Distance(this.transform.position, sphere.position) > minDistance)
            {
                this.transform.Translate(0f, 0f, followSpeed * Time.deltaTime);
            }
        }

    }
}
