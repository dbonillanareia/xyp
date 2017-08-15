using System;
using System.ComponentModel;

namespace XypTeam.ViewModel
{
    public class MemberViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        public string Test { get; set; }

        public MemberViewModel()
        {
            Test = "test";
        }
    }
}
