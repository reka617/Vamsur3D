using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] GameObject CharacterMenuPanel;
    [SerializeField] GameObject CharacterInfoMenuPanel;
    [SerializeField] GameObject CharacterBox;
    [SerializeField] GameObject CharacterInfoBox;
    [SerializeField] Transform _characterContent;
    [SerializeField] GameObject WeaponUpgradeMenuPanel;
    [SerializeField] GameObject WeaponBox;
    [SerializeField] Transform _weaponContent;
    [SerializeField] GameObject WeaponSelectPanel;
    [SerializeField] GameObject _settingsMenu;
    List<GameObject> infoBoxTmps = new List<GameObject>();

    // Start is called before the first frame update
    public void OnSelectCharacterMenu()
    {
        CharacterMenuPanel.SetActive(true);
        initCharaterSelectBox();
    }

    public void OpenSelectCharacterPanel(Define.HeroType hType, Define.WeaponType wType)
    {

        CharacterInfoMenuPanel.SetActive(true);
        CharacterInfoMenuPanel.GetComponent<CharacterInfoMenu>().SetData(hType, wType);
    }

    public void OnSelectWeaponUpgradeMenu()
    {
        WeaponUpgradeMenuPanel.SetActive(true);
        initWeaponSelectBox();
    }

    public void OnSettingsMenu()
    {
        _settingsMenu.SetActive(true);
    }

    public void OpenSelectWeaponPanel(Define.WeaponType type)
    {
        WeaponSelectPanel.SetActive(true);
        WeaponSelectPanel.GetComponent<WeaponInfoMenu>().SetData(type);
    }

    public void initCharaterSelectBox()
    {
        if (infoBoxTmps.Count != 0) return;
        List<Define.HeroType> heroTypes = new List<Define.HeroType>(GenericSingleton<DataManager>.getInstance().HeroDict.Keys);
        Debug.Log(heroTypes);
        foreach(Define.HeroType heroType in heroTypes)
        {
            Define.Hero heroInfo = GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType);

            GameObject infoBoxTmp = Instantiate(CharacterBox, _characterContent);
            infoBoxTmp.GetComponent<SelectedInfoBox>().Init(CharacterMenuPanel.GetComponent<CharacterBoxController>());
            infoBoxTmp.GetComponent<SelectedInfoBox>().SetData(heroInfo.thumbnailPath, heroType.ToString(), heroType);
            infoBoxTmp.name = "CharacterBox";

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((eventData) => { infoBoxTmp.GetComponent<SelectedInfoBox>().OnClickedCharacterBox(); });

            infoBoxTmp.GetComponent<EventTrigger>().triggers.Add(entry);

            infoBoxTmps.Add(infoBoxTmp);   
        }
    }

    public void initWeaponSelectBox()
    {
        
        List<Define.WeaponType> weaponTypes = new List<Define.WeaponType>(GenericSingleton<DataManager>.getInstance().WeaponDict.Keys);
        foreach (Define.WeaponType weaponType in weaponTypes)
        {
            Define.Weapon weaponInfo = GenericSingleton<DataManager>.getInstance().GetWeaponInfo(weaponType);
            int curEnhanceLevel = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceLevel(weaponType);

            GameObject infoBoxTmp = Instantiate(WeaponBox, _weaponContent);
            infoBoxTmp.GetComponent<SelectedInfoBox>().Init(WeaponUpgradeMenuPanel.GetComponent<WeaponBoxController>());
            infoBoxTmp.GetComponent<SelectedInfoBox>().SetData(weaponInfo.thumbnailPath, weaponType.ToString());
            infoBoxTmp.name = "WeaponBox";

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((eventData) => { infoBoxTmp.GetComponent<SelectedInfoBox>().OnClickedWeaponBox(); });

            infoBoxTmp.GetComponent<EventTrigger>().triggers.Add(entry);
        }
    }

    // MainStart ???????
    //ĳ???? ????? ???? ???ξ????? ????
    public void TestStartMain()//Define.HeroType heroType ???? ?????? ?????? ????
    {
        GenericSingleton<GameManager>.getInstance().GameStart(); //ĳ???? ??? ?????????? ?????????????? ???? ????
        SceneManager.LoadScene("MainScene");
    }
}
   
