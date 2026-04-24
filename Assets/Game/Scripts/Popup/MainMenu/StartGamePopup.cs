using Popup.Data;
using Popup.UI;
using UnityEngine;
using Game.Menu;
using CustomButton;
using Game.Popup.Data;

namespace Game.Popup.Menu
{
    public class StartGamePopup : UIPopup
    {
        public override void Open<PopupData>(PopupData data)
        {
            StartGamePopupData popupData = data as StartGamePopupData;
            AcceptButton.onClick.AddListener(() => popupData.popupAccepted(this));
            DeclineButton.onClick.AddListener(() => popupData.popupDeclined(this));

            base.Open(data);
        }

        public void OnDestroy()
        {
            AcceptButton.onClick.RemoveAllListeners();
            DeclineButton.onClick.RemoveAllListeners();
        }
    }
}