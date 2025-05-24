using UnityEngine;

public class CatapultaController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; //Evita que tombe ao girar
    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        //Calcula a direcao do movimento
        Vector3 moveDirection = -transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;

        //Move o canhao
        rb.MovePosition(rb.position + moveDirection);

        //Rotaciona o canhnao
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * turnInput * turnSpeed * Time.fixedDeltaTime));
    }
}
