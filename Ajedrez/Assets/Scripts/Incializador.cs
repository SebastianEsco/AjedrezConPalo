using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class Incializador : MonoBehaviour
{
    public GameObject[] piezas = new GameObject[32];
    ObjetoPieza[] scriptPieza = new ObjetoPieza[32];

    private void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            if (piezas[i] != null)
            {
                scriptPieza[i] = piezas[i].GetComponent<ObjetoPieza>();
            }
        }
    }

    public void DesactivacionMasiva()
    {
        for (int i = 0; i < piezas.Length; i++)
        {
            if (scriptPieza[i] != null)
            {
                scriptPieza[i].Desactivar();
            }
        }
    }

    private void OnMouseDown()
    {
        DesactivacionMasiva();
    }

    public int HabilitacionDeMovimientoVertical(Pieza pieza)
    {
        Debug.Log("Entra");

        //BLANCAS AL LIMITE
        if(pieza.color == 1)
        {
            if(pieza.posicion[1] == 4)
            {
                return 0;
            }
            
            
        }

        //NEGRAS AL LIMITE
        if(pieza.color == 0 )
        {
            if(pieza.posicion[1] == -3)
            {
                return 0;
            }
            
            
        }


        for (int i = 0; i < 16; i++)
        {
            if (piezas[i] != null)
            {
                if (pieza.posicion[1] + 1f == piezas[i].transform.position.y)
                {
                    Debug.Log(pieza.posicion[1] + 1 + " .... vs .... " + piezas[i].transform.position.y);
                    return 0;
                }
            }
        }
        for (int i = 0; i < 16; i++)
        {
            if (piezas[i] != null)
            {
                if (pieza.posicion[1] + 2f == piezas[i].transform.position.y)
                {
                    Debug.Log(pieza.posicion[1]+ 1 + " .... vs .... " + piezas[i].transform.position.y);
                    return 1;
                }
            }
        }
        Debug.Log("retornando 2");
        return 2;

    }

}
