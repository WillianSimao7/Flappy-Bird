using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rig;
    public float jumpForce;

    private Vector3 startPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rig.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.status)
        {
            case GameStatus.Start:
                StartUpdate();
                break;
            case GameStatus.Play:
                PlayUpdate();
                break;
            case GameStatus.GameOver:
                GameOverUpdate();
                break;
        }
    }

    public void StartGame()
    {
        rig.bodyType = RigidbodyType2D.Dynamic;
        Jump();
    }

    //Aparece a tela, mas o jogo ainda não começou
    void StartUpdate()
    {
       
    }

    //O jogo está rolando
    void PlayUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    //Perdeu o jogo
    void GameOverUpdate()
    {

    }

    void Jump()
    {
        rig.velocity = Vector3.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }

    public void Restart()
    {
        transform.position = startPosition;
        rig.bodyType = RigidbodyType2D.Static;
    }
}