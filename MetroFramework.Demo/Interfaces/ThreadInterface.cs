using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Interfaces
{
    public interface ThreadInterface
    {
        void DoWork(object sender, DoWorkEventArgs e);

        bool Pause();

        bool Resume();

        bool RequestStop();
    }
}
