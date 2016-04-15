using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIswall;
	private bool hittingWall;

	private bool notatEdge;
	//public Transform edgeCheck;

	void Start()
	{
	}

	void Update()
	{
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIswall);
		//notatEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIswall);

		if (hittingWall)/* || !notatEdge*/ 
		{
			moveRight = !moveRight;
		}

		if (moveRight) {
			transform.localScale = new Vector3 (0.3f, 0.3f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} 
		else 
		{
			transform.localScale = new Vector3 (-0.3f, 0.3f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}