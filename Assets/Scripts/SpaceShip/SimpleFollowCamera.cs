using UnityEngine;

public class SimpleFollowCamera: MonoBehaviour {
	public Transform Target;
	public Vector3 FollowDistance = new Vector3(0f, 2f, -10f);
	public float DistanceDamp = 1f;
	public float RotationalDamp = 5f;

	public Vector3 velocity = Vector3.one;

	private void LateUpdate() {
        if (Target != null)
        {
            SmoothFollow();
        }

		// Vector3 targetPos = Target.position + (Target.rotation * FollowDistance);
		// Vector3 newPos = Vector3.Lerp(transform.position, targetPos, DistanceDamp * Time.deltaTime);
		// transform.position = newPos;

		// Quaternion targetRot = Quaternion.LookRotation(Target.position - transform.position, Target.up);
		// Quaternion newRot = Quaternion.Slerp(transform.rotation, targetRot, RotationalDamp * Time.deltaTime);
		// transform.rotation = newRot;

	}

	private void SmoothFollow() {
		Vector3 targetPos = Target.position + (Target.rotation * FollowDistance);
		Vector3 newPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, DistanceDamp);
		transform.position = newPos;

		transform.LookAt(Target, Target.up);
	}
}