using System;

namespace FigurasGeometricas
{
    public class Circulo
    {
        private double radio;

        public Circulo(double radio)
        {
            this.radio = radio;
        }

        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    public class Rectangulo
    {
        private double largo;
        private double ancho;

        public Rectangulo(double largo, double ancho)
        {
            this.largo = largo;
            this.ancho = ancho;
        }

        public double CalcularArea()
        {
            return largo * ancho;
        }

        public double CalcularPerimetro()
        {
            return 2 * (largo + ancho);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circulo miCirculo = new Circulo(5);
            Console.WriteLine("Área del círculo: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro del círculo: " + miCirculo.CalcularPerimetro());

            Rectangulo miRectangulo = new Rectangulo(4, 6);
            Console.WriteLine("Área del rectángulo: " + miRectangulo.CalcularArea());
            Console.WriteLine("Perímetro del rectángulo: " + miRectangulo.CalcularPerimetro());

            Console.ReadKey(); // Espera que el usuario presione una tecla para cerrar la consola
        }
    }
}
