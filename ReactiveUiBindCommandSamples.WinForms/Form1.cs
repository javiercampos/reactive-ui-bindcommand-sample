using System;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactiveUI;

namespace ReactiveUiBindCommandSamples.WinForms
{
    public partial class Form1 : Form, IViewFor<Form1ViewModel>
    {
        public Form1()
        {
            InitializeComponent();
            ViewModel = new Form1ViewModel();

            this.BindCommand(ViewModel, x => x.ButtonCommand, x => x.buttonClickMe);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (Form1ViewModel)value;
        }
        public Form1ViewModel ViewModel { get; set; }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = @"I got the focus!";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = @"I lost the focus!";
        }
    }

    public class Form1ViewModel
    {
        public Form1ViewModel()
        {
            ButtonCommand = ReactiveCommand.CreateFromTask(async () => await Task.Delay(10));
        }

        public ReactiveCommand<Unit, Unit> ButtonCommand { get; }
    }
}
