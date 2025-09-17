using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private float numero1;
        private string operador;
        private bool isResult = false;
        private bool comma = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClicNumero(object sender, RoutedEventArgs e)
        {
            Button Sen = sender as Button;
            if (isResult)
            {
                operacion.Content = "";
                isResult = false;
            }

            
            if (Sen.Content.Equals(",") && !comma)
            {
                if (operacion.Content == null)
                {
                    operacion.Content += "0,";
                    comma = true;
                }
                
            }

            Console.WriteLine(comma);
            Console.WriteLine(Sen.Content.Equals(","));

            if (!Sen.Content.Equals(",") || !comma) 
            {
                operacion.Content += Sen.Content.ToString();
            }
            
        }

        private void Operador(object sender, RoutedEventArgs e)
        {
            Button op = sender as Button;
            comma = false;
            operador = op.Content.ToString();
            numero1 = operacion.Content.ToString() != "Error" ? float.Parse(operacion.Content.ToString()) : 0;
            operacion.Content = "";
        }

        private void RealizarOperacion(object sender, RoutedEventArgs e)
        {
            
                switch (operador)
                {
                    case "X":
                        operacion.Content = (numero1 * float.Parse(operacion.Content.ToString())).ToString();
                        isResult = true;
                        break;
                    case "/":
                        if (float.Parse(operacion.Content.ToString()) == 0)
                        {
                            operacion.Content = "Error"; 
                            
                        }else
                        {
                            operacion.Content = (numero1 / float.Parse(operacion.Content.ToString())).ToString();
                        }
                        isResult = true;
                        break;
                    case "+":
                        operacion.Content = (numero1 + float.Parse(operacion.Content.ToString())).ToString();
                        isResult = true;
                        break;
                    case "-":
                        operacion.Content = (numero1 - float.Parse(operacion.Content.ToString())).ToString();
                        isResult = true;
                        break;
                }

            
        }

        private void Borrar(object sender, RoutedEventArgs e)
        {
            numero1 = 0;
            operador = "";
            isResult = false;
            comma = false;
            operacion.Content = "";

        }

        private void ClearNow(object sender, RoutedEventArgs e)
        {
            operacion.Content = "";
        }
    }
}