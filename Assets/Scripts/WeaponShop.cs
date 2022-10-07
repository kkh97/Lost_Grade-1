using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponShop : MonoBehaviour
{
    List<string> WeaponList = new List<string>()
    {
        {"PickAxe"},
        {"SteelAxe"},
        {"RecurveBow"}
    };

    Dictionary<string, int> SelectedList = new Dictionary<string, int>();

    //public Action<PointerEventData> OnClickHandler = null;

    public void Enter(PlayerStat _playerStat)
    {
        if (GameObject.Find("Weapon_Shop") == null)
        {
            Managers.Resource.Instantiate("Weapon_Shop", GameObject.Find("Item Shop Group").transform);
        }
    }

    public void Exit()
    {
        if (GameObject.Find("Weapon_Shop") != null)
            Managers.Resource.Destroy(GameObject.Find("Weapon_Shop"));
        WeaponList.Clear();
        SelectedList.Clear();
    }

    // �۾� ��... : ������ ���ý� ���õ� ������ â(��ư)�� ������ ����ϴ� ���� �߰� �ʿ�
    public void SelectItem()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "Button_SelectPickAxe")
        {
            Debug.Log("PickAxe selected");
            
            if (SelectedList.ContainsKey("PickAxe"))
                SelectedList["PickAxe"] += 1;
            else
                SelectedList.Add("PickAxe", 1);

            // ����Ʈ �� �ö󰬴��� Ȯ�ο�
            foreach(KeyValuePair<string, int> item in SelectedList)
                Debug.Log(item.Key + " : " + item.Value);

            // if(SelectedList.Count < 3)
            // Texture2D?texture?=?(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Textures/texture.jpg",?typeof(Texture2D));
            // GameObject?obj?=?(GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefab/player.prefab",?typeof(GameObject));
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Button_SelectSteelAxe")
        {
            Debug.Log("SteelAxe selected");
            
            if (SelectedList.ContainsKey("SteelAxe"))
                SelectedList["SteelAxe"] += 1;
            else
                SelectedList.Add("SteelAxe", 1);

            // ����Ʈ �� �ö󰬴��� Ȯ�ο�
            foreach (KeyValuePair<string, int> item in SelectedList)
                Debug.Log(item.Key + " : " + item.Value);
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Button_SelectRecurveBow")
        {
            Debug.Log("RecurveBow selected");

            if (SelectedList.ContainsKey("RecurveBow"))
                SelectedList["RecurveBow"] += 1;
            else
                SelectedList.Add("RecurveBow", 1);

            // ����Ʈ �� �ö󰬴��� Ȯ�ο�
            foreach (KeyValuePair<string, int> item in SelectedList)
                Debug.Log(item.Key + " : " + item.Value);
        }
    }

    // ���õȰ� Ŭ�� ���� �� ��� �ϴ� �� �߰� ���� : �ش� ��ư�� ��ϵ� �������� null�� �ƴ϶�� �̸��� Ȯ�� �� SelectedList���� ��������
    public void deleteItem()
    {
        /*
        if()
        {
            
        }
        */
    }
}
