﻿using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Interactable;
using SmallWorld.src.Model.Interactuable;
using SmallWorld.src.Model.Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmallWorld.src.Model
{
    internal class Entity
    {
        IKingdom kingdom;
        string name;
        IDiet diet;
        IHabitat habitat;

        int maxEnergy;
        int currentEnergy;
        int maxLife;
        int currentLife;

        int attackPoints;
        int defensePoints;
        bool attackRange;
        int costToAttack;

        Terrain currentTerrain;
        bool dieStatus;
        int defenseShield;
        //Point position;



        //properties
        //TODO: hacer validaciones en propiedades, informar de alguna manera si esta muerto y no puede recibir mas ataques, talvez borrandolo de la lista, o que la lista traiga solo los vivos. y los interacts se traigan los muertos para abono.
        internal IKingdom Kingdom 
        { 
            get => kingdom;
            set 
            {
                if (value != null) kingdom = value;
                else throw new InvalidOperationException("Debe seleccionar un Reino");
            } 
        }
        public string KingdomName { get { return kingdom.ToString(); } }
        public string Name
        {
            get => name;
            set
            {
                if (value != null) name = value;
                else throw new InvalidOperationException("Debe especificar un Nombre");
            }
        }

        internal IDiet Diet
        {
            get => diet;
            set
            {
                if (value != null) diet = value;
                else throw new InvalidOperationException("Debe especificar una Dieta");
            }
        }
        public string DietName { get { return diet.ToString(); } }
        internal IHabitat Habitat 
        { 
            get => habitat; 
            set
            {
                if (value != null) habitat = value;
                else throw new InvalidOperationException("Debe seleccionar un Habitat");
            }
        }
        public string HabitatName { get { return habitat.ToString(); } }
        public int MaxEnergy
        {
            get => maxEnergy;
            set 
            {
                if (value > 0) maxEnergy = value;
                else throw new InvalidOperationException("La energía máxima debe ser mayor a 0");
            }
        }
        public int MaxLife { 
            get => maxLife;
            //get { return maxLife; }
            set 
            { 
                if (value > 0) maxLife = value;
                else throw new InvalidOperationException("La vida máxima debe ser mayor a 0");
            }
        }
        public int CurrentLife { get => currentLife; set => currentLife = value; }
        public int AttackPoints { get => attackPoints; set => attackPoints = value; }
        public int DefensePoints { get => defensePoints; set => defensePoints = value; }
        public bool AttackRange { get => attackRange; set => attackRange = value; }
        public int CurrentEnergy { get => currentEnergy; set => currentEnergy = value; }
        public bool DieStatus { get => dieStatus; set => dieStatus = value; }
        public int CostToAttack { get => costToAttack; set => costToAttack = value; }
        public int DefenseShield { get => defenseShield; set => defenseShield = value; }

        //public Terrain CurrentTerrain { get => currentTerrain; set => currentTerrain = value; }

        //public Point Position { get => position; set => position = value; }

        //constructor
        public Entity(IKingdom kingdom, string name, IDiet diet, IHabitat habitat, int attackPoints, int defensePoints, bool attackRange, int maxLife, int maxEnergy, int defenseShield)
        {
            Kingdom = kingdom;
            Name = name;
            Diet = diet;
            Habitat = habitat;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            AttackRange = attackRange;
            MaxLife = maxLife;
            CurrentLife = maxLife;
            MaxEnergy = maxEnergy;
            CurrentEnergy = maxEnergy;
            CostToAttack = 30;
            DefenseShield = defenseShield;
            //CurrentTerrain = currentTerrain;
            //Position = position;
        }
        public Entity() { }

        

        public void Feed()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void RangeAttack()
        {
            throw new NotImplementedException();
        }

        public void Rest()
        {
            CurrentEnergy += 50;
            CurrentLife += 100;
            VerifyMaxEnergy();
            VerifyMaxLife();
        }


        


        /// <summary>
        /// This method does that the attacking entity throw a dice and attack to the
        /// victim entity with his attack points and the random value of the trowing dice.
        /// Attack had a cost of energy
        /// </summary>
        /// <param name="EntityToAttack"></param>
        public void Attack(Entity EntityToAttack)
        {
            if (!VerifyIfTheEntityNeedEnergyToDoAnAction(CostToAttack))
            {
                int DicePoints = Dice.TrowDice(6);
                EntityToAttack.TakeDamage(AttackPoints, DicePoints);
                CurrentEnergy -= CostToAttack;
                VerifyMinCurrentEnergy();
            }
        }


        public void TakeDamage(int AttackPointsOfTheAttackingEntity, int AttackDicePoints)
        {
            if (ShieldIsDestroyed())
            {
                CurrentLife -= (AttackPointsOfTheAttackingEntity + AttackDicePoints);
                VerifyMinCurrentLife();
            }
            else 
            { 
                DefenseShield -= (AttackPointsOfTheAttackingEntity + AttackDicePoints);
                VerifyStatusOfDefenseShield();
            }
            
            
        }


        /*Método TakeDamage con la mecánica de lanzar dados y puntos de defensa. Tuve problemas para implementar esto
        public void TakeDamage(int AttackPointsOfTheAttackingEntity, int AttackDicePoints)
        {
            int DicePoints2 = Dice.TrowDice(6);
            Console.WriteLine($"Dado atacante: {AttackDicePoints} Dado Victima: {DicePoints2}");
            MessageBox.Show($"Dado atacante: {AttackDicePoints} Dado Victima: {DicePoints2}");
            //TODO: resolver problema de negativos y positivos



            
            if (DefensePoints > AttackPointsOfTheAttackingEntity)
            {
                //Supongamos  VidaActual = 100 - (100 - 50) 
                //            VidaActual = 50
                CurrentLife = CurrentLife - ((DefensePoints + DicePoints2) - (AttackPointsOfTheAttackingEntity + AttackDicePoints));

            }

            if (DefensePoints < AttackPointsOfTheAttackingEntity)
            {
                //Supongamos  VidaActual = 100 + (50 - 100) 
                //            VidaActual = 50
                CurrentLife = CurrentLife + ((DefensePoints + DicePoints2) - (AttackPointsOfTheAttackingEntity + AttackDicePoints));

            }
            //CurrentLife = CurrentLife - ((DefensePoints + DicePoints2) - (AttackPointsOfTheAttackingEntity + AttackDicePoints));
           
            VerifyMaxLife();

        }*/


        public bool ShieldIsDestroyed()
        {
            bool shieldIsDestroyed = false;
            if (DefenseShield <= 0)
            {
                shieldIsDestroyed = true;
            }
            return shieldIsDestroyed;
        }


        /// <summary>
        /// If after of attack the defense shield had a negative value, 
        /// this points substract CurrentLife
        /// </summary>
        public void VerifyStatusOfDefenseShield()
        {
            if (DefenseShield < 0)
            {
                CurrentLife += DefenseShield;
                DefenseShield = 0;
                VerifyMinCurrentLife();
            }
        }

        public void Interact (Item objectInteractable)
        {
            CurrentLife = CurrentLife + objectInteractable.Points;
        }


        /*public void Move(Terrain DestinyTerrain)
        {
            //TODO: validacion de si el habitat coincide con el terreno
            CurrentTerrain = DestinyTerrain;
        }*/


        public void VerifyMaxLife()
        {
            if(CurrentLife > MaxLife)
            {
                CurrentLife = MaxLife;
            }
        }

        public void VerifyMinCurrentLife()
        {
            if (CurrentLife <= 0)
            {
                CurrentLife = 0;
                Die();
            }
        }

        public void VerifyMaxEnergy()
        {
            if (CurrentEnergy > MaxEnergy)
            {
                CurrentEnergy = MaxEnergy;
            }
        }

        public void VerifyMinCurrentEnergy() 
        {
            if (CurrentEnergy <= 0)
            {
                CurrentEnergy = 0;
                MessageBox.Show($"{name} tiene energía 0, debe dormir para recuperar energía");
            }
        }
        public void Die()
        {
            DieStatus = true;
        }

        public bool VerifyIfTheEntityNeedEnergyToDoAnAction(int Action)
        {
            bool needEnergy = false;
            if (Action >= CurrentEnergy)
            {
                MessageBox.Show($"{Name}necesita descansar y así recuperar energía antes de hacer esta acción");
                needEnergy = true;
            }
            return needEnergy;
        }


        public override string ToString()
        {
            return name;
            //return $"Reino:{Kingdom}, Nombre:{Name}, Dieta:{Diet}, Habitat:{Habitat}, Energía actual:{CurrentEnergy}, Energía Máxima:{MaxEnergy}, Vida Actual:{CurrentLife}, Vida Máxima:{MaxLife}, Puntos de Ataque:{AttackPoints}, Escudo de Defensa:{DefensePoints}, Fuerza del ataque a distancia:{AttackRange}";
        }
    }
}
