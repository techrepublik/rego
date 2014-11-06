using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win;

namespace StudentRegistration.Helpers
{
    public class NoFocusRectUltraTabControl : IUIElementDrawFilter
    {
        #region Implementation of IUIElementDrawFilter

        public bool DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
        {
            return true;
        }

        public DrawPhase GetPhasesToFilter(ref UIElementDrawParams drawParams)
        {
            return DrawPhase.BeforeDrawFocus;
        }

        #endregion
    }
}
