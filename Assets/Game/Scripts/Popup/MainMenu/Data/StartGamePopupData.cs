using Popup.Data;
using UnityEngine;
using Game.Delegate;
using System;
using Popup;

namespace Game.Popup.Data
{
    public class StartGamePopupData : PopupData
    {
        public DelegateCollection.OnSelectGameThemeDelegate OnThemeSelected;
        public DelegateCollection.OnStartGameSelectedDelegate OnStartGameSelected;

        public StartGamePopupData(
            string descriptionData, 
            string headerData, 
            bool useAcceptButton, 
            bool useDeclineButton,
            PopupData.OnAcceptButtonSelectedDelegate popupAccepted,
            PopupData.OnDeclineButtonSelectedDelegate popupDeclined,
            DelegateCollection.OnSelectGameThemeDelegate OnThemeSelectedCallback = null,
            DelegateCollection.OnStartGameSelectedDelegate OnStartGameSelectedCallback = null
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
            OnThemeSelected = OnThemeSelectedCallback;
            OnStartGameSelected = OnStartGameSelectedCallback;
        }
    }
}