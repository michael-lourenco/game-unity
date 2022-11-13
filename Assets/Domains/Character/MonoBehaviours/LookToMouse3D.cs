using UnityEngine;

public class LookToMouse3D : MonoBehaviour
{

	public Transform objectToLookMouse;
	public float velocity = 5.0f;

	public bool freezyY = true;

	private Ray ray;
	private RaycastHit hit;

	private void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (!Physics.Raycast(ray, out hit))
			return;

		Vector3 pos = objectToLookMouse.position - hit.point;

		if (freezyY)
			pos.y = 0;

		Quaternion rot = Quaternion.LookRotation(-pos);

		objectToLookMouse.rotation = Quaternion.Lerp(objectToLookMouse.rotation, rot, velocity * Time.deltaTime);
	}


}