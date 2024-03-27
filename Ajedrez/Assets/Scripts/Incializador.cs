using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class Incializador : MonoBehaviour
{
    public GameObject[] piezas = new GameObject[16];
    ObjetoPieza[] scriptPieza = new ObjetoPieza[16];

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

}
