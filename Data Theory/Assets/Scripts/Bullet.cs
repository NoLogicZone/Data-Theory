using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    void Awake()
    {
        StartCoroutine(Delete());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
