using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public string weaponName;
    [SerializeField] public int weaponDamage;

    public Weapon(string weaponName, int weaponDamage)
    {
        this.weaponName = weaponName;
        this.weaponDamage = weaponDamage;
    }
}
