﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIproject.Goals
{
    class GetFuel : Goal // find and follow route to closest fuel
    {
        private Vehicle parent;

        public GetFuel(Vehicle _parent)
        {
            parent = _parent;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
