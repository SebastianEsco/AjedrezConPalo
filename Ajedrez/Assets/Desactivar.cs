using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar : MonoBehaviour
{
    ObjetoPieza pieza;
    public GameObject objeto;
    

    private void Start()
    {
        pieza = objeto.GetComponent<ObjetoPieza>();
    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if(!pieza.encima)
        {
            pieza.Desactivar();
        }
    }
}
