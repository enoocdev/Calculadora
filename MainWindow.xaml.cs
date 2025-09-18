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
        private string operador = "";
        private bool isResult = false;
        private bool comma = false;

        private string Operar()
        {
            string res = "";
            switch (operador)
            {
                case "X":
                    res = (numero1 * float.Parse(operacion.Content.ToString())).ToString();
                    
                    break;
                case "/":
                    if (float.Parse(operacion.Content.ToString()) == 0)
                    {
                        res = "Error";

                    }
                    else
                    {
                        res = (numero1 / float.Parse(operacion.Content.ToString())).ToString();
                    }
                    
                    break;
                case "+":
                    res = (numero1 + float.Parse(operacion.Content.ToString())).ToString();
                    
                    break;
                case "-":
                    res = (numero1 - float.Parse(operacion.Content.ToString())).ToString();
                    
                    break;
            }

            return res;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClicNumero(object sender, RoutedEventArgs e)
        {
            Button Sen = sender as Button;
            if (operacion.Content != null && operacion.Content.Equals("Error"))
            {
                operacion.Content = "";
            }
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

            if (!Sen.Content.Equals(",") || !comma) 
            {
                operacion.Content += Sen.Content.ToString();
            }
            
        }

        private void Operador(object sender, RoutedEventArgs e)
        {
            Button op = sender as Button;
            string resultado = Operar();
            if (!isResult && operador != "") 
            {
                if (!resultado.Equals("Error"))
                {
                    numero1 = float.Parse(resultado);
                    operacion.Content = "";
                    operador = op.Content.ToString();
                }
                else
                {
                    operacion.Content = resultado;
                    numero1 = 0;
                }
            }
            else 
            {
                numero1 = operacion.Content.ToString() != "Error" ? float.Parse(operacion.Content.ToString()) : 0;
                operacion.Content = "";
                operador = op.Content.ToString();
            }

            comma = false;
            
            
        }

        private void RealizarOperacion(object sender, RoutedEventArgs e)
        {
           
            operacion.Content = Operar();
            isResult = true;
            operador = "";
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