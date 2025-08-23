import java.util.HashMap;

public class Traductor {
    private HashMap<String, String> diccionario;

    public Traductor() {
        diccionario = new HashMap<>();
        inicializarDiccionario();
    }

    private void inicializarDiccionario() {
        diccionario.put("tiempo", "time");
        diccionario.put("persona", "person");
        diccionario.put("año", "year");
        diccionario.put("camino", "way");
        diccionario.put("forma", "way");
        diccionario.put("día", "day");
        diccionario.put("cosa", "thing");
        diccionario.put("hombre", "man");
        diccionario.put("mundo", "world");
        diccionario.put("vida", "life");
        diccionario.put("mano", "hand");
        diccionario.put("parte", "part");
        diccionario.put("niño", "child");
        diccionario.put("ojo", "eye");
        diccionario.put("mujer", "woman");
        diccionario.put("lugar", "place");
        diccionario.put("trabajo", "work");
        diccionario.put("semana", "week");
        diccionario.put("caso", "case");
        diccionario.put("tema", "point");
        diccionario.put("gobierno", "government");
        diccionario.put("empresa", "company");
        diccionario.put("compañía", "company");
    }

    public void agregarPalabra(String esp, String eng) {
        if (!diccionario.containsKey(esp)) {
            diccionario.put(esp, eng);
            System.out.println("✅ Palabra agregada con éxito.");
        } else {
            System.out.println("⚠️ La palabra ya existe en el diccionario.");
        }
    }

    public String traducirFrase(String frase) {
        String[] palabras = frase.split("\\s+|(?=[,.!?;:])");
        StringBuilder traduccion = new StringBuilder();

        for (String palabraOriginal : palabras) {
            String limpia = palabraOriginal.toLowerCase().replaceAll("[^a-záéíóúüñ]", "");
            if (diccionario.containsKey(limpia)) {
                traduccion.append(diccionario.get(limpia)).append(" ");
            } else {
                traduccion.append(palabraOriginal).append(" ");
            }
        }

        return traduccion.toString().trim();
    }
}
