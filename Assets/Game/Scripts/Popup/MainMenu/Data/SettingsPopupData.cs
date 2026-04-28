using Popup.Data;
using UnityEngine;
using Game.Delegate;
using System;
using Popup;
using Game.Save.Stats;

namespace Game.Popup.Data
{
    public class SettingsPopupData : PopupData
    {
        public SettingsPopupData(
            string descriptionData, 
            string headerData, 
            bool useAcceptButton, 
            bool useDeclineButton,
            PopupData.OnAcceptButtonSelectedDelegate popupAccepted,
            PopupData.OnDeclineButtonSelectedDelegate popupDeclined
        ) : 
        base(
            descriptionData : descriptionData, 
            headerData: headerData, 
            useAcceptButton: useAcceptButton, 
            useDeclineButton: useDeclineButton,
            popupAccepted: popupAccepted,
            popupDeclined: popupDeclined
        )
        {
        }
    }
}