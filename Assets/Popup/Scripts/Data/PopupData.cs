using System;
using UnityEngine;

namespace Popup.Data
{
    public class PopupData
    {
        public string descriptionData;
        public string headerData;
        public bool useAcceptButton;
        public bool useDeclineButton;
        public OnAcceptButtonSelectedDelegate popupAccepted;
        public OnDeclineButtonSelectedDelegate popupDeclined;

        public delegate void OnAcceptButtonSelectedDelegate(IPopup popup);
        public delegate void OnDeclineButtonSelectedDelegate(IPopup popup);

        public PopupData(
            string descriptionData, 
            string headerData, 
            bool useAcceptButton, 
            bool useDeclineButton, 
            OnAcceptButtonSelectedDelegate popupAccepted, 
            OnDeclineButtonSelectedDelegate popupDeclined
        )
        {
            this.descriptionData = descriptionData;
            this.headerData = headerData;
            this.useAcceptButton = useAcceptButton;
            this.useDeclineButton = useDeclineButton;
            this.popupAccepted = popupAccepted;
            this.popupDeclined = popupDeclined;
        }
    }
}