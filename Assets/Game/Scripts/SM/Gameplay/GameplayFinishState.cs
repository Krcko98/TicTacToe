using Game.Gameplay;
using Game.Manager;
using Game.Popup.Data;
using Game.SM;
using Game.SM.Gameplay.Data;
using Popup;
using UnityEngine;

namespace Game.SM.Gameplay
{
    public class GameplayFinishState : SMState
    {
        private GameplayFinishStateData data;

        public override void Init<T>(T data)
        {
            this.data = data as GameplayFinishStateData;
        }

        public override void Enter()
        {
            GameController.Instance.EndGamePopup.Open(
                new EndgamePopupData(
                    descriptionData: "",
                    headerData: "Game finished",
                    useAcceptButton: true,
                    useDeclineButton: true,
                    popupAccepted: retryClicked,
                    popupDeclined: exitClicked,
                    winner: GameController.Instance.gameData.winningPlayer,
                    gameTime: GameController.Instance.gameData.timePassed
            ));
        }

        private void retryClicked(IPopup popup)
        {
            GameloopManager.Instance.RestartGame();
        }

        private void exitClicked(IPopup popup)
        {
            GameloopManager.Instance.ReturnToMainMenu();
        }

        public override void Loop()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}