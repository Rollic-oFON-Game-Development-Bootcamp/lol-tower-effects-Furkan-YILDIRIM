using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private ParticleSystem trailEffect;

    private Transform target;

    bool test = false;

    public void Shoot(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target != null)
        {

            //transform.position += Vector3.Lerp(transform.position, target.transform.position, 1);

            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 5);

            if (Vector3.Distance(transform.position,target.transform.position) < 0.0001f && !test)
            {
                trailEffect.Stop();
                test = true;
                explosionEffect.transform.position = target.transform.position;
                explosionEffect.Play();
                Destroy(gameObject, explosionEffect.main.startLifetime.constant);

            }
        }
    }

}
