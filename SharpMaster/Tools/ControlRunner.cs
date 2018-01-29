
using System;
using System.Windows.Forms;

namespace SharpMaster.Tools
{
    public class ControlRunner : IRunner
    {
        private readonly Control control;
        private readonly Action<Exception> catcher;

        public ControlRunner(Control control, Action<Exception> catcher = null)
        {
            this.control = control;
            this.catcher = catcher;
        }

        public void Run(Action action)
        {
            try
            {
                //invoke causes thread deathlocks
                //when disposing thread runners
                control.BeginInvoke(action);
            }
            catch (Exception ex)
            {
                try { catcher?.Invoke(ex); }
                catch (Exception) { }
            }
        }
    }
}