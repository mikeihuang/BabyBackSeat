using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horsie : MonoBehaviour {

	public Vector3 MovementScale = new Vector3 ();
	public Vector3 MovementSpeed = new Vector3 ();

	public Vector3 RotationScale = new Vector3 ();
	public Vector3 RotationSpeed = new Vector3 ();

    public float RespawnDelay = 5f;

    public CamSaturationChange CamSat;
    public RandomAudioClip appearSound;

    private AudioSource eatingSound;
    private Animator anim;

	private Vector3 RootPosition;
	private Quaternion RootRotation;

    private float timeOut;

	// Use this for initialization
	void Start () {
        eatingSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

		appearSound = GetComponentInChildren<RandomAudioClip> ();

		RootPosition = this.transform.position;
		RootRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = RootPosition + new Vector3 (
			MovementScale.x * Mathf.Sin (MovementSpeed.x * Time.time),
			MovementScale.y * Mathf.Sin (MovementSpeed.y * Time.time),
			MovementScale.z * Mathf.Sin (MovementSpeed.z * Time.time)
		);

		this.transform.rotation = RootRotation * Quaternion.Euler(
			RotationScale.x * Mathf.Sin (RotationSpeed.x * Time.time),
			RotationScale.y * Mathf.Sin (RotationSpeed.y * Time.time),
			RotationScale.z * Mathf.Sin (RotationSpeed.z * Time.time)
		);
        timeOut -= Time.deltaTime;
        if (GameStateManager.Instance.satActual > 0.7f && timeOut < 0)
        {
			if (anim.GetBool ("Show") == false) {
				appearSound.Play ();
			}
            anim.SetBool("Show", true);
        }
        else
        {
            anim.SetBool("Show", false);
        }
	}

    public void Show()
    {
        anim.SetBool("Show", true);
    }

    public void Hide()
    {
        anim.SetBool("Show", false);
    }

    public IEnumerator Eat(GameObject food)
    {
        Debug.Log("Horsie ate the " + food.name);

		// Heart Particle for eating
		if (!transform.Find ("FX_Heart").GetComponent<ParticleSystem> ().isPlaying) {
			transform.Find ("FX_Heart").GetComponent<ParticleSystem> ().Play ();
		}

        // Reward
        GameStateManager.Instance.AdjustSaturation(+0.3f);
        anim.SetBool("Chew", true);

		// Food position change
		food.transform.position = new Vector3 (0f,-1f,0.5f);

        if (eatingSound)
        {
            eatingSound.Play();
        }
        yield return null;
        anim.SetBool("Chew", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Horsie's mouth collided with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Food")
        {
            StartCoroutine(Eat(collision.gameObject));
        }
        else
        {
            if (collision.gameObject.tag == "Weapon")
            {
                timeOut = RespawnDelay;
                appearSound.Play();
            }
        }
    }

}
