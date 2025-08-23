public class Ciudadano {
    private int id;
    private String nombre;
    private boolean pfizer;
    private boolean astra;

    public Ciudadano(int id, String nombre) {
        this.id = id;
        this.nombre = nombre;
    }

    public int getId() { return id; }
    public String getNombre() { return nombre; }

    public boolean isPfizer() { return pfizer; }
    public void setPfizer(boolean pfizer) { this.pfizer = pfizer; }

    public boolean isAstra() { return astra; }
    public void setAstra(boolean astra) { this.astra = astra; }

    @Override
    public String toString() {
        return nombre + " [Pfizer=" + pfizer + ", AstraZeneca=" + astra + "]";
    }
}
