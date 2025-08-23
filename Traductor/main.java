import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Traductor traductor = new Traductor();
        int opcion = -1;

        do {
            System.out.println("\n========= MENÚ =========");
            System.out.println("1. Traducir una frase");
            System.out.println("2. Agregar palabras al diccionario");
            System.out.println("0. Salir");
            System.out.print("Seleccione una opción: ");

            String entrada = scanner.nextLine();
            if (!entrada.matches("\\d")) {
                System.out.println("⚠️ Entrada no válida.");
                continue;
            }

            opcion = Integer.parseInt(entrada);

            switch (opcion) {
                case 1:
                    System.out.print("\nIngrese la frase en español: ");
                    String frase = scanner.nextLine();
                    String resultado = traductor.traducirFrase(frase);
                    System.out.println("\n📝 Traducción:");
                    System.out.println(resultado);
                    break;

                case 2:
                    System.out.print("\nIngrese la palabra en español: ");
                    String esp = scanner.nextLine().toLowerCase().trim();
                    System.out.print("Ingrese la traducción al inglés: ");
                    String eng = scanner.nextLine().toLowerCase().trim();
                    traductor.agregarPalabra(esp, eng);
                    break;

                case 0:
                    System.out.println("👋 ¡Gracias por usar el traductor!");
                    break;

                default:
                    System.out.println("⚠️ Opción inválida.");
            }

        } while (opcion != 0);

        scanner.close();
    }
}
