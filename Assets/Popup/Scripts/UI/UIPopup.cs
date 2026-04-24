using Popup.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Popup.UI
{
    public class UIPopup : MonoBehaviour, IPopup
    {
        [SerializeField] private Image background;
        [SerializeField] private Button acceptButton;
        [SerializeField] private Button declineButton;

        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private TextMeshProUGUI headerText;

        public Button AcceptButton { get => acceptButton; }
        public Button DeclineButton { get => declineButton; }

        public PopupData TextData { get; protected set; } 

        public virtual void Open<T>(T data) where T : PopupData
        {
            TextData = data;
            if(descriptionText != null)
            {
                descriptionText.text = data.descriptionData;
            } 
            if(headerText != null)
            {
                headerText.text = data.headerData;
            }
            
            if(acceptButton != null)
                acceptButton.gameObject.SetActive(data.useAcceptButton);
            if(declineButton != null)
                declineButton.gameObject.SetActive(data.useDeclineButton);

            Open();
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void Oestroy()
        {
            AcceptButton.onClick.RemoveAllListeners();
            DeclineButton.onClick.RemoveAllListeners();
        }
    }
}