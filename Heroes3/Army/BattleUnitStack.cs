using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BattleUnitStack
{
    public int curHitPoints;
    public int curAttack;
    public int curDefence;
    public double curInitiative;

    public int BasicAmount { get; protected set; }
    public Unit minion { get; protected set; }

    public BattleUnitStack(UnitStack CrusadeStack)
    {
        BasicAmount = CrusadeStack.Amount; // max possible amount of minions
        this.minion = CrusadeStack.minion; 
        curHitPoints = CrusadeStack.minion.HitPoints * CrusadeStack.Amount;
        curAttack = CrusadeStack.minion.Attack;
        curDefence = CrusadeStack.minion.Defence;
        curInitiative = CrusadeStack.minion.Initiative;
    }
    public bool IsDead()
    {
        if (curHitPoints <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public string ShowBattleStats()
    {
        string stats;
        double Alive = (double)curHitPoints / minion.HitPoints;
        Alive = Math.Ceiling(Alive);

        stats = $"Name: {minion.Type}\n" +
    $"Amount: {Alive}\\{BasicAmount} HP: {curHitPoints - ((Alive-1)*minion.HitPoints)}\\{minion.HitPoints}\n" +
    $"Attack: {curAttack}\n" +
    $"Damage: {minion.MinDamage} - {minion.MaxDamage}\n" +
    $"Defence: {curDefence}\n" +
    $"Initiative: {curInitiative}\n";

        return stats;
    }
}