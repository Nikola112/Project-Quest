using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Transform head;
	public float speed = 5f;

	[SerializeField]
	private float lookSensitivity = 10f;
	[SerializeField]
	private float mouseSmoothing = 2f;

	private Rigidbody rb;

	private Vector3 movementVelocity = Vector3.zero;
	private float xRotation = 0f;
	private float yRotation = 0f;
	private float lastXRotation = 0f;
	private float lastYRotation = 0f;

	private void Awake()
	{
		rb = GetComponent<Rigidbody> ();
	}

	private void FixedUpdate()
	{
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		if (horizontal == 0f && vertical == 0f)
		{
			movementVelocity /= 1.3f;
		}
		else
		{
			movementVelocity = ((transform.forward * vertical) + (transform.right * horizontal)).normalized * speed * Time.fixedDeltaTime;
		}

		if (movementVelocity.sqrMagnitude > 0.001f)
		{
			rb.MovePosition (rb.position + movementVelocity);
		}
	}

	private void LateUpdate()
	{
		float mouseX = Input.GetAxisRaw ("Mouse X") * lookSensitivity;
		float mouseY = Input.GetAxisRaw ("Mouse Y") * lookSensitivity;

		xRotation = Mathf.Lerp (lastXRotation, xRotation + mouseX, 1f / mouseSmoothing);
		yRotation = Mathf.Lerp (lastYRotation, yRotation - mouseY, 1f / mouseSmoothing);

		yRotation = Mathf.Clamp (yRotation, -85, 85);

		head.localRotation = Quaternion.Euler (yRotation, 0f, 0f);
		transform.rotation = Quaternion.Euler (0f, xRotation, 0f);

		lastXRotation = xRotation;
		lastYRotation = yRotation;
	}

	public bool IsGrounded()
	{
		return Physics.Raycast (transform.position, Vector3.down, 1.1f);
	}
}
