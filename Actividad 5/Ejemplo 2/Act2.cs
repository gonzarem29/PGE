using System;
using System.Collections.Generic;
using System.Threading;

namespace EventDispatcher
{
    public delegate void EventHandler(object sender, EventArgs e);

    // 1. Diseño de una clase que simula un bucle despachador de eventos
    public class EventDispatcher
    {
        private readonly Dictionary<string, EventHandler> eventHandlers = new Dictionary<string, EventHandler>();

        // 2. Definición de eventos personalizados dentro de la clase
        public event EventHandler EventDispatched;

        // Método para suscribir eventos
        public void Subscribe(string eventName, EventHandler eventHandler)
        {
            if (!eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName] = eventHandler;
            }
            else
            {
                eventHandlers[eventName] += eventHandler;
            }
        }

        // Método para desuscribir eventos
        public void Unsubscribe(string eventName, EventHandler eventHandler)
        {
            if (eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName] -= eventHandler;
            }
        }

        // 3. Manipulación de eventos mediante suscripciones y desencadenamientos
        public void DispatchEvent(string eventName)
        {
            Console.WriteLine($"Evento '{eventName}' despachado.");
            EventDispatched?.Invoke(this, EventArgs.Empty);

            // 4. Simulación de la recepción y procesamiento de mensajes utilizando eventos
            Thread.Sleep(1000);
        }
    }

    class Program
    {
        static void Main()
        {
            EventDispatcher eventDispatcher = new EventDispatcher();

            // 3. Manipulación de eventos mediante suscripciones y desencadenamientos
            // Suscribir a un evento
            eventDispatcher.Subscribe("Evento1", Event1Handler);

            // Suscribir a un evento diferente
            eventDispatcher.Subscribe("Evento2", Event2Handler);

            // Manejar el evento global
            eventDispatcher.EventDispatched += GlobalEventHandler;

            // Despachar eventos
            eventDispatcher.DispatchEvent("Evento1");
            eventDispatcher.DispatchEvent("Evento2");

            // Desuscribir un evento
            eventDispatcher.Unsubscribe("Evento1", Event1Handler);

            // Despachar eventos nuevamente
            eventDispatcher.DispatchEvent("Evento1");
            eventDispatcher.DispatchEvent("Evento2");
        }

        static void Event1Handler(object sender, EventArgs e)
        {
            Console.WriteLine("Manejador del Evento1");
        }

        static void Event2Handler(object sender, EventArgs e)
        {
            Console.WriteLine("Manejador del Evento2");
        }

        static void GlobalEventHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Manejador Global del Evento");
        }
    }
}
