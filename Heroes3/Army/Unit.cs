using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Unit
{
    public enum Types
    {
        ANGEL,
        BONEDRAGON,
        CYCLOPE,
        DEVIL,
        FURY,
        GRYPHONE,
        HYDRA,
        LICH,
        SHAMAN,
        SKELETON
    }
    public Types Type { get; private set;  }
    public int HitPoints { get; private set; }
    public int Attack { get; private set; }
    public int Defence { get; private set; }
    public int MinDamage { get; private set; }
    public int MaxDamage { get; private set; }
    public double Initiative { get; private set; }

    public Unit(string UnitType, int UnitHitpoints, int UnitAttack, int UnitDefence, int UnitMinDamage, int UnitMaxDamage, double UnitInitiative)
        {
            Type = (Types)System.Enum.Parse(typeof(Types),UnitType);
            HitPoints = UnitHitpoints;
            Attack = UnitAttack;
            Defence = UnitDefence;
            MinDamage = UnitMinDamage;
            MaxDamage = UnitMaxDamage;
            Initiative = UnitInitiative;
        }


    public string ShowStats()
    {
        string stats;
        stats = $"Name: {Type}\n" +
            $"HP: {HitPoints}\n" +
            $"Attack: {Attack}\n" +
            $"Damage: {MinDamage} - {MaxDamage}\n" +
            $"Defence: {Defence}\n" +
            $"Initiative: {Initiative}\n";
        return stats;
    }
}
