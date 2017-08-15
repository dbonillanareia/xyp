using System;
using System.ComponentModel;
using XypTeam.Interfaces;

namespace XypTeam.ViewModel
{
    public class MemberViewModel : IViewModel, INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        public string Test { get; set; }

        public MemberViewModel()
        {
            Test = "test";
        }
    }
}
