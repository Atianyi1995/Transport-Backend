using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum EventType
{
    WIN, PLAY, LOOSE
}
public class EventBus : MonoBehaviour
{

    //EventType.Win -> event(list of methods)
    //Loose -> event(list of methods)
    //Play -> event(list of methods)

    static Dictionary<EventType, UnityEvent> events = new Dictionary<EventType, UnityEvent>();

    public static void Subscribe(EventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;


        if (events.TryGetValue(eventType, out thisEvent) == true)
        {
            thisEvent.AddListener(listener);
            Debug.Log("event already Registered.");
        }
        else
        {

            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            events.Add(eventType, thisEvent);
            Debug.Log("new event  Registered.");

        }
    }

    public static void Publish(EventType eventType)
    {
        if (events.TryGetValue(eventType, out var thisEvent))
        {
            if(thisEvent != null)
            {
                Debug.Log("Publishing event!");

                thisEvent.Invoke();
            }
            else
            {
                Debug.Log("No event!");

            }
        }
    }
}
