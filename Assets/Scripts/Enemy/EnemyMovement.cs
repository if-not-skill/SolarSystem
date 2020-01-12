using UnityEngine;

public class EnemyMovement: MonoBehaviour {
	public Transform Target;
	[SerializeField] private float MovementSpeed = 5f;
	[SerializeField] private float RotationalDamp = 1.5f;
    [SerializeField] private float StoppingDistance = 5f;


	private void Update() {
		Turn();
		Move();
	}

	private void Turn() {
        if (Target == null) return;
		Vector3 pos = Target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(pos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationalDamp * Time.deltaTime);
	}

	private void Move() {
        if (Target == null) return;
        RaycastHit hit;
        Vector3 direction = Target.position - transform.position;

        if (Physics.Raycast(transform.position, direction, out hit, StoppingDistance))
        {
            return;
        }
        transform.position += transform.forward * MovementSpeed * Time.deltaTime;
    }
}