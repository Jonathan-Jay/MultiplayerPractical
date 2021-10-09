using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
	public float range = 0.5f;

	private float counter = 0;
	private float defaultY;
	private Quaternion defaultRotation;

    // Start is called before the first frame update
    void Start()
    {
        defaultY = transform.position.y;
		defaultRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
		counter += Time.deltaTime;

        Vector3 pos = transform.position;
		pos.y = defaultY + Mathf.Sin(counter * 3f) * range;
		transform.position = pos;

		transform.rotation = defaultRotation * Quaternion.AngleAxis(counter * 360f, Vector3.forward);
    }
}
