using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class Incializador : MonoBehaviour
{
    int contador;
    public GameObject[] piezas = new GameObject[32];
    ObjetoPieza[] scriptPieza = new ObjetoPieza[32];

    private void Start()
    {
        for (int i = 0; i < piezas.Length; i++)
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


        for (int i = 0; i < piezas.Length; i++)
        {
            if (piezas[i] != null)
            {
                if (pieza.posicion[1] + 1f == piezas[i].transform.position.y)
                {
                    if(pieza.posicion[0] == piezas[i].transform.position.x)
                    {
                        return 0;
                    }
                    
                }
            }
        }
        for (int i = 0; i < piezas.Length; i++)
        {
            if (piezas[i] != null)
            {
                if (pieza.posicion[1] + 2f == piezas[i].transform.position.y)
                {

                    if (pieza.posicion[0] == piezas[i].transform.position.x)
                    {
                        return 1;
                    }
                }
            }
        }
        return 2;

    }

    public bool[] HabilitarParaComer(Pieza peon)
    {
        bool[] ladoAComer = new bool[2];
        ladoAComer[0] = false;
        ladoAComer[1] = false;

        for (int i = 0; i < piezas.Length; i++)
        {
            if (piezas[i] != null)
            {
                
                if (peon.posicion[0] + 1f == piezas[i].transform.position.x && peon.posicion[1] + 1f == piezas[i].transform.position.y)
                { //Hay pieza arriba a la derecha
                    if (peon.color != scriptPieza[i].color)
                    {

                        ladoAComer[0] = true;
                    }
                }

                if (peon.posicion[0] - 1f == piezas[i].transform.position.x && peon.posicion[1] + 1f == piezas[i].transform.position.y)
                { //Hay pieza arriba a la izquierda
                    if (peon.color != scriptPieza[i].color)
                    {
                        ladoAComer[1] = true;
                    }
                }
            }

        }

        return ladoAComer;
    }

    public void DestruirObjeto(Pieza piezaQueComio)
    {
        for (int i = 0; i < piezas.Length; i++)
        {
            if (piezas[i] != null)
            {
                Debug.Log("Holi");
                if (piezaQueComio.color != scriptPieza[i].color)
                {
                    Debug.Log(piezaQueComio.posicion[0] + " .... Vs .... " + piezas[i].transform.position.x);
                    Debug.Log(piezaQueComio.posicion[1] + " .... Vs .... " + piezas[i].transform.position.y);
                    if (piezaQueComio.posicion[0] == piezas[i].transform.position.x && piezaQueComio.posicion[1] == piezas[i].transform.position.y)
                    {
                        Destroy(piezas[i]);
                    }
                }
                
            }

        }
    }

}
