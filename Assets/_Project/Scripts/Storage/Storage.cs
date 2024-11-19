using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Storage
{
    public class Storage : MonoBehaviour, IPointerClickHandler
    {
        private StoragePresenter _presenter;

        public string OwnerId => _presenter.OwnerId;

        public void Construct(StoragePresenter presenter)
        {
            _presenter = presenter;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _presenter.OnClick();
        }
    }
}