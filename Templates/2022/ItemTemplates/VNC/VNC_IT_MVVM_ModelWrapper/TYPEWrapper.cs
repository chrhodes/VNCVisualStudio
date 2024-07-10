using System.Collections.Generic;

using VNC.Core.Mvvm;

using $customAPPLICATION$.Domain;

namespace $rootnamespace$
{
    public class $safeitemname$ : ModelWrapper<Domain.$customTYPE$>
    {
        public $safeitemname$() { }
        public $safeitemname$(Domain.$customTYPE$ model) : base(model)
        {
        }

        // TODO(crhodes)
        // Wrap each property from the passed in model.

        public string StringProperty { get { return GetValue<string>(); } set { SetValue(value); } }
        public int IntProperty { get { return GetValue<int>(); } set { SetValue(value); } }
    }
}
