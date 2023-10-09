using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class StageSelectManager : MonoBehaviour
{
    int cursor = 0;
    int prevCursor = 0;
    int stageNum = 3;

    [SerializeField] GameObject stage1Go;
    [SerializeField] GameObject stage2Go;
    [SerializeField] GameObject stage3Go;
    List<GameObject> stages = new List<GameObject>();

    [SerializeField] TMP_Text testText;

    Color selectColor = new Color(0f, 1f, 0f);
    Color normalColor = new Color(1f, 1f, 1f);

    private void Start()
    {
        stages.Add(stage1Go);
        stages.Add(stage2Go);
        stages.Add(stage3Go);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("������");
            cursor++;
            SelectStage();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("����");
            cursor--;
            SelectStage();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveStage();
        }
    }

    // Ŀ���� ��ġ�� ��ư�� �ܰ��� ǥ��
    void SelectStage()
    {
        cursor += stageNum;
        cursor %= stageNum;

        stages[prevCursor].GetComponent<Image>().color = normalColor;
        stages[cursor].GetComponent<Image>().color = selectColor;

        prevCursor = cursor;
        Debug.Log("���� �������� �ε���: " + cursor);
    }

    // �ش� ���������� �̵�
    void MoveStage()
    {
        EventSystem.current.SetSelectedGameObject(stages[cursor]);
    }

    // �ӽ�
    public void LoadStage1Scene()
    {
        testText.text = "Load Stage 1";
    }

    public void LoadStage2Scene()
    {
        testText.text = "Load Stage 2";
    }

    public void LoadStage3Scene()
    {
        testText.text = "Load Stage 3";
    }
}
