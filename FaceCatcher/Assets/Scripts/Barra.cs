using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    public Slider slider;
    public GameObject cabeca;
    public int blendshapeID;
    public static float var_queixo;
    public static float var_grosso;
    public static float var_frente;
    public static float var_testa;
    public static float var_olho1;
    public static float var_boca;
    public static float var_bofrente;
    public static float var_tamanho;
    public static float var_olho2; 

    void Awake(){
        slider = GetComponentInParent<Slider>();
    }

    void Update()
    {
        cabeca.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(blendshapeID, slider.value);
        if(blendshapeID == 0){
            var_queixo = slider.value;
        }else if(blendshapeID == 1){
            var_grosso = slider.value;
        }else if(blendshapeID == 2){
            var_frente = slider.value;
        }else if(blendshapeID == 3){
            var_testa = slider.value;
        }else if(blendshapeID == 4){
            var_olho1 = slider.value;
        }else if(blendshapeID == 5){
            var_boca = slider.value;
        }else if(blendshapeID == 6){
            var_bofrente = slider.value;
        }else if(blendshapeID == 7){
            var_tamanho = slider.value;
        }else if(blendshapeID == 8){
            var_olho2 = slider.value;
        }
    }
}
