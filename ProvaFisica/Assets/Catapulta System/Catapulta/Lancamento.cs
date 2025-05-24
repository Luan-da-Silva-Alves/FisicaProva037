using System.Collections;
using UnityEngine;

public class Lancamento : MonoBehaviour
{
    public HingeJoint hinge;

    public float maxRecuo = 0f;      // Até onde a catapulta pode recuar
    public float recuoSpeed = 50f;     // Velocidade ao recuar (mouse pressionado)
    public float lancamentoSpeed = 1000f; // Velocidade ao lançar (mouse solto)

    public bool isLaunching = false;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();

        // Configura limites do hinge
        JointLimits limits = hinge.limits;
        limits.min = maxRecuo;
        limits.max = 60f;
        hinge.limits = limits;
        hinge.useLimits = true;

        hinge.useMotor = true;
    }

    void Update()
    {
        if (isLaunching) return;

        JointMotor motor = hinge.motor;

        if (Input.GetMouseButton(0))
        {
            // Recuar enquanto segura o botão
            motor.force = 100f;
            motor.targetVelocity = -recuoSpeed;
            hinge.motor = motor;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Soltou o botão → lançar
            StartCoroutine(Lancar());
        }
        else
        {
            // Sem input → manter parado
            motor.targetVelocity = 0f;
            hinge.motor = motor;
        }
    }

    IEnumerator Lancar()
    {
        isLaunching = true;

        JointMotor motor = hinge.motor;
        motor.force = 1000f;
        motor.targetVelocity = lancamentoSpeed; // movimento rápido pra frente
        hinge.motor = motor;

        yield return new WaitForSeconds(0.4f);

        // Parar movimento após lançamento
        motor.targetVelocity = 0f;
        hinge.motor = motor;

        isLaunching = false;
    }


}
