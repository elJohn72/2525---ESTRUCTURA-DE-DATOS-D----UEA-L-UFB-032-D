import java.util.*;

public class VacunacionService {
    private List<Ciudadano> ciudadanos;

    public VacunacionService(int total) {
        ciudadanos = new ArrayList<>();
        for (int i = 1; i <= total; i++) {
            ciudadanos.add(new Ciudadano(i, "Ciudadano " + String.format("%03d", i)));
        }
    }

    public List<Ciudadano> getCiudadanos() { return ciudadanos; }

    public void asignarVacunas(int pfizerN, int azN, long seed) {
        Random r = new Random(seed);
        Collections.shuffle(ciudadanos, r);

        for (int i = 0; i < pfizerN; i++) ciudadanos.get(i).setPfizer(true);
        for (int i = pfizerN; i < pfizerN + azN && i < ciudadanos.size(); i++) ciudadanos.get(i).setAstra(true);
    }

    public List<Ciudadano> noVacunados() {
        return ciudadanos.stream()
                .filter(c -> !c.isPfizer() && !c.isAstra())
                .toList();
    }

    public List<Ciudadano> ambasDosis() {
        return ciudadanos.stream()
                .filter(c -> c.isPfizer() && c.isAstra())
                .toList();
    }

    public List<Ciudadano> soloPfizer() {
        return ciudadanos.stream()
                .filter(c -> c.isPfizer() && !c.isAstra())
                .toList();
    }

    public List<Ciudadano> soloAstra() {
        return ciudadanos.stream()
                .filter(c -> !c.isPfizer() && c.isAstra())
                .toList();
    }
}
