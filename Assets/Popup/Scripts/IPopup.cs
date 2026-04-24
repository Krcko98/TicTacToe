using UnityEngine;
using Popup.Data;

namespace Popup
{
    public interface IPopup
    {
        public PopupData TextData { get; }
        public void Close();
        public void Open<T>(T data) where T : PopupData;

    }
}