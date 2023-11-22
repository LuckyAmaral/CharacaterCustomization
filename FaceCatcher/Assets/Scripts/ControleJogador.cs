using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//adiciona o componente CharacterController automaticamente
[RequireComponent(typeof(CharacterController))]

public class ControleJogador : MonoBehaviour
{
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    private bool powerUp = false;
    public Animator animacao;
    private bool aereo = false;
    private float curSpeedX =0.0f;
    private float curSpeedY =0.0f;
    private AudioSource somPulo;
	private AudioSource somMusica1;
	private AudioSource somMusica2;
    private AudioSource somMoeda;
    private AudioSource somPorta;
    private int contagem =0;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;

        somMusica1 = GetComponents<AudioSource>()[0];
	    somPulo = GetComponents<AudioSource>()[2];
	    somMusica2 = GetComponents<AudioSource>()[1];
        somMoeda = GetComponents<AudioSource>()[3];
        somPorta = GetComponents<AudioSource>()[4];
    }
void Update()
    {
        if (characterController.isGrounded)
        {
            // Se o jogador estiver no chão, então pode se mover
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            curSpeedX =  speed * Input.GetAxis("Vertical") *-1;
            curSpeedY = speed * Input.GetAxis("Horizontal") *-1;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                somPulo.Play();
                aereo = true;
            }
        }
        animacao.SetBool("Air",aereo);
        // Aplica gravidade
        moveDirection.y -= gravity * Time.deltaTime;

        // Move o jogador
        characterController.Move(moveDirection * Time.deltaTime);

        // Gira a Câmera
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;

        rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
        playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        transform.eulerAngles = new Vector2(0, rotation.y);
        animacao.SetInteger("VeloX",(int)curSpeedX);
        animacao.SetInteger("VeloY",(int)curSpeedY);
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Estrela")){
            somMusica1.Stop();
	        somMusica2.Play();
            other.gameObject.SetActive(false);
            powerUp = true;
        }else if(other.gameObject.CompareTag("Enemy")){
            if(powerUp == true){
                other.gameObject.SetActive(false);
            }else{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }else if(other.gameObject.CompareTag("Moeda")){
	        somMoeda.Play();
            contagem++;
            other.gameObject.SetActive(false);
        }else if(other.gameObject.CompareTag("Porta")){
            if(contagem > 0){
                other.gameObject.SetActive(false);
                contagem--;
                somPorta.Play();
            }
        }
    }
    void OnCollisionEnter(Collision col) {
        aereo = false;
    }
}

