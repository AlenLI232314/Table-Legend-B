using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RollDice : MonoBehaviour
{
	// Start is called before the first frame update
	static Rigidbody rb;
	public static Vector3 diceVelocity;
	public bool isMoving;
	public AudioSource audioSource;
	[SerializeField] private AudioClip[] diceRolls;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		diceVelocity = rb.velocity;

		if (Input.GetKeyDown(KeyCode.E))
		{
			//DiceNumText.diceNumber = 0;
			float dirX = UnityEngine.Random.Range(0, 500);
			float dirY = UnityEngine.Random.Range(0, 500);
			float dirZ = UnityEngine.Random.Range(0, 500);
			transform.position = new Vector3(0, 3, 0);
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 800);
			rb.AddTorque(dirX, dirY, dirZ);
			isMoving = false;
			audioSource.PlayOneShot(diceRolls[UnityEngine.Random.Range(0, diceRolls.Length)]);
		}
	}
}
