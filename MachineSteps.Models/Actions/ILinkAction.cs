﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSteps.Models.Actions
{
    public interface ILinkAction : IBaseAction
    {
        int LinkId { get; set; }
    }
}
