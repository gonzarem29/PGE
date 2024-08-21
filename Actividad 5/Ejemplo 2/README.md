## 1. Diseño de una clase que simula un bucle despachador de eventos:

public class EventDispatcher (línea 8).
## 2. Definición de eventos personalizados dentro de la clase:

public event EventHandler EventDispatched; (línea 12).
## 3. Manipulación de eventos mediante suscripciones y desencadenamientos:

Suscripción de eventos:
eventDispatcher.Subscribe("Evento1", Event1Handler); (línea 35).
eventDispatcher.Subscribe("Evento2", Event2Handler); (línea 38).
Desuscripción de eventos:
eventDispatcher.Unsubscribe("Evento1", Event1Handler); (línea 47).
Desencadenamiento de eventos:
eventDispatcher.DispatchEvent("Evento1"); (línea 41).
eventDispatcher.DispatchEvent("Evento2"); (línea 42).
EventDispatched?.Invoke(this, EventArgs.Empty); dentro del método DispatchEvent (línea 23).
## 4. Simulación de la recepción y procesamiento de mensajes utilizando eventos:

Simulación de procesamiento con Thread.Sleep(1000); dentro del método DispatchEvent (línea 25).
Manejo de mensajes:
Console.WriteLine("Manejador del Evento1"); dentro de Event1Handler (línea 50).
Console.WriteLine("Manejador del Evento2"); dentro de Event2Handler (línea 54).
Console.WriteLine("Manejador Global del Evento"); dentro de GlobalEventHandler (línea 58).
