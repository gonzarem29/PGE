#include <iostream>
#include <string>
#include <map>
#include <functional>

using namespace std;

void separador() {
    cout << "----------------------------------------\n";
}

// Clase Nodo que representa cada nodo que puede ser seleccionado o deseleccionado
class Nodo {
public:
    string nombre;
    bool seleccionado;

    // Constructor por defecto
    Nodo() : nombre(""), seleccionado(false) {}

    // Constructor que recibe un nombre
    Nodo(string n) : nombre(n), seleccionado(false) {}

    // Método para seleccionar el nodo
    void seleccionar() {
        seleccionado = true;
        separador();
        cout << "Nodo " << nombre << " seleccionado.\n";
        cout << "Se remarcaron los objetos de este nodo.\n";
    }

    // Método para deseleccionar el nodo
    void deseleccionar() {
        seleccionado = false;
        separador();
        cout << "Nodo " << nombre << " deseleccionado.\n";
        cout << "Se desmarcaron los objetos de este nodo.\n";
    }
};

// Función de conversión de eventos a manejadores, que ahora recibe el nombre del nodo
function<void()> convertirEventoAManejador(const string& evento, Nodo& nodo) {
    if (evento == "seleccionar" || evento == "1") {
        return [&]() { nodo.seleccionar(); separador(); };  // Callback para seleccionar el nodo
    }
    if (evento == "deseleccionar" || evento == "2") {
        return [&]() { nodo.deseleccionar(); separador();};  // Callback para deseleccionar el nodo
    }
    return []() { cout << "Evento no reconocido.\n"; };  // Evento no válido
}

// Función para el despachador de eventos que permite seleccionar entre varios nodos
void despachadorEventos() {
    // Creamos un mapa de nodos donde la clave es el nombre del nodo
    map<string, Nodo> nodos = {
        {"Nodo1", Nodo("Nodo1")},
        {"Nodo2", Nodo("Nodo2")},
        {"Nodo3", Nodo("Nodo3")}
    };

    // Bucle principal que escucha eventos simulados del usuario
    while (true) {
        string evento, nombreNodo;
        cout << "Ingrese el evento: \n";
        cout << "1. Seleccionar\n2. Deseleccionar\n3. Salir\n";
        cin >> evento;

        // Si el evento es "salir", se termina el programa
        if (evento == "salir" || evento == "3") {
            break;
        }

        // Solicita el nombre del nodo para aplicar el evento
        cout << "Ingrese el nombre del nodo ('Nodo1', 'Nodo2', 'Nodo3'): ";
        cin >> nombreNodo;

        // Verifica si el nodo existe en el mapa
        if (nodos.find(nombreNodo) != nodos.end()) {
            // Conversión del evento a un manejador para el nodo especificado
            function<void()> manejadorEvento = convertirEventoAManejador(evento, nodos[nombreNodo]);

            // Ejecuta el manejador correspondiente (seleccionar o deseleccionar)
            manejadorEvento();
        } else {
            cout << "Nodo no encontrado.\n";
        }
    }
}

int main() {
    // Ejecutamos el bucle despachador de eventos
    despachadorEventos();

    return 0;
}
