using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvFiddle
{
    public abstract class BaseFixer
    {
        internal BaseFixer()
        {

        }

        public abstract void Fix(SETweak.Mods.DataBindings.Environment env);
    }
}
