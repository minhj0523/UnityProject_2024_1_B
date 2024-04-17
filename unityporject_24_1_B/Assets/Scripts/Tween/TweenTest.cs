using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;               //DoTween�� ����ϱ� ����

public class ExTween : MonoBehaviour
{
    Tween tween;
    Sequence sequence;
    // Start is called before the first frame update
    void Start()
    {
        //transform.DOMoveX(5, 0.5f);                         //Tween�� ���ؼ� ������Ʈ�� X������ 0.5�ʵ��� 5��ŭ ����. 

        // transform.DORotate(new Vector3(0, 0, 180), 0.3f);         //Tween�� ���ؼ� ������Ʈ�� X������ 0.5�ʵ��� 180�� ��ŭ ȸ���Ѵ�.
        // transform.DOScale(new Vector3(2, 2, 2), 2);              //Tween�� ���ؼ� ������Ʈ�� 2�ʵ��� 2��� Ŀ����.

        //Sequence sequence = DOTween.Sequence();               //�������� �����Ѵ�. (���� Tween�� ������ ���� Ʈ
        //sequence.Append(transform.DOMoveX(0, 0.5f));
        //sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 0.3f));
        //sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 2));

        //transform.DOMoveX(0, 0.5f).SetEase(Ease.OutBounce).OnComplete(DeactivateObject);           //���Ҷ� ȿ���� �߰� ��ų �� �ִ�.   (Ease.OutBounce)
        //transform.DOShakeRotation(0.5f, new Vector3(0, 0, 5), 10, 90);      //�̵��ϴ� ���� ȸ�� ��� �߰�


        sequence = DOTween.Sequence();               //�������� �����Ѵ�.
        sequence.Append(transform.DOMoveX(5, 2f));            //������ �߰�
        sequence.SetLoops(-1, LoopType.Yoyo);                //������ ���������� �ɼǵ� ����
    }


    void DeactivateObject()                         //������ ����� ���Ŀ� �Լ��� ȣ��
    {
        gameObject.SetActive(false);                //������Ʈ�� ����.
        Debug.Log("���� ����");        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))      //�����̽��ٸ� ������
        {
            sequence.Kill();                      //�ش� �������� �����Ѵ�.
            //tween.Kill();                       //�ش� Ʈ���� �����Ѵ�.
        }
    }
}
