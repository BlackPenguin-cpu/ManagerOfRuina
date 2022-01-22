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
            eventname.text = "전염병 유행";
            eventlore.text = "사람들 사이에서 코...뭐라고 하는 강력한 전염병이 유행하기 시작했습니다.\n인구 수가 감소합니다.";
        }
        else if (random <= 27.5f)
        {
            Singleton<GameManager>.Instance.Status.Population -= 15 + Value;
            Singleton<GameManager>.Instance.Status.Happiness -= 25 + Value;
            Singleton<GameManager>.Instance.Status.Environment -= 5 + Value;
            war++;
            eventname.text = war + "차 세계대전 반발";
            eventlore.text = "늘 그래왔듯이 또 다시 전쟁이 일어났습니다. 시덥잖은 일로 시작된 전쟁이였지만, 점점 더 격해져 결국 " + war + "차 세계대전이 일어나는 결과가 초래했습니다.\n사람들이 공포에 떨고 인구 수가 감소합니다.";
        }
        else if (random <= 37.5f)
        {
            Singleton<GameManager>.Instance.Status.Environment -= 30 + Value;
            Singleton<GameManager>.Instance.Status.Resources -= 5 + Value;
            eventname.text = "원자력 폭발";
            eventlore.text = "원자력 연구소에서 5등급 원자력 폭발이 발생했습니다. 주변에 사람이 사는 곳이 없어 인명 피해는 미미하지만, 주변 환경이 심하게 오염되었습니다.\n환경이 감소합니다.";
        }
        else if (random <= 52.5f)
        {
            Singleton<GameManager>.Instance.Status.Resources -= 25 + Value;
            eventname.text = "자원 고갈";
            eventlore.text = "어느 한 나라의 과도한 자원 채집으로 광맥이 고갈되었습니다.\n자원이 감소합니다";
        }
        else if (random <= 65f)
        {
            Singleton<GameManager>.Instance.Status.Environment -= 30 + Value;
            eventname.text = "산불 사태 발생";
            eventlore.text = "산불이 크게 발생하여 주변 산림이 전부 재가 되었습니다. 빠른 대피로 인명피해는 일어나지 않았지만, 나무의 수가 치명적이게 줄어들었습니다.\n환경이 감소합니다.";
        }
        else if (random <= 77.5f)
        {
            Singleton<GameManager>.Instance.Status.Population -= 2;
            Singleton<GameManager>.Instance.Status.Happiness -= 30 + Value;
            eventname.text = "식량 고갈";
            eventlore.text = "한 공동체에서의 식량이 모두 고갈 되었습니다. 이번 식량은 어쩌면 고기가 될지도 모르겠네요.\n행복 지수가 감소합니다.";
        }
        else if (random <= 87.5f)
        {
            Singleton<GameManager>.Instance.Status.Population -= 10 + Value;
            Singleton<GameManager>.Instance.Status.Happiness -= 25 + Value;
            eventname.text = "무력 지배자";
            eventlore.text = "한 나라에 무력으로 정권을 장악하는 독재자가 등장하였다고 합니다. 그 곳의 국민들은 과도한 업무와 세금에 시달리겠군요.\n행복 지수가 감소합니다.";
        }
        else if (random <= 100)
        {
            Singleton<GameManager>.Instance.Status.Population -= 2 ;
            Singleton<GameManager>.Instance.Status.Resources -= 20 + Value;
            eventname.text = "화물선 침몰";
            eventlore.text = "마을 하나를 살릴 정도의 귀중한 자원들을 옮기던 화물선이 암석충돌로 인해 바닷속으로 가라앉고 말았습니다.\n자원이 감소합니다.";
        }
    }
}
