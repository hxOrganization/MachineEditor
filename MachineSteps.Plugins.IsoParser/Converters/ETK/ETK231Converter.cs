﻿using MachineSteps.Models.Steps;
using MachineSteps.Plugins.IsoConverterBase;
using MachineSteps.Plugins.IsoIstructions;
using MachineSteps.Plugins.IsoParser.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MachineSteps.Plugins.IsoParser.Converters.ETK
{
    [ETKConverter(231)]
    public class ETK231Converter : SetVariableIstructionConverter<State>
    {
        public override List<MachineStep> Convert(SetVariableIstruction istruction, State state)
        {
            var bytes = BitConverter.GetBytes((uint)istruction.Value);
            var ar = new BitArray(bytes);
            var n = Math.Min(state.Plane.RoolerBars.Length, ar.Length);

            for (int i = 0; i < n; i++) state.Plane.RoolerBars[i] = ar[i];

            return null;
        }
    }
}
