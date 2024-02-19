public class RedFireProjectile : SkillProjectile
{
    protected override void OnTriggerEnterAction()
    {
        base.OnTriggerEnterAction();

        Destroy(gameObject);
    }
}
