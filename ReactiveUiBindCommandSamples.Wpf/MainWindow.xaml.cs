using System.Reactive;
using System.Threading.Tasks;
using System.Windows;
using ReactiveUI;

namespace ReactiveUiBindCommandSamples.Wpf
{
    public partial class MainWindow : Window, IViewFor<Window1ViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new Window1ViewModel();

            this.BindCommand(ViewModel, x => x.ButtonCommand, x => x.ButtonClickMe);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (Window1ViewModel)value;
        }

        public Window1ViewModel ViewModel { get; set; }

        private void TextBox2_OnGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox2.Text = @"I got the focus!";
        }

        private void TextBox2_OnLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox2.Text = @"I lost the focus!";
        }
    }

    public class Window1ViewModel
    {
        public Window1ViewModel()
        {
            ButtonCommand = ReactiveCommand.CreateFromTask(async () => await Task.Delay(1000));
        }

        public ReactiveCommand<Unit, Unit> ButtonCommand { get; }
    }

}
