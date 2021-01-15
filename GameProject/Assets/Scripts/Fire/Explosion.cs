using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Explosion : MonoBehaviour
{
    private float timeRemaining = 5;
    bool isExploding = false;

    private float radius = 5.0f;

    public GameObject myPrefab;

    [SerializeField]
    private GameObject life;


    private float valOfLifeRemoved;
    private float percentageOfLifeRemoved = 10.0f;

    bool exploded = true;


    // Start is called before the first frame update
    void Start()
    {
        valOfLifeRemoved = life.transform.localScale.x * percentageOfLifeRemoved / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(exploded)
            RangeDamge();
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0 && isExploding == false)
        {
            timeRemaining = 10;
            isExploding = true;
            Instantiate(myPrefab, new Vector3(10, 0, -33), Quaternion.identity);
            Destroy(myPrefab);
        }

    }

    public void RangeDamge()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliders)
        {

            Rigidbody rb = near.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (rb.tag.Equals("Player"))
                {
                    if (life.transform.localScale.x > 0)
                    {
                        life.transform.localScale = new Vector3(life.transform.localScale.x - valOfLifeRemoved, life.transform.localScale.y, life.transform.localScale.z);
                        exploded = false;
                        Destroy(myPrefab);
                    }
                }
            }
        }
    }
}
