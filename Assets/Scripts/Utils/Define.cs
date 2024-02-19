namespace Define
{
    public class Hero
    {
        public int id;
        public int hp;
        public int moveSpeed;
        public float power;
        public string thumbnailPath;
        public string prefabPath;
        public string basicWeapon;
    }
    
    public class Weapon
    {
        public int id;
        public int lv;
        public float power;
        public int projectileCount;
        public float projectileSpeed;
        public float coolTime;
        public string prefabPath;
        public string thumbnailPath;
        public string rank;
        public string desc;
        public string levelDesc;
    }

    public class WeaponEnhanceData
    {
        public int id;
        public int enhanceLv;
        public float power;
        public int cost;
    }

    public class Monster
    {
        public int id;
        public int hp;
        public int exp;
        public int projectileCount;
        public float power;
        public string prefabPath;
        public string imageUrl;
    }

    public enum HeroType
    {
        None,
        SwordHero,
        Wizard,
        Max
    }

    public enum WeaponType
    {
        None,
        Sword,
        Staff,
        Bible,
        FireField,
        Boomerang,
        Max
    }
    public enum MonsterType
    {
        NormalMob = 1,
        ProjectileMob,
        EliteMob,
        Max
    }
}
