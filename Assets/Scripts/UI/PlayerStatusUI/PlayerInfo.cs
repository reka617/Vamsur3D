using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : UIBase
{
    private Image _thumbnailImage;
    private TMP_Text _lvText;
    private string _thumbnailPath;
    private int _lv;

    public override void Init()
    {
        _thumbnailImage = transform.Find("ThumbFrame/ThumbMask/Thumb").GetComponent<Image>();
        _lvText = transform.Find("LvFrame/LvText").GetComponent<TMP_Text>();
    }

    public void SetThumbnail(string path)
    {
        _thumbnailPath = path;
        Sprite thumb = Resources.Load<Sprite>(_thumbnailPath);
        _thumbnailImage.sprite = thumb;
    }

    public void SetLv(int lv)
    {
        _lv = lv;
        _lvText.text = _lv.ToString();
    }
}
