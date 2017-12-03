using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeMove : MonoBehaviour {
    private CodePrefab codePrefab;
    private IEnumerator MoveAnimtion;
    private bool isMoveing = false;

    public bool IsMoveIng {
        get { return isMoveing; }
    }

    public CodePrefab CodePrefabCompent {
        get { return codePrefab; }
    }
    public void initMoveCompent(CodePrefab code) {
        codePrefab = code;
    }

    public void MoveToPos(int X , int Y , float fillTime) {

        if (MoveAnimtion != null) {
            StopCoroutine(MoveAnimtion);
        }
        MoveAnimtion = Move(X , Y , fillTime);
        StartCoroutine(MoveAnimtion);
    }

    public void MoveBackToPos(int X, int Y, float fillTime) {
        if (MoveAnimtion != null)
        {
            StopCoroutine(MoveAnimtion);
        }
        MoveAnimtion = MoveBack(X , Y , fillTime);
        StartCoroutine(MoveAnimtion);
    }

    private IEnumerator Move(int newx , int newy , float fillTime) {
        isMoveing = true;

        codePrefab.getX = newx;
        codePrefab.getY = newy;

        Vector3 startPos = transform.position;
        Vector3 endPos = codePrefab.getGrid.NumToVector(newx , newy);

        for (float t = 0; t <= fillTime; t += Time.deltaTime) {

            transform.position = Vector3.Lerp(startPos, endPos, t / fillTime);

            yield return 0;
        }

        transform.position = endPos;

        isMoveing = false;
    }

    private IEnumerator MoveBack(int newx, int newy, float fillTime) {
        isMoveing = true;
        Vector3 startPos = transform.position;
        Vector3 endPos = codePrefab.getGrid.NumToVector(newx, newy);

        for (float t = 0; t <= fillTime; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t / fillTime);
            yield return 0;
        }

        yield return new WaitForSeconds(fillTime);
        transform.position = endPos;

        for (float t = 0; t <= fillTime; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(endPos, startPos, t / fillTime);
            yield return 0;
        }
        transform.position = startPos;
        isMoveing = false;
    }

    //鼠标按下时
    private void OnMouseDown()
    {
        if (!isMoveing)
        {
            CodePrefabCompent.getGrid.DownCode(CodePrefabCompent);
        }
    }
    //鼠标指向时
    private void OnMouseEnter()
    {
        if (!isMoveing) {
            CodePrefabCompent.getGrid.EnterCode(CodePrefabCompent);
        }
    }

    //鼠标抬起时
    private void OnMouseUp()
    {
        CodePrefabCompent.getGrid.UpCode();
    }
}
