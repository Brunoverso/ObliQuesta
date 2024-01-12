using UnityEngine;
using UnityEngine.UI;

public class BallMovementController : MonoBehaviour
{
    public Slider sliderVelocidadeInicial;
    public Slider sliderAngulo;

    private Rigidbody rb;
    private bool movimentoIniciado = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.useGravity = false; // Desativar a gravidade para que o movimento seja apenas em x e y
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !movimentoIniciado)
        {
            IniciarMovimento();
        }
    }

    private void IniciarMovimento()
    {
        movimentoIniciado = true;
        float velocidadeInicial = sliderVelocidadeInicial.value;
        float angulo = sliderAngulo.value;

        float anguloRadianos = angulo * Mathf.Deg2Rad;
        float velocidadeInicialX = velocidadeInicial * Mathf.Cos(anguloRadianos);
        float velocidadeInicialY = velocidadeInicial * Mathf.Sin(anguloRadianos);

        Vector3 velocidadeInicialVector = new Vector3(velocidadeInicialX, velocidadeInicialY, 0);
        rb.velocity = velocidadeInicialVector;
        movimentoIniciado = false;
    }
}
