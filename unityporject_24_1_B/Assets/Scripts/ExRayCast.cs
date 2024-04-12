using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                                   //UI�� ����ϱ� ���ؼ�
using UnityEngine.SceneManagement;                                      //Scene �̵� �ϱ� ���ؼ�

public class ExRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int Point = 0;                                          //����Ʈ ��� ����
    public GameObject TargetObject;                                //Ÿ�� ������
    public float CheckTime = 0;                                     //Ÿ�� Gen �ð� ����
    public float GameTime = 30.0f;                                  //���� �ð� ����

    public Text pointUI;                                           //Unity UI ����
    public Text timeUI;                                              //Unity UI ����
    // Update is called once per frame
    void Update()
    {
        CheckTime += Time.deltaTime;                   //������ �����Ǿ�ð��� ����ϰ� �Ѵ�
        GameTime -= Time.deltaTime;                    //������ �ð��� �����Ͽ� 30�� -> 0�ʷ� ���� �Ѵ�.

        if(GameTime <= 0)                             //0�ʰ� �Ǹ� 
        {
            PlayerPrefs.SetInt("Point", Point);        //����Ƽ���� �����ϴ� �����Լ�
            SceneManager.LoadScene("MainScene");         //MainScene���� �̵��Ѵ�.
        }

        pointUI.text = "���� ; " + Point.ToString();                         //UI���� ǥ��
        timeUI.text = "���� �ð� ; " + GameTime.ToString() + "s";            //UI ���� �ð� ǥ��

        if(CheckTime >= 0.5f)                          //0.5�� ���� �ൿ�� �Ѵ�.
        {
            int RamdomX = Random.Range(0, 12);         //0~11������ �������� �̾Ƴٴ�.
            int RandomY = Random.Range(0, 12);         //0~11������ �������� �̾Ƴٴ�.
            GameObject temp = Instantiate(TargetObject);            //Instantiacte �Լ��� ���ؼ� �������� �����Ѵ�.
            temp.transform.position = new Vector3(-6 + RamdomX, -6 + RandomY, 0);      //�������� ���ؼ� -6 ~ 5 ������ ���� �����ϰ� ��ġ
            Destroy(temp, 1.0f);                                                      //���� �� �ı��� 1���Ŀ� ���ش�.
            CheckTime = 0;                                                           //�ð��� �ʱ�ȭ ���ش�. (0.5�� ���� �ݺ��ϰ� �ϱ� ���ؼ�)
        }

        if (Input.GetMouseButtonDown(1))       //���콺 ������ ��ư�� ������ ���
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);    //ī�޶� ȭ�� �������� ���콺 �����ǿ��� Ray�� ���.

            RaycastHit hit;

            if(Physics.Raycast(cast, out hit))        //Ray�� ����Ȱ��� ������
            {
                Debug.Log(hit.collider.gameObject.name);         //����� ������Ʈ �̸��� ����� �ش�.

                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);     //Ray�� �������� ǥ�� ���ִ� �Լ�.

                if(hit.collider.gameObject.tag == "Target")                     //����� ������Ʈ�� Tag �� Target�� ���
                {
                    Point += 1;                                            //�ı� ���� 1���� �ش�.
                    Destroy(hit.collider.gameObject);
                }
            }
        }      
    }
}