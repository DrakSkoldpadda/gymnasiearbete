using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(Transform target)
    {
        float step = speed * Time.deltaTime;

        Vector3.MoveTowards(transform.position, target.position, step);

        //target.GetComponent<Health>().TakeDamage(damage);
    }
}
