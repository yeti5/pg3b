/*
 ********************************************************************************
 * Copyright (c) 2009 Richard Burke
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 * * Redistributions of source code must retain the above copyright
 *   notice, this list of conditions and the following disclaimer.
 *
 * * Redistributions in binary form must reproduce the above copyright
 *   notice, this list of conditions and the following disclaimer in
 *   the documentation and/or other materials provided with the
 *   distribution.
 *
 * * Neither the name of the copyright holders nor the names of
 *   contributors may be used to endorse or promote products derived
 *   from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 *
 * $Rev: 200 $
 * $Author: rburke $
 * $LastChangedDate: 2009-11-16 21:24:01 -0500 (Mon, 16 Nov 2009) $
 ********************************************************************************
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PG3B.Interface
{
    public class GamepadController
    {
        private PlayerIndex playerIndex;

        public bool IsConnected {get { return GamePad.GetState(playerIndex, GamePadDeadZone.None).IsConnected; } }
        public GamePadButtons Buttons { get { return GamePad.GetState(playerIndex, GamePadDeadZone.None).Buttons; } }
        public GamePadDPad DPad { get { return GamePad.GetState(playerIndex, GamePadDeadZone.None).DPad; } }
        public GamePadThumbSticks ThumbSticks { get { return GamePad.GetState(playerIndex, GamePadDeadZone.None).ThumbSticks; } }
        public GamePadTriggers Triggers { get { return GamePad.GetState(playerIndex, GamePadDeadZone.None).Triggers; } }

        public GamepadController(int _playerIndex)
        {
            PlayerIndex[] map = new PlayerIndex[] { PlayerIndex.One, PlayerIndex.Two, PlayerIndex.Three, PlayerIndex.Four };

            try
            {
                playerIndex = map[_playerIndex - 1];
            }
            catch
            {
                playerIndex = PlayerIndex.One;
            }
        }
    }
}
