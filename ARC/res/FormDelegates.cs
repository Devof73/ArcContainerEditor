﻿using System;
using System.Windows.Forms;

namespace SpecializedHelpers
{
    public class ControlDelegates
    {
        private delegate void ControlDelegate();
        private static ControlDelegate Do;
        public static void Invoke(Control ctrl, Action e)
        {
            try
            {
                Do = new ControlDelegate(e);
                ctrl.Invoke(Do);
            }
            catch { }
        }


    }
}
