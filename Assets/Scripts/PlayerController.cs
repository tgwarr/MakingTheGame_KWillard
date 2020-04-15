using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private AudioSource audioSource;
	public ParticleSystem dirtSplat;
	public ParticleSystem obstacleExplosion;
	private Rigidbody playerRigidBody;
	private Animator playerAnim;
	public AudioClip jumpSound;
	public AudioClip explosionSound;
	public float forceMultiplier;
	public float gravityMultiplier;
	public bool onGround = true;
	public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
		audioSource = GetComponent<AudioSource>();
		playerAnim = GetComponent<Animator>();
		playerRigidBody = GetComponent<Rigidbody>();
		Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
		{
			playerRigidBody.AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
			onGround = false;
			dirtSplat.Stop();
			playerAnim.SetTrigger("Jump_trig");
			audioSource.PlayOneShot(jumpSound, 1.0f);
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Obstacle"))
		{
			dirtSplat.Stop();
			gameOver = true;
			Debug.Log("Game Over!");
			playerAnim.SetBool("Death_b", true);
			playerAnim.SetInteger("DeathType_int", 1);
			obstacleExplosion.Play();
			audioSource.PlayOneShot(explosionSound, 2.0f);
		}
		else if(collision.gameObject.CompareTag("Ground") && !gameOver)
		{
			onGround = true;
			dirtSplat.Play();
		}
	}
}
