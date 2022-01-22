using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventManager : Singleton<EventManager>
{
    [SerializeField] private TextMeshProUGUI eventname;
    [SerializeField] private TextMeshProUGUI eventlore;
    [SerializeField] private Image eventicon;
    public Image eventbg;
    private int war = 3;

    public void Event()
    {
        float random = RandomUtil.valueForProb;
        int Value = TimeManager.Instance.years - 5;
        eventbg.gameObject.SetActive(true);
        if(random <= 15)
        {
            Singleton<GameManager>.Instance.Status.Population -= 20 + Value;
            Singleton<GameManager>.Instance.Status.Happiness -= 5 + Value;
            eventname.text = "������ ����";
            eventlore.text = "����� ���̿��� ��...����� �ϴ� ������ �������� �����ϱ� �����߽��ϴ�.\n�α� ���� �����մϴ�.";
        }
        else if (random <= 27.5f)
        {
            Singleton<GameManager>.Instance.Status.Population -= 15 + Value;
            Singleton<GameManager>.Instance.Status.Happiness -= 25 + Value;
            Singleton<GameManager>.Instance.Status.Environment -= 5 + Value;
            war++;
            eventname.text = war + "�� ������� �ݹ�";
            eventlore.text = "�� �׷��Ե��� �� �ٽ� ������ �Ͼ���ϴ�. �ô����� �Ϸ� ���۵� �����̿�����, ���� �� ������ �ᱹ " + war + "�� ��������� �Ͼ�� ����� �ʷ��߽��ϴ�.\n������� ������ ���� �α� ���� �����մϴ�.";
        }
        else if (random <= 37.5f)
        {
            Singleton<GameManager>.Instance.Status.Environment -= 30 + Value;
            Singleton<GameManager>.Instance.Status.Resources -= 5 + Value;
            eventname.text = "���ڷ� ����";
            eventlore.text = "���ڷ� �����ҿ��� 5��� ���ڷ� ������ �߻��߽��ϴ�. �ֺ��� ����� ��� ���� ���� �θ� ���ش� �̹�������, �ֺ� ȯ���� ���ϰ� �����Ǿ����ϴ�.\nȯ���� �����մϴ�.";
        }
        else if (random <= 52.5f)
        {
            Singleton<GameManager>.Instance.Status.Resources -= 25 + Value;
            eventname.text = "�ڿ� ��";
            eventlore.text = "��� �� ������ ������ �ڿ� ä������ ������ ���Ǿ����ϴ�.\n�ڿ��� �����մϴ�";
        }
        else if (random <= 65f)
        {
            Singleton<GameManager>.Instance.Status.Environment -= 30 + Value;
            eventname.text = "��� ���� �߻�";
            eventlore.text = "����� ũ�� �߻��Ͽ� �ֺ� �긲�� ���� �簡 �Ǿ����ϴ�. ���� ���Ƿ� �θ����ش� �Ͼ�� �ʾ�����, ������ ���� ġ�����̰� �پ������ϴ�.\nȯ���� �����մϴ�.";
        }
        else if (random <= 77.5f)
        {
            Singleton<GameManager>.Instance.Status.Population -= 2;
            Singleton<GameManager>.Instance.Status.Happiness -= 30 + Value;
            eventname.text = "�ķ� ��";
            eventlore.text = "�� ����ü������ �ķ��� ��� �� �Ǿ����ϴ�. �̹� �ķ��� ��¼�� ��Ⱑ ������ �𸣰ڳ׿�.\n�ູ ������ �����մϴ�.";
        }
        else if (random <= 87.5f)
        {
            Singleton<GameManager>.Instance.Status.Population -= 10 + Value;
            Singleton<GameManager>.Instance.Status.Happiness -= 25 + Value;
            eventname.text = "���� ������";
            eventlore.text = "�� ���� �������� ������ ����ϴ� �����ڰ� �����Ͽ��ٰ� �մϴ�. �� ���� ���ε��� ������ ������ ���ݿ� �ô޸��ڱ���.\n�ູ ������ �����մϴ�.";
        }
        else if (random <= 100)
        {
            Singleton<GameManager>.Instance.Status.Population -= 2 ;
            Singleton<GameManager>.Instance.Status.Resources -= 20 + Value;
            eventname.text = "ȭ���� ħ��";
            eventlore.text = "���� �ϳ��� �츱 ������ ������ �ڿ����� �ű�� ȭ������ �ϼ��浹�� ���� �ٴ������ ����ɰ� ���ҽ��ϴ�.\n�ڿ��� �����մϴ�.";
        }
    }
}
