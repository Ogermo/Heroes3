using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BattleUnitStack
{
    public int curHitPoints { get; private set; }
    public int curAttack { get; private set; }
    public int curDefence { get; private set; }
    public double curInitiative { get; private set; }

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
    //apply changes to stats (heal/attack, buff/debuff)
    public void changeHealth(int Health) //+healed -damaged
    {
        curHitPoints = curHitPoints + Health;
        if (curHitPoints <= 0)
        {
            curHitPoints = 0;
        }
        if (curHitPoints > minion.HitPoints * BasicAmount)
        {
            curHitPoints = minion.HitPoints * BasicAmount;
        }
    }
    public void changeAttack(int attack)
    {
        curAttack = curAttack + attack;
        if (curAttack < 0)
        {
            curAttack = 0;
        }
    }
    public void changeDefence(int defence)
    {
        curDefence = curDefence + defence;
        if (curDefence < 0)
        {
            curDefence = 0;
        }
    }
    public void changeInitiative(double initiative)
    {
        curInitiative = curInitiative + initiative;
        if (curInitiative < 0)
        {
            curInitiative = 0;
        }
    }
    // show stats
    public string ShowBattleStats ()
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