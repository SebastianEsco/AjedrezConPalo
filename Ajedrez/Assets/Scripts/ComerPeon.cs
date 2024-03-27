using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComerPeon : MonoBehaviour
{
    ObjetoPieza scriptPieza;
    public GameObject pieza;
    void Start()
    {
        scriptPieza = pieza.GetComponent<ObjetoPieza>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (scriptPieza.comerDerecha)
        {
            scriptPieza.Comer(true);
            
        }
        else if(scriptPieza.comerIzquierda)
        {
            scriptPieza.Comer(false);
        }
    }
}
