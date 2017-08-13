using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horsie : MonoBehaviour {

	public Vector3 MovementScale = new Vector3 ();
	public Vector3 MovementSpeed = new Vector3 ();

	public Vector3 RotationScale = new Vector3 ();
	public Vector3 RotationSpeed = new Vector3 ();

    private AudioSource eatingSound;
    private Animator anim;

	private Vector3 RootPosition;
	private Quaternion RootRotation;

	// Use this for initialization
	void Start () {
        eatingSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

		RootPosition = this.transform.position;
		RootRotation = this.transform.rotation;
        Show();
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
        // Reward
        GameStateManager.Instance.AdjustSaturation(+0.3f);
        anim.SetBool("Chew", true);
        food.SetActive(false);
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
    }

}
