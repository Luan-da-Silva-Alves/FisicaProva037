using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int pontos = 0;
    public TextMeshProUGUI txtPontos;

    public CenaManager cena;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        if (cena == null)
            cena = GameObject.Find("Cena").GetComponent<CenaManager>();

        if (txtPontos == null && cena.cenaIndex == 1)
        {
            txtPontos = GameObject.Find("TxtPontuacao").GetComponent<TextMeshProUGUI>();
        }

        if (txtPontos != null)
            txtPontos.text = "Pontos: " + pontos;

        if (pontos >= 500)
        {
            pontos = 500;
            Debug.Log("Fim da fase");
        }
    }

}
