﻿using System.Collections.Generic;
using System.Linq;
using MachineSteps.Models.Actions;
using MachineSteps.Models.Steps;
using MachineSteps.Plugins.IsoConverterBase;
using MachineSteps.Plugins.IsoInterpreter.Attributes;
using MachineSteps.Plugins.IsoIstructions;

namespace MachineSteps.Plugins.IsoInterpreter.Converters.G
{
    [GIstructionConverter(3)]
    public class G3Converter : GIstructionConverter<State>
    {
        public override List<MachineStep> Convert(GIstruction istruction, State state)
        {
            var step = new MachineStep()
            {
                Id = GetStepId(),
                Name = "G3",
                Actions = new List<BaseAction>()
            };

            istruction.Parameters.TryGetValue('X', out double x);
            istruction.Parameters.TryGetValue('Y', out double y);
            istruction.Parameters.TryGetValue('I', out double i);
            istruction.Parameters.TryGetValue('J', out double j);
            if (istruction.Parameters.TryGetValue('F', out double v)) state.FeedSpeed = (int)v;

            state.Axes.SetPosition(step, state.FeedSpeed, x, y, i, j, false);
            SetActionsIds(step);

            return (step.Actions.Count() > 0) ? new List<MachineStep>() { step } : null;
        }
    }
}
