using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject Dummy, Player;
	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	public static CameraFollow instance;
	private void Awake()
	{
		instance = this;
	}
	public void Set_Realtime_Target()
	{
		target = Player.transform;
	}
	public void Set_Dummy_Target()
	{
		target = Dummy.transform;
	}
	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}

}