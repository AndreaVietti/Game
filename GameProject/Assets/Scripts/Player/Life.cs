using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    [SerializeField]
    private GameObject life;

    public Animator animator;

    private float percentageOfLifeRemoved = 20.0f;
    private float percentageOfLifeEarned = 10.0f;
    private float valOfLifeRemoved;
    private float lifeMediKit;

    public AudioClip mediKit;
    public AudioClip dangerKit;
    public AudioClip die;
    AudioSource audioSource;

    private bool endAnimation = false;

    // Use this for initialization
    void Start()
    {
        valOfLifeRemoved = life.transform.localScale.x * percentageOfLifeRemoved / 100;
        lifeMediKit = life.transform.localScale.x * percentageOfLifeEarned / 100;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life.transform.localScale.x <= 0)
        {
            StartCoroutine(death());
            if (endAnimation)
            {
                SceneManager.LoadScene("LoseMap");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            if (life.transform.localScale.x > 0) {
                life.transform.localScale = new Vector3(life.transform.localScale.x - valOfLifeRemoved, life.transform.localScale.y, life.transform.localScale.z);
            }
        }

        if (other.gameObject.tag.Equals("DangerKit"))
        {
            if (life.transform.localScale.x > 0)
            {
                audioSource.PlayOneShot(dangerKit, 0.1f);
                life.transform.localScale = new Vector3(life.transform.localScale.x - valOfLifeRemoved, life.transform.localScale.y, life.transform.localScale.z);
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("MediKit"))
        {
            if (life.transform.localScale.x < 1)
            {
                audioSource.PlayOneShot(mediKit, 0.1f);
                life.transform.localScale = new Vector3(life.transform.localScale.x + lifeMediKit, life.transform.localScale.y, life.transform.localScale.z);
            }
            Destroy(other.gameObject);
        }
    }

    private IEnumerator death()
    {
        animator.SetBool("death", true);
        audioSource.PlayOneShot(die, 0.01f);
        yield return new WaitForSeconds(3);
        endAnimation = true;
    }


}
