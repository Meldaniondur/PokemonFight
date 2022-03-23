using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    /// <summary>
    /// Class to represent moves (attacks in Pokemon), currently only holds a name that we're going to use for flavour
    /// </summary>
    public enum MoveType
        {
            Fire,
            Water,
            Grass, 
            Normal
}
public class Move
    {
        //Data
        int power;
        MoveType moveType;
        bool specialAttack;

        //Get methode
        public string Name { get; }

        public int Power { get => power; }
        public MoveType TypeOfMove { get => moveType; }
        public bool IsSpecial { get => specialAttack; }

        //Constructor for the move
        public Move(string name, MoveType moveType, int power,bool specialAttack)
        {
            this.Name = name;
            this.moveType = moveType;
            this.power = power;
            this.specialAttack = specialAttack;
        }
    }
}
