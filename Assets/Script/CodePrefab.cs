using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePrefab : MonoBehaviour {
    public int X;
    public int Y;
    private Grid.CodeType type;
    private Grid grid;
    private CodeMove MoveComponent;
    private CodeColor ColorComponent;
    public AnimationClip clearAnimation;

    public int getX {
        get { return X; }
        set { X = value; }
    }

    public int getY {
        get { return Y; }
        set { Y = value; }
    }

    public Grid getGrid {
        get { return grid; }
    }

    public Grid.CodeType getCodeType {
        get { return type; }
    }

    public CodeMove getMoveComponent {
        get {
            if (MoveComponent == null || MoveComponent.CodePrefabCompent == null) {
                MoveComponent = GetComponent<CodeMove>();
                MoveComponent.initMoveCompent(this);
            }
            return MoveComponent;
        }
    }

    public CodeColor getColorComponent {
        get {
            if (ColorComponent == null) {
                ColorComponent = GetComponent<CodeColor>();
            }
            return ColorComponent;
        }
    }

    public void initPos(int x, int y, Grid grid_ , Grid.CodeType codeT) {
        X = x;
        Y = y;
        grid = grid_;
        type = codeT;
    }

    //清除该方块
    public void ClearCode() {
        StartCoroutine(clear());
    }

    private IEnumerator clear() {
        Animator a = GetComponent<Animator>();
        if (a)
        {
            a.Play(clearAnimation.name);

            yield return new WaitForSeconds(clearAnimation.length);

            Destroy(gameObject);
        }
    }
}
