using System.Collections;
using UnityEngine;

public class PrefabBehavior : MonoBehaviour
{
    public GameController game;

    public GameObject explosaoPrefab;
    public float radius = 5f;
    public float explositionForce = 700f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<GameController>();

        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Catapulta"))
        {
            Instantiate(explosaoPrefab, gameObject.transform.position, Quaternion.identity);

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider nearbyObjectCollider in colliders)
            {

                Rigidbody rigidbody = nearbyObjectCollider.GetComponent<Rigidbody>();

                if (rigidbody != null)
                {

                    rigidbody.AddExplosionForce(explositionForce, transform.position, radius, explositionForce);
                    Destroy(explosaoPrefab);
                }

            }



        }
           



        if (collision.collider.CompareTag("+10"))
        {
            //Debug.Log("colidiu com o mago");
            game.pontos += 10;
        }
        if (collision.collider.CompareTag("+25"))
        {
            //Debug.Log("colidiu com o mago");
            game.pontos += 25;
        }
        if (collision.collider.CompareTag("+50"))
        {
            //Debug.Log("colidiu com o mago");
            game.pontos += 50;

        }
        if (collision.collider.CompareTag("+5"))
        {
            //Debug.Log("colidiu com o mago");
            game.pontos += 5;
        }
    }
}
