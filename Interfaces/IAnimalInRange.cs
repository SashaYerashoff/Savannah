﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Savannah.Interfaces
{
    public interface ITempAnimal : IAnimal
    {
        int Distance { get; set; }
    }
}
