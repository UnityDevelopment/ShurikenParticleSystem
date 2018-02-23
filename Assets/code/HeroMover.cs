using UnityEngine;
using System.Collections;

public class HeroMover : MonoBehaviour {

	public float motion_speed;
	public float rotation_speed;
	public ParticleSystem[] muzzles = new ParticleSystem[2];
	public ParticleSystem[] exhaust = new ParticleSystem[2];
	public Light[] muzzle_lights = new Light[2];

	void Start () {
		
	}
	
	void Move()
	{
		float delta_speed = Time.deltaTime * motion_speed;

		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector3.right * -delta_speed);
		}
		
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector3.right * delta_speed);
		}
		
	}
	
	void Turn()
	{
		float delta_rotation_speed = Time.deltaTime * rotation_speed;
		
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.up * delta_rotation_speed );
		}
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.up * -delta_rotation_speed);
		}
	}


	void Fire()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			foreach (ParticleSystem muzzle in muzzles)
			{
				muzzle.Play();
			}
			foreach (Light muzzle_light in muzzle_lights)
			{
				muzzle_light.gameObject.SetActive(true);
			}
		} else if (Input.GetKeyUp(KeyCode.Space))
		{
			foreach (ParticleSystem muzzle in muzzles)
			{
				muzzle.Stop();
				muzzle.Clear();
			}
			foreach (Light muzzle_light in muzzle_lights)
			{
				muzzle_light.gameObject.SetActive(false);
			}
		}

	}

	void Update () 
	{
		Move ();
		Turn ();
		Fire ();
	}
}
