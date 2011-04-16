﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaPortal.Player;

namespace WifiRemote
{
    /// <summary>
    /// Message that is sent to the client in regular updates as when Media is
    /// being played on the htpc
    /// </summary>
    class MessageNowPlayingUpdate
    {
        string type = "nowplayingupdate";
        public String Type
        {
            get { return type; }
        }

        /// <summary>
        /// Duration of the media in seconds
        /// </summary>
        public int Duration
        {
            get { return (int)g_Player.Player.Duration; }
        }

        /// <summary>
        /// Current position in the file in seconds
        /// </summary>
        public int Position
        {
            get { return (int)g_Player.Player.CurrentPosition; }
        }

        /// <summary>
        /// Current speed of the player
        /// </summary>
        public int Speed
        {
            get { return (int)g_Player.Player.Speed; }
        }

        /// <summary>
        /// Is the current playing item tv
        /// </summary>
        public bool IsTv
        {
            get { return g_Player.Player.IsTV; }
        }
    }
}
