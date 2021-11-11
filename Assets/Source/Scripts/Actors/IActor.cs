namespace Ingame
{
    public interface IActor
    {
        public void TakeDamage(float amountOfDamage);
        public void Heal(float amountOfHp);
    }
}