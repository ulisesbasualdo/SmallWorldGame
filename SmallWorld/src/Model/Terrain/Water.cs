﻿using SmallWorld.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Terreno
{
    internal class Water : ITerrain
    {
        public string getTerrainName()
        {
            return "Agua";
        }
    }
}
