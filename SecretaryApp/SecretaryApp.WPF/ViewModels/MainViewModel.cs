using SecretaryApp.WPF.State.Navigators;
using SecretaryApp.WPF.State.SubNavigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretaryApp.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ISubNavigator SubNavigator { get; set; } = new SubNavigator();
    }
}
