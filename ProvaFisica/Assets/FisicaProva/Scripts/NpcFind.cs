using UnityEngine;

public class NpcFind : MonoBehaviour
{

    public AnimationToRagdoll[] npcs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        npcs = GameObject.Find("NPCS").GetComponentsInChildren<AnimationToRagdoll>();

        if (npcs.Length > 0) return;
        CenaManager cena = GameObject.Find("Cena").GetComponent<CenaManager>();
        cena.Reiniciar();
        
    }
}
