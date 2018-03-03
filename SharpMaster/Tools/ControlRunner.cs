
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
            Action wrapper = () => { Disposer.IgnoreException(action, catcher); };
            control.Invoke(wrapper);   
        }
    }
}