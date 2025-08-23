public class VacunacionCovidApp {
    public static void main(String[] args) {
        VacunacionService service = new VacunacionService(500);
        service.asignarVacunas(75, 75, 20250823L);

        System.out.println("No vacunados: " + service.noVacunados().size());
        System.out.println("Ambas dosis: " + service.ambasDosis().size());
        System.out.println("Solo Pfizer: " + service.soloPfizer().size());
        System.out.println("Solo AstraZeneca: " + service.soloAstra().size());
    }
}
