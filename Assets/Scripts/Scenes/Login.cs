using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [Header("LoginPanel")]
    public InputField IDInputField;
    public InputField PassInputField;
    [Header("AccountPanel")]
    public InputField New_IDInputField;
    public InputField New_PassInputField;

    public string LoginUrl;

    void Start()
    {
        LoginUrl = "localhost/Login/Login.php";
    }
    public void LoginBtn() 
    {
        StartCoroutine(LoginCo());
    }
    IEnumerator LoginCo()
    {
        Debug.Log(IDInputField.text);
        Debug.Log(PassInputField.text);
        if (IDInputField.text == "chopr159")
        {
            if (PassInputField.text == "gkdnem12")
            {
                Debug.Log("�α��ο� �����ϼ̽��ϴ�.");
                Managers.Scene.LoadScene(Define.Scene.TestScene);
            }

            else
            {
                Debug.Log("���̵�� ��й�ȣ�� �ٽ� Ȯ���� �ּ���.");
            }
        }
        else
        {
            Debug.Log("���̵�� ��й�ȣ�� �ٽ� Ȯ���� �ּ���.");
        }
        yield return null;
    }
    public void CreateAccoutBtn()
    {
        //StartCoroutine(LoginCo());
    }
}
