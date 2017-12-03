using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeColor : MonoBehaviour {

    public enum ColorType {
        YELLOW,
        GREEN,
        VIOLET,
        PINK,
        BLUE,
        RED,
    }

    [System.Serializable]
    public struct ColorSprite {
        public ColorType colorType;
        public Sprite colorsprite;
    }
    
    public ColorSprite[] Sprites;

    //颜色字典
    public Dictionary<ColorType, Sprite> ColorDic;

    //当前颜色状态
    public ColorType Spritecolor;

    public ColorType getColor {
        get { return Spritecolor; }
        set { Spritecolor = value; }
    }

    private SpriteRenderer spriteCompent;

    private void Awake()
    {
        spriteCompent = transform.Find("code").GetComponent<SpriteRenderer>();

        ColorDic = new Dictionary<ColorType, Sprite>();

        for (int i = 0; i < Sprites.Length; i++) {
            if (!ColorDic.ContainsKey(Sprites[i].colorType)) {
                ColorDic.Add(Sprites[i].colorType, Sprites[i].colorsprite);
            }
        }


    }

    //指定颜色
    public void setSprite(ColorType colorType_) {

        Spritecolor = colorType_;

        if (ColorDic.ContainsKey(colorType_)) {
            spriteCompent.sprite = ColorDic[colorType_];
        }
    }

    //随机指定颜色
    public void setRangeSprite() {
        int ran = Random.Range(0 , Sprites.Length);
        Spritecolor = (ColorType)ran;

        if (ColorDic.ContainsKey(Spritecolor))
        {
            spriteCompent.sprite = ColorDic[Spritecolor];
        }
    }
}
