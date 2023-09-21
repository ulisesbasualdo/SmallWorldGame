﻿using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Dieta;
using SmallWorld.src.Model.Terreno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Habitat
{
    internal class Aerial : IHabitat
    {
        private string name = "Aéreo";
        private List<ITerrainType> terrainsAcepted = new List<ITerrainType>()
        {
            new Earth(),
            new Water()
        };
        public override bool Equals(object obj)
        {
            if (obj is Aerial other)
            {
                return name == other.name;
            }
            return false;
        }
        public override string ToString()
        {
            return name;
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
