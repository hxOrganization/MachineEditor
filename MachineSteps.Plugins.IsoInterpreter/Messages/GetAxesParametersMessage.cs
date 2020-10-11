﻿using MachineSteps.Plugins.IsoInterpreter.Models;
using System;
using System.Collections.Generic;

namespace MachineSteps.Plugins.IsoInterpreter.Messages
{
    public class GetAxesParametersMessage
    {
        public Action<List<Parameter>> GetParameters { get; set; } 
    }
}
