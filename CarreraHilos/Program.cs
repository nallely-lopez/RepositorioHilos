using System; //importación de librerías, permnite usar funciones básicas (writeLine)
using System.Threading;//importa la funcionalidad necesaria para utilizar hilos 
class Program
{ 
    static void Main()
    {
        Console.WriteLine("¡Carrera de hilos!");

        // Crear dos corredores
        Thread corredorA = new Thread(Correr); //creación de objetos thread, los cuales son hilos
        Thread corredorB = new Thread(Correr); //ambos hilos usraán la función correr 
        Thread corredorC = new Thread(Correr); //Se crearón nuevos corredores 
        Thread corredorD = new Thread(Correr);
        //en este punto los hilos están creados pero aun no han comenzado a ejecutarse 

        corredorA.Start("Corredor A"); //inicia la ejecución del hilo con .statrt
        corredorB.Start("Corredor B"); //pasan como arguento el nomre del corredor 

        corredorA.Join(); //detiene la ejecución del programa hasta que el hilo termine 
        corredorB.Join();//el programa esperará hasta que el corredor a termine antes de  continuar con corredor b

        Console.WriteLine("¡Carrera terminada!");
    }

    static void Correr(object nombre) //función ejecutada por el hilo, el cual recibe un parametro nombre, que es el nombre del corredor
    {
        Random rnd = new Random();//generación de numeros aleatorios, el cual se usará para simular las velocidades diferentes entre los corredores 
        for (int pasos = 1; pasos <= 10; pasos++) //bucle en el cada corredor avanza 10 pasos hasta la meta 
        {
            Console.WriteLine($"{nombre} avanzó a la posición: {pasos}"); //cada vez que un corredor avanza, se imprime un mensaje mostrando su posición actual
            Thread.Sleep(rnd.Next(100, 500)); // Velocidad aleatoria
        }
        Console.WriteLine($" {nombre} terminó la carrera!");
    }
}
