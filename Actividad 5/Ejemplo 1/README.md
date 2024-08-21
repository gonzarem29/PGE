## 1. Diseño de una clase que simula un bucle despachador de eventos:

public class Publicador (línea 4).
## 2. Definición de eventos personalizados dentro de la clase:

public event EventHandler EventoOcurrido; (línea 6).
## 3. Manipulación de eventos mediante suscripciones y desencadenamientos:

En la clase Publicador, la suscripción al evento ocurre en publicador.EventoOcurrido += suscriptor.ManejadorEvento; (línea 27).
El desencadenamiento del evento ocurre en EventoOcurrido?.Invoke(this, EventArgs.Empty); (línea 10).
## 4. Simulación de la recepción y procesamiento de mensajes utilizando eventos:

Console.WriteLine("El evento ha ocurrido."); en el método ManejadorEvento de la clase Suscriptor (línea 15).
