using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabeca : MonoBehaviour
{
        public GameObject cabeca;
    // Start is called before the first frame update
    void Start()
    {
        cabeca.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, Barra.var_queixo);
        cabeca.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, Barra.var_grosso);
        cabeca.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(2, Barra.var_frente);
        cabeca.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(3, Barra.var_testa);
        cabeca.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(4, Barra.var_olho1);
        cabeca.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(5, Barra.var_boca);
        cabeca.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(6, Barra.var_bofrente);
        cabeca.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(7, Barra.var_tamanho);
        cabeca.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(8, Barra.var_olho2);
    }

}
