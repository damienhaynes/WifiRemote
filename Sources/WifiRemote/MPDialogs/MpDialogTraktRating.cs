﻿using System;

namespace WifiRemote.MPDialogs
{
    public class MpDialogTraktRating : MpDialog
    {
        TraktPlugin.GUI.GUIRateDialog mpDialog;
        public MpDialogTraktRating(TraktPlugin.GUI.GUIRateDialog dialog)
            : base(dialog)
        {
            this.mpDialog = dialog;
            this.DialogType = dialog.GetModuleName();
            this.DialogId = dialog.GetID;
            this.Rating = ratingFromTraktRateValue(dialog.Rated);
            this.ShowAdvancedRatings = true;
            GetHeading(dialog, 1);
            GetText(dialog, 2, 3, 4, 5);

            this.AvailableActions.Add("cancel");
            this.AvailableActions.Add("setrating");
            this.AvailableActions.Add("confirmrating");
        }

        private int ratingFromTraktRateValue(TraktAPI.Enums.TraktRateValue rateValue) 
        {
            switch (rateValue)
            {
                case TraktAPI.Enums.TraktRateValue.unrate:
                    return 0;

                case TraktAPI.Enums.TraktRateValue.one:
                    return 1;

                case TraktAPI.Enums.TraktRateValue.two:
                    return 2;

                case TraktAPI.Enums.TraktRateValue.three:
                    return 3;

                case TraktAPI.Enums.TraktRateValue.four:
                    return 4;

                case TraktAPI.Enums.TraktRateValue.five:
                    return 5;

                case TraktAPI.Enums.TraktRateValue.six:
                    return 6;

                case TraktAPI.Enums.TraktRateValue.seven:
                    return 7;

                case TraktAPI.Enums.TraktRateValue.eight:
                    return 8;

                case TraktAPI.Enums.TraktRateValue.nine:
                    return 9;

                case TraktAPI.Enums.TraktRateValue.ten:
                    return 10;
            }

            return 0;
        }

        /// <summary>
        /// Current Rating
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// <code>true</code> if the dialog uses advanced rating (1-10), otherwise 'love' (1) and 'hate' (2) are used.
        /// </summary>
        public bool ShowAdvancedRatings { get; set; }

        /// <summary>
        /// Handle actions which are available on this dialog
        /// </summary>
        /// <param name="action">Action to execute</param>
        /// <param name="index">Index (e.g. needed for lists)</param>
        public override void HandleAction(String action, int index)
        {
            base.HandleAction(action, index);

            if (action.Equals("setrating"))
            {
                SetRating(index);
            }

            if (action.Equals("confirmrating"))
            {
                ConfirmRating();
            }
        }

        public void ConfirmRating()
        {
            MediaPortal.GUI.Library.Action confirmAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.ACTION_SELECT_ITEM, 0, 0);
            mpDialog.OnAction(confirmAction);
        }

        /// <summary>
        /// Set Rating for this dialog
        /// </summary>
        /// <param name="rating"></param>
        public void SetRating(int rating)
        {
            MediaPortal.GUI.Library.Action ratingAction = null; ;
            switch (rating)
            {
                case 1:
                    ratingAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.REMOTE_1, 0, 0);
                    break;
                case 2:
                    ratingAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.REMOTE_2, 0, 0);
                    break;
                case 3:
                    ratingAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.REMOTE_3, 0, 0);
                    break;
                case 4:
                    ratingAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.REMOTE_4, 0, 0);
                    break;
                case 5:
                    ratingAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.REMOTE_5, 0, 0);
                    break;
                case 6:
                    ratingAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.REMOTE_6, 0, 0);
                    break;
                case 7:
                    ratingAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.REMOTE_7, 0, 0);
                    break;
                case 8:
                    ratingAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.REMOTE_8, 0, 0);
                    break;
                case 9:
                    ratingAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.REMOTE_9, 0, 0);
                    break;
                case 10:
                    ratingAction = new MediaPortal.GUI.Library.Action(MediaPortal.GUI.Library.Action.ActionType.REMOTE_0, 0, 0);
                    break;
            }

            if (ratingAction != null)
            {
                mpDialog.OnAction(ratingAction);
            }
        }
    }
}
