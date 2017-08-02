using Xamarin.Forms;

namespace xyp04
{
    public partial class xyp04Page : ContentPage
    {
        public xyp04Page()
        {
            InitializeComponent();
            BindingContext = new xyp04ViewModel();
        }
    }
}
