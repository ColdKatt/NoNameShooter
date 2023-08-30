namespace Weapons
{
    public abstract class WeaponState
    {
        protected WeaponStateHandler _weapon;
        public WeaponStateHandler Weapon { set => _weapon = value; }
        public abstract void ChangeState();
    }
}
