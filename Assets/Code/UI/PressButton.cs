using Client.Components;
using Client.Objects;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Client.UI
{
    public class PressButton:MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            gameObject.GetComponent<EntityRef>().Entity.Get<Pressed>();
        }
    }
}