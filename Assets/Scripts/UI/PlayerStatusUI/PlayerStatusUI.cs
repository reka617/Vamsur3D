public class PlayerStatusUI : UIBase
{
    // Todo
    // CharacterInfo UI�� ĳ���� ����� �ε�
    // CharacterInfo UI�� ���� �ݿ��Ͽ� �����ֵ���
    // ItemSlots UI�� ȹ���� ������ �����ֵ���
    // �� ������ ���� �����Ϳ� �����ǵ��� ����Ͽ� ��� ����

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
