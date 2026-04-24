using Popup.Data;
using UnityEngine;
using Game.Delegate;
using System;
using Popup;
using Game.Save.Stats;

namespace Game.Popup.Data
{
    public class StatsPopupData : PopupData
    {
        public StatsData stats;

        public StatsPopupData(
            string descriptionData, 
            string headerData, 
            bool useAcceptButton, 
            bool useDeclineButton,
            PopupData.OnAcceptButtonSelectedDelegate popupAccepted,
            PopupData.OnDeclineButtonSelectedDelegate popupDeclined,
            StatsData stats
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
            this.stats = stats;
        }
    }
}