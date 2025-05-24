using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaManager : MonoBehaviour
{
    public int cenaIndex;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cenaIndex = SceneManager.GetActiveScene().buildIndex;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Iniciar()
    {
        SceneManager.LoadScene("FisicaProva");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("FisicaProva");
    }
}
