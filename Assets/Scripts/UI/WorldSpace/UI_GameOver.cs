using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : UI_Base
{
    //�ٸ� ��ũ��Ʈ������ �� ��ũ��Ʈ�� ���� ������ �� �ֵ��� �ϱ����� �������� ����
    public static UI_GameOver instance;

    public Text gameOver;

    Animator anim;

    enum GameObjects
    {
        GameOver
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        anim = gameOver.gameObject.GetComponent<Animator>();

        gameOver.enabled = false;
    }

    public void ShowGameOver()
    {
        gameOver.enabled = true;

        anim.CrossFade("GameOver", 0.1f, -1, 0);
    }

    public void HideGameOver()
    {
        gameOver.enabled = false;
    }

    void Update()
    {

    }
}