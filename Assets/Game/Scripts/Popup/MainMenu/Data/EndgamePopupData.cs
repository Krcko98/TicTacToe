using Popup.Data;
using UnityEngine;
using Game.Delegate;
using System;
using Popup;

namespace Game.Popup.Data
{
    public class EndgamePopupData : PopupData
    {
        public int winnerPlayer;
        public float gameTime;

        public EndgamePopupData(
            string descriptionData, 
            string headerData, 
            bool useAcceptButton, 
            bool useDeclineButton,
            PopupData.OnAcceptButtonSelectedDelegate popupAccepted,
            PopupData.OnDeclineButtonSelectedDelegate popupDeclined,
            int winner,
            float gameTime
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
            this.winnerPlayer = winner;
            this.gameTime = gameTime;
        }
    }
}