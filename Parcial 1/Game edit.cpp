#include <iostream>
#include <unordered_map>
#include <functional>

using namespace std;

// Definición de los callbacks
void gameMode() {
    cout << "Game Mode activado" << endl;
}

void editMode() {
    cout << "Edit Mode activado" << endl;
}

// Función de manejo de error
void showError(const string& mode) {
    cout << "Ya estás en el modo " << mode << "." << endl;
}

// Clase que representa el despachador de eventos
class EventDispatcher {
public:
    unordered_map<char, function<void()>> eventHandlers;  // Mapa de eventos y callbacks
    string currentMode = "";  // Variable para almacenar el modo actual

    // Método para agregar manejadores de eventos al mapa
    void addEventHandler(char eventKey, function<void()> handler) {
        eventHandlers[eventKey] = handler;
    }

    // Función de conversión de teclas a modos
    string convertirTeclaAModo(char key) {
        if (key == 'g') {
            return "Game Mode";
        } else if (key == 'e') {
            return "Edit Mode";
        } else {
            return "";  // Modo desconocido
        }
    }

    // Método que ejecuta el bucle de eventos, esperando la entrada del usuario
    void runEventLoop() {
        char key;
        bool running = true;

        while (running) {
            // Solicita al usuario una entrada
            cout << "Seleccione modo (g: Game Mode, e: Edit Mode, q: Salir): ";
            cin >> key;

            if (key == 'q') {
                running = false;  // Salir del bucle si se ingresa 'q'
            } else if (eventHandlers.find(key) != eventHandlers.end()) {
                // Conversión de la tecla a un modo
                string selectedMode = convertirTeclaAModo(key);

                // Verifica si el modo seleccionado ya está activo
                if (currentMode == selectedMode) {
                    showError(currentMode);  // Muestra un mensaje de error si ya estamos en ese modo
                } else {
                    // Actualiza el modo actual y llama al callback correspondiente
                    currentMode = selectedMode;
                    eventHandlers[key]();  // Llama al callback (gameMode o editMode)
                }
            } else {
                cout << "Evento no reconocido." << endl;  // Tecla no reconocida
            }
        }

        cout << "Saliendo del bucle de eventos." << endl;
    }
};

int main() {
    // Crear una instancia del despachador de eventos
    EventDispatcher dispatcher;

    // Mapear los eventos de entrada de usuario con sus callbacks
    dispatcher.addEventHandler('g', gameMode);
    dispatcher.addEventHandler('e', editMode);

    // Inicia el bucle de eventos
    dispatcher.runEventLoop();

    return 0;
}
