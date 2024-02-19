public class PlayerStatusUI : UIBase
{
    // Todo
    // CharacterInfo UI에 캐릭터 썸네일 로드
    // CharacterInfo UI에 레벨 반영하여 보여주도록
    // ItemSlots UI에 획득한 아이템 보여주도록
    // 각 데이터 실제 데이터와 연동되도록 고려하여 기능 개발

    PlayerInfo _playerInfo;
    ItemSlots _itemSlots;

    void Start()
    {
        _playerInfo = GetComponentInChildren<PlayerInfo>();
        _itemSlots = GetComponentInChildren<ItemSlots>();

        SetLv(GenericSingleton<GameManager>.getInstance().HeroLv);
        Define.HeroType heroType = GenericSingleton<GameManager>.getInstance().HeroType;
        string path = GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType).thumbnailPath;
        SetThumbnail(path);
    }

    public void AddItem(Define.Weapon weaponData)
    {
        if (_itemSlots == null)
            _itemSlots = GetComponentInChildren<ItemSlots>();

        _itemSlots.AddItem(weaponData.thumbnailPath);
    }

    public void SetLv(int lv)
    {
        _playerInfo.SetLv(GenericSingleton<GameManager>.getInstance().HeroLv);
    }

    public void SetThumbnail(string path)
    {
        _playerInfo.SetThumbnail(path);
    }
}
